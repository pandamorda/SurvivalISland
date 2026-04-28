namespace _Project.Scripts.Gameplay.Interaction
{
    public interface IInteractable
    {
        bool CanInteract { get; }
        void Focus();
        void Unfocus();
        void StartInteract();
        void StopInteract();
        void Tick(float deltaTime);
        InteractKey Key { get; }
    }
}