
using _Project.Scripts.Gameplay.Interaction;
using UnityEngine;
namespace _Project.Scripts.Gameplay.Player.Movement{

    public class UnityInputService : IInputService
    {
        private readonly PlayerMovementConfig config;
        private InteractKey key;
        public Vector2 MoveInput => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        public bool SprintHeld => Input.GetKey(config.SprintKey);
        public bool JumpHeld => Input.GetKey(KeyCode.Space);
        public bool DiveHeld => Input.GetKey(KeyCode.LeftControl);
        public bool JumpPressed => Input.GetKeyDown(KeyCode.Space);


        public bool InteractPressed => Input.GetKeyDown(KeyCode.E);
        public bool InteractHeld => Input.GetKey(KeyCode.E);
        public bool InteractReleased => Input.GetKeyUp(KeyCode.E);
        public UnityInputService(PlayerMovementConfig config, InteractKey key)
        {
            this.config = config;
            this.key = key;
        }
        private KeyCode KeyFor(InteractKey key) => key switch
        {
            InteractKey.Chop   => KeyCode.Mouse0,
            InteractKey.Open   => KeyCode.E,
            InteractKey.Pickup => KeyCode.F,
        };
    }
    
}

