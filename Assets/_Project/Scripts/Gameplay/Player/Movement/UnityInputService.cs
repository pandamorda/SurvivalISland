
using _Project.Scripts.Gameplay.Interaction;
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
        
        public bool IsPressed(InteractKey key)  => Input.GetKeyDown(KeyFor(key));
        public bool IsHeld(InteractKey key)     => Input.GetKey(KeyFor(key));
        public bool IsReleased(InteractKey key) => Input.GetKeyUp(KeyFor(key));
        
        private KeyCode KeyFor(InteractKey key) => key switch
        {
            InteractKey.Chop   => KeyCode.Mouse0,
            InteractKey.Open   => KeyCode.E,
            InteractKey.Pickup => KeyCode.F,
        };
        
    }
    
}

