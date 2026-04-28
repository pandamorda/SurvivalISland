using UnityEngine;

namespace _Project.Scripts.Gameplay.Player.Movement
{
    public interface IInputService
    {
        Vector2 MoveInput { get; }
        bool JumpPressed{ get; }
        bool JumpHeld{ get; }
        bool SprintHeld{ get; }
        bool DiveHeld{ get; }

        
        bool InteractPressed { get; }
        bool InteractHeld { get; }
        bool InteractReleased { get; }
    }

}
