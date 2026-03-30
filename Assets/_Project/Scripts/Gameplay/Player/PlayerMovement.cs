using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{ 
    private CharacterController _characterController; 
    
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float waterGravity = -1.56f;
    [SerializeField] private float jumpForce = 10f;
    
    [SerializeField] private float sprintSpeed = 10f;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private KeyCode sprintKey = KeyCode.LeftShift;
    private Vector3 swimVelocity;
     private PlayerRoot root;
    [SerializeField] private float staminaCostPerSecond = 10f;
    [SerializeField] private float staminaRecoveryPerSecond = 5f;
    
    private float yVelocity;
    void Swim()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.right * moveX
                                + transform.forward * moveY;

        moveDirection = Vector3.ClampMagnitude(moveDirection, 1f);
        Vector3 targetVelocity = moveDirection * moveSpeed * 0.9f;
        
       
        if (Input.GetKey(KeyCode.Space))
        {
            yVelocity = 3f;
        }

        
        swimVelocity = Vector3.Lerp(swimVelocity, targetVelocity, Time.deltaTime * 2f);
        swimVelocity.y = yVelocity;
        _characterController.Move(swimVelocity * Time.deltaTime);
    }

    
    void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        
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
      
        
        Vector3 moveDirection = transform.right * moveX
                                + transform.forward * moveY;

        moveDirection = Vector3.ClampMagnitude(moveDirection, 1f);
        
        moveDirection *= currentSpeed;
        moveDirection.y = yVelocity;
        _characterController.Move(moveDirection * Time.deltaTime);
    }
 
    void ApplyGravity()
    {
        if (root.Water.InWater)
        {
          
            float depth = root.Water.YHeight;

           
            float targetDepth = 0.5f;

            // якщо ми нижче targetDepth -> сила вгору
            // якщо вище -> сила вниз
            float offset = targetDepth - depth;

            float buoyancyForce = 4f;   // сила "виштовхування"
            float waterDamping = 3f;    // гасіння стрибків

            yVelocity += offset * buoyancyForce * Time.deltaTime;
            yVelocity -= yVelocity * waterDamping * Time.deltaTime;
            float wave = Mathf.Sin(Time.time * 2f) * 0.3f;
            yVelocity += wave * Time.deltaTime;
            // невелике обмеження
            yVelocity = Mathf.Clamp(yVelocity, -2f, 2f);
        }
        else
        {
            if (_characterController.isGrounded)
            {
                yVelocity = -2f;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    yVelocity = jumpForce;
                }
            }
            else
            {
                yVelocity += gravity * Time.deltaTime;
            }
        }
    }
    
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        root = GetComponent<PlayerRoot>();

    }
    void OnEnable()
    {
        if (root != null && root.Survival != null)
            
            root.Survival.OnDeath += Disable;
        
    }

    void OnDisable()
    {
        if (root != null)
            root.Survival.OnDeath -= Disable;
    }

    void Disable()
    {
        enabled = false;
    }
    void Update()
    {
        ApplyGravity();
        if (root.Water.InWater)
        {
            Swim();
        }
           
        else
        {
             Move();
        }
       
        
       
        
    }


    
    
}
