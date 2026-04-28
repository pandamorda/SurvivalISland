using _Project.Scripts.Gameplay.Interaction;
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

        
        bool IsPressed(InteractKey key);
        bool IsHeld(InteractKey key);
        bool IsReleased(InteractKey key);
    }

}
