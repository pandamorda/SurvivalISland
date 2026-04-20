using UnityEngine;

namespace _Project.Scripts.Gameplay.Player.Movement
{
    public class SwimmingState : MovementStateBase
    {
       
        private float yVelocity;
        private Vector3 swimVelocity;
        
        public SwimmingState(CharacterController characterController, 
            Transform pos, 
            PlayerRoot playerRoot,
            PlayerMovementConfig playerMovementConfig)
            :base(characterController, pos, playerRoot, playerMovementConfig)
        {
            
            
        }
        
        

        public override void Update()
        {
            Vector2 move = ReadMoveInput();

            Vector3 inputDir = GetPlanarMoveDirection(move);

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

            ApplyMove(finalVelocity);
        }
    }
}

