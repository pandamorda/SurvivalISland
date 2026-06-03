namespace _Project.Scripts.Gameplay.Interaction.States
{
    public interface IInteractionState
    {
        void Enter(InteractableBase ctx);
        void Exit(InteractableBase ctx);
        void OnFocus(InteractableBase ctx);
        void OnUnfocus(InteractableBase ctx);
        void OnStartInteract(InteractableBase ctx);
        void OnStopInteract(InteractableBase ctx);
        void Tick(InteractableBase ctx, float deltaTime);
    }
}