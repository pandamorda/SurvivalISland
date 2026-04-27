using UnityEngine;
using _Project.Scripts.Gameplay.Player.Movement;
namespace _Project.Scripts.Gameplay.Player
{

    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        
        private IMovementState currentState;
        private GroundedState groundedState;
        private SwimmingState swimmingState;
        private AirbornedState airbornedState;
        
        private CharacterController _characterController;
        private PlayerRoot root;
        
        
        [SerializeField] private PlayerMovementConfig config;



        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            root = GetComponent<PlayerRoot>();
            IInputService input = new UnityInputService(config);
            groundedState = new GroundedState(_characterController, transform, root, config, input);
            swimmingState = new SwimmingState(_characterController, transform, root, config, input);
            airbornedState = new AirbornedState(_characterController, transform, root, config, input);
            
            currentState = groundedState;
            currentState.Enter();
        }


        private void Update()
        {
            TransitionCheck();
            currentState.Update();
        }


        void TransitionCheck()
        {
            if (root.Water.InWater && currentState != swimmingState)
                SwitchState(swimmingState);
            else if (!root.Water.InWater && _characterController.isGrounded && currentState != groundedState)
                SwitchState(groundedState);
            else if (!root.Water.InWater && !_characterController.isGrounded && currentState != airbornedState)
                SwitchState(airbornedState); 
        }
        private void SwitchState(IMovementState next)
        {
            bool wasGround = currentState == groundedState;
            bool wasSwimming = currentState == swimmingState;
    
            currentState.Exit();
            currentState = next;
    
            if (wasSwimming && next == airbornedState)
                airbornedState.SetYVelocity(config.ExitWaterBoost);
            if(wasGround && next == airbornedState)
                airbornedState.SetYVelocity(groundedState.YVelocity);
    
            currentState.Enter();
        }
        



     

        
    }
}