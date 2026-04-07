
using UnityEngine;

namespace _Project.Scripts.Gameplay.Player.Movement
{
    public class GroundedState : IMovementState
    {
        private CharacterController characterController;
        private Transform position;
        private PlayerRoot root;
        private PlayerMovementConfig config;
        
        private float yVelocity;
        
        
        public GroundedState(CharacterController characterController, Transform pos, PlayerRoot playerRoot, PlayerMovementConfig playerMovementConfig)
        {
            this.characterController = characterController;
            this.position = pos;
            this.root = playerRoot;
            this.config = playerMovementConfig;
            
        }

        public void Enter()
        {
            
        }

        public void Exit()
        {
            
        }
        public void Update()
        {
            


            if (characterController.isGrounded)
            {
                yVelocity = config.GroundedYVelocity;

                if (Input.GetKeyDown(KeyCode.Space))
                    yVelocity = config.JumpForce;
            }
            else
            {
                yVelocity += config.Gravity * Time.deltaTime;
            }


            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            float currentSpeed;
            float staminaCost = config.StaminaCostPerSecond * Time.deltaTime;

            if (Input.GetKey(config.SprintKey) && root.Survival.HasStamina(staminaCost))
            {
                currentSpeed = config.SprintSpeed;
                root.Survival.ConsumeStamina(staminaCost);
            }
            else
            {
                currentSpeed = config.MoveSpeed;
                root.Survival.RecoverStamina(config.StaminaRecoveryPerSecond * Time.deltaTime);
            }

            Vector3 moveDir = Vector3.ClampMagnitude(
                position.right * moveX + position.forward * moveZ, 1f) * currentSpeed;

            moveDir.y = yVelocity;
            characterController.Move(moveDir * Time.deltaTime);
        }
    }
}


