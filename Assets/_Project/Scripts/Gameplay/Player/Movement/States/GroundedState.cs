
using UnityEngine;

namespace _Project.Scripts.Gameplay.Player.Movement
{
    public class GroundedState : MovementStateBase
    {
       
        
        private float yVelocity;
        public float YVelocity => yVelocity;

        public GroundedState(
            CharacterController characterController, 
            Transform pos, 
            PlayerRoot playerRoot, 
            PlayerMovementConfig playerMovementConfig, 
            IInputService iInputService)
            : base(characterController, pos, playerRoot, playerMovementConfig, iInputService)
        {
            
        }

       
        public override void Update()
        {
            


            if (characterController.isGrounded)
            {
                yVelocity = config.GroundedYVelocity;

                if (input.JumpPressed)
                    yVelocity = config.JumpForce;
            }



            Vector2 move = ReadMoveInput();

            float currentSpeed;
            float staminaCost = config.StaminaCostPerSecond * Time.deltaTime;

            if (input.SprintHeld && root.Survival.HasStamina(staminaCost))
            {
                currentSpeed = config.SprintSpeed;
                root.Survival.ConsumeStamina(staminaCost);
            }
            else
            {
                currentSpeed = config.MoveSpeed;
                root.Survival.RecoverStamina(config.StaminaRecoveryPerSecond * Time.deltaTime);
            }

            Vector3 moveDir = GetPlanarMoveDirection(move) * currentSpeed;

            moveDir.y = yVelocity;
            ApplyMove(moveDir);
        }
    }
}


