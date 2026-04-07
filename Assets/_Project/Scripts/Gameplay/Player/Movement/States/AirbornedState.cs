using UnityEngine;

namespace _Project.Scripts.Gameplay.Player.Movement
{
    public class AirbornedState : IMovementState
    {
        private CharacterController characterController;
        private Transform position;
        private PlayerRoot root;
        private PlayerMovementConfig config;
        
        private float yVelocity;
        
        
        public AirbornedState(CharacterController characterController, Transform pos, PlayerRoot playerRoot, PlayerMovementConfig playerMovementConfig)
        {
            this.characterController = characterController;
            this.position = pos;
            this.root = playerRoot;
            this.config = playerMovementConfig;
            
        }
        public void Exit()
        {
            
        }

        public void Enter()
        {
            
        }

        public void Update()
        {
            
            yVelocity += config.Gravity * Time.deltaTime;


            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            Vector3 moveDir = Vector3.ClampMagnitude(
                position.right * moveX + position.forward * moveZ, 1f) * config.MoveSpeed;

            moveDir.y = yVelocity;
            characterController.Move(moveDir * Time.deltaTime);
        }
    }
}

