
using UnityEngine;
namespace _Project.Scripts.Gameplay.Player.Movement{

    public class UnityInputService : IInputService
    {
        private readonly PlayerMovementConfig config;
        
        public Vector2 MoveInput => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        public bool SprintHeld => Input.GetKey(config.SprintKey);
        public bool JumpHeld => Input.GetKey(KeyCode.Space);
        public bool DiveHeld => Input.GetKey(KeyCode.LeftControl);
        public bool JumpPressed => Input.GetKeyDown(KeyCode.Space);
        
        public UnityInputService(PlayerMovementConfig config)
        {
            this.config = config;
        }
    }
    
}

