using UnityEngine;

namespace _Project.Scripts.Gameplay.Player.Movement
{
    public abstract class MovementStateBase : IMovementState
    {
        protected readonly CharacterController characterController;
        protected readonly Transform position;
        protected readonly PlayerRoot root;
        protected readonly PlayerMovementConfig config;
        protected readonly IInputService input;
        protected MovementStateBase(CharacterController characterController, Transform pos, PlayerRoot playerRoot, PlayerMovementConfig playerMovementConfig, IInputService iInputService)
        {
            this.characterController = characterController;
            this.position = pos;
            this.root = playerRoot;
            this.config = playerMovementConfig;
            this.input = iInputService;

        }
        public virtual void Enter()
        {

        }

        public virtual void Exit()
        {

        }

        public abstract void Update();

        protected Vector2 ReadMoveInput()
        {
            return input.MoveInput;
        }

        protected Vector3 GetPlanarMoveDirection(Vector2 input)
        {
            Vector3 moveDir = Vector3.ClampMagnitude(
                position.right * input.x + position.forward * input.y, 1f) ;
            return moveDir;
        }

        protected void ApplyMove(Vector3 velocity)
        {
            characterController.Move(velocity * Time.deltaTime);
        }
    }
}