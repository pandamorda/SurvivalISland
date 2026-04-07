using UnityEngine;

namespace _Project.Scripts.Gameplay.Player.Movement
{
    public class SwimmingState : IMovementState
    {
        private CharacterController characterController;
        private Transform position;
        private PlayerRoot root;
        private PlayerMovementConfig config;
        
        private float yVelocity;
        private Vector3 swimVelocity;
        
        public SwimmingState(CharacterController characterController, Transform pos, PlayerRoot playerRoot, PlayerMovementConfig playerMovementConfig)
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
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            Vector3 inputDir = Vector3.ClampMagnitude(
                position.right * moveX + position.forward * moveZ, 1f);

            Vector3 targetHorizontal = inputDir * config.SwimSpeed;


            swimVelocity = Vector3.Lerp(swimVelocity, targetHorizontal, Time.deltaTime * config.SwimAcceleration);


            float targetSurfaceY = root.Water.WaterSurfaceY - config.SwimFloatDepth;
            float currentY = position.position.y;
            float depthOffset = targetSurfaceY - currentY;


            float vertInput = 0f;
            if (Input.GetKey(KeyCode.Space)) vertInput = 1f;
            if (Input.GetKey(KeyCode.LeftControl)) vertInput = -1f;

            if (Mathf.Abs(vertInput) > 0.01f)
            {

                yVelocity += vertInput * config.DiveSpeed * Time.deltaTime * config.DiveAccelerationMultiplier;
            }
            else
            {

                float buoyancyForce = depthOffset * config.SwimBuoyancySmooth;
                yVelocity += buoyancyForce * Time.deltaTime;
            }


            yVelocity -= yVelocity * config.DiveDamping * Time.deltaTime;
            yVelocity = Mathf.Clamp(yVelocity, -config.DiveSpeed, config.DiveSpeed);


            Vector3 finalVelocity = swimVelocity;
            finalVelocity.y = yVelocity;

            characterController.Move(finalVelocity * Time.deltaTime);
        }
    }
}

