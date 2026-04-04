using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private CharacterController _characterController;
    private PlayerRoot root;

    
    [Header("Ground Movement")]
    [SerializeField] private float moveSpeed   = 5f;
    [SerializeField] private float sprintSpeed = 10f;
    [SerializeField] private KeyCode sprintKey = KeyCode.LeftShift;

    [Header("Stamina")]
    [SerializeField] private float staminaCostPerSecond     = 10f;
    [SerializeField] private float staminaRecoveryPerSecond = 5f;

    
    [Header("Gravity & Jump")]
    [SerializeField] private float gravity   = -20f;
    [SerializeField] private float jumpForce = 7f;

   
    [Header("Swimming")]
    [SerializeField] private float swimSpeed          = 4f;
    [SerializeField] private float swimAcceleration   = 4f;   
    [SerializeField] private float swimBuoyancySmooth = 5f;   
    [SerializeField] private float swimFloatDepth     = 0.3f; 
    [SerializeField] private float diveDamping        = 3f;   
    [SerializeField] private float diveSpeed          = 3f;   

   
    private float   yVelocity;
    private Vector3 swimVelocity;
    private bool    wasInWater;



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

   

    private void HandleWaterTransition()
    {
        bool inWater = root.Water.InWater;

       
        if (wasInWater && !inWater)
        {
            yVelocity = Mathf.Max(yVelocity, 2f);
        }

        wasInWater = inWater;
    }

  

    private void UpdateSwimming()
    {
        
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 inputDir = Vector3.ClampMagnitude(
            transform.right * moveX + transform.forward * moveZ, 1f);

        Vector3 targetHorizontal = inputDir * swimSpeed;

        
        swimVelocity = Vector3.Lerp(swimVelocity, targetHorizontal, Time.deltaTime * swimAcceleration);

        
        float targetSurfaceY = root.Water.WaterSurfaceY - swimFloatDepth;
        float currentY       = transform.position.y;
        float depthOffset    = targetSurfaceY - currentY; 

       
        float vertInput = 0f;
        if (Input.GetKey(KeyCode.Space))      vertInput =  1f;
        if (Input.GetKey(KeyCode.LeftControl)) vertInput = -1f;

        if (Mathf.Abs(vertInput) > 0.01f)
        {
          
            yVelocity += vertInput * diveSpeed * Time.deltaTime * 10f;
        }
        else
        {
            
            float buoyancyForce = depthOffset * swimBuoyancySmooth;
            yVelocity += buoyancyForce * Time.deltaTime;
        }

       
        yVelocity -= yVelocity * diveDamping * Time.deltaTime;
        yVelocity  = Mathf.Clamp(yVelocity, -diveSpeed, diveSpeed);

        
        Vector3 finalVelocity = swimVelocity;
        finalVelocity.y = yVelocity;

        _characterController.Move(finalVelocity * Time.deltaTime);
    }

   
    private void UpdateGroundMovement()
    {
        
        swimVelocity = Vector3.zero;

        
        if (_characterController.isGrounded)
        {
            yVelocity = -2f; 

            if (Input.GetKeyDown(KeyCode.Space))
                yVelocity = jumpForce;
        }
        else
        {
            yVelocity += gravity * Time.deltaTime;
        }

        
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