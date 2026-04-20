using UnityEngine;

namespace _Project.Scripts.Gameplay.Player.Movement
{
    public class AirbornedState : MovementStateBase
    {
        
        private float yVelocity;
        public void SetYVelocity(float value) => yVelocity = value;
        
        public AirbornedState(CharacterController characterController, 
            Transform pos,
            PlayerRoot playerRoot, 
            PlayerMovementConfig playerMovementConfig)
            :base(characterController, pos, playerRoot, playerMovementConfig)
        {
           
        }
       

        public override void Update()
        {
            
            yVelocity += config.Gravity * Time.deltaTime;


            Vector2 move = ReadMoveInput();

            Vector3 moveDir = GetPlanarMoveDirection(move) * config.MoveSpeed;

            moveDir.y = yVelocity;
            ApplyMove(moveDir);
        }
    }
}

