using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private CharacterController _characterController;
    private PlayerRoot root;

    // ── Рух по землі ──────────────────────────────────────────
    [Header("Ground Movement")]
    [SerializeField] private float moveSpeed   = 5f;
    [SerializeField] private float sprintSpeed = 10f;
    [SerializeField] private KeyCode sprintKey = KeyCode.LeftShift;

    [Header("Stamina")]
    [SerializeField] private float staminaCostPerSecond     = 10f;
    [SerializeField] private float staminaRecoveryPerSecond = 5f;

    // ── Гравітація / стрибок ───────────────────────────────────
    [Header("Gravity & Jump")]
    [SerializeField] private float gravity   = -20f;
    [SerializeField] private float jumpForce = 7f;

    // ── Плавання ──────────────────────────────────────────────
    [Header("Swimming")]
    [SerializeField] private float swimSpeed          = 4f;
    [SerializeField] private float swimAcceleration   = 4f;   // плавність набору швидкості
    [SerializeField] private float swimBuoyancySmooth = 5f;   // швидкість "виспливання" на поверхню
    [SerializeField] private float swimFloatDepth     = 0.3f; // на скільки метрів нижче поверхні тримається гравець
    [SerializeField] private float diveDamping        = 3f;   // гасіння вертикального руху у воді
    [SerializeField] private float diveSpeed          = 3f;   // швидкість занурення/підйому (Space/Ctrl)

    // ── Внутрішній стан ───────────────────────────────────────
    private float   yVelocity;
    private Vector3 swimVelocity;
    private bool    wasInWater;

    // ─────────────────────────────────────────────────────────
    //  Unity lifecycle
    // ─────────────────────────────────────────────────────────

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        root = GetComponent<PlayerRoot>();
    }

    private void OnEnable()
    {
        if (root?.Survival != null)
            root.Survival.OnDeath += Disable;
    }

    private void OnDisable()
    {
        if (root != null)
            root.Survival.OnDeath -= Disable;
    }

    private void Disable() => enabled = false;

    private void Update()
    {
        HandleWaterTransition();

        if (root.Water.InWater)
            UpdateSwimming();
        else
            UpdateGroundMovement();
    }

    // ─────────────────────────────────────────────────────────
    //  Перехід між водою і суходолом
    // ─────────────────────────────────────────────────────────

    private void HandleWaterTransition()
    {
        bool inWater = root.Water.InWater;

        // Щойно вийшли з води — даємо імпульс вгору (не падати одразу)
        if (wasInWater && !inWater)
        {
            yVelocity = Mathf.Max(yVelocity, 2f);
        }

        wasInWater = inWater;
    }

    // ─────────────────────────────────────────────────────────
    //  Плавання
    // ─────────────────────────────────────────────────────────

    private void UpdateSwimming()
    {
        // --- Горизонтальний рух ---
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 inputDir = Vector3.ClampMagnitude(
            transform.right * moveX + transform.forward * moveZ, 1f);

        Vector3 targetHorizontal = inputDir * swimSpeed;

        // Плавне прискорення
        swimVelocity = Vector3.Lerp(swimVelocity, targetHorizontal, Time.deltaTime * swimAcceleration);

        // --- Вертикальний рух (занурення / підйом) ---
        float targetSurfaceY = root.Water.WaterSurfaceY - swimFloatDepth;
        float currentY       = transform.position.y;
        float depthOffset    = targetSurfaceY - currentY; // > 0 = нижче поверхні, треба підняти

        // Вхід/вихід (Space = вгору, LeftCtrl = вниз)
        float vertInput = 0f;
        if (Input.GetKey(KeyCode.Space))      vertInput =  1f;
        if (Input.GetKey(KeyCode.LeftControl)) vertInput = -1f;

        if (Mathf.Abs(vertInput) > 0.01f)
        {
            // Гравець керує вертикаллю вручну
            yVelocity += vertInput * diveSpeed * Time.deltaTime * 10f;
        }
        else
        {
            // Буяння: плавно тягнемо до цільової глибини
            float buoyancyForce = depthOffset * swimBuoyancySmooth;
            yVelocity += buoyancyForce * Time.deltaTime;
        }

        // Гасіння вертикальної швидкості у воді (відчуття густоти)
        yVelocity -= yVelocity * diveDamping * Time.deltaTime;
        yVelocity  = Mathf.Clamp(yVelocity, -diveSpeed, diveSpeed);

        // --- Збираємо фінальний вектор руху ---
        Vector3 finalVelocity = swimVelocity;
        finalVelocity.y = yVelocity;

        _characterController.Move(finalVelocity * Time.deltaTime);
    }

    // ─────────────────────────────────────────────────────────
    //  Рух по суші
    // ─────────────────────────────────────────────────────────

    private void UpdateGroundMovement()
    {
        // Скидаємо swim-velocity при виході на сушу
        swimVelocity = Vector3.zero;

        // --- Гравітація / стрибок ---
        if (_characterController.isGrounded)
        {
            yVelocity = -2f; // невеликий прижим до землі

            if (Input.GetKeyDown(KeyCode.Space))
                yVelocity = jumpForce;
        }
        else
        {
            yVelocity += gravity * Time.deltaTime;
        }

        // --- Горизонтальна швидкість ---
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        float currentSpeed;
        float staminaCost = staminaCostPerSecond * Time.deltaTime;

        if (Input.GetKey(sprintKey) && root.Survival.HasStamina(staminaCost))
        {
            currentSpeed = sprintSpeed;
            root.Survival.ConsumeStamina(staminaCost);
        }
        else
        {
            currentSpeed = moveSpeed;
            root.Survival.RecoverStamina(staminaRecoveryPerSecond * Time.deltaTime);
        }

        Vector3 moveDir = Vector3.ClampMagnitude(
            transform.right * moveX + transform.forward * moveZ, 1f) * currentSpeed;

        moveDir.y = yVelocity;
        _characterController.Move(moveDir * Time.deltaTime);
    }
}