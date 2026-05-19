namespace _Project.Scripts.Gameplay.Interaction.Behaviors
{
    public interface IExtractionBehavior
    {
        void Begin(InteractableBase host);
        void OnInputReleased(InteractableBase host);
        ExtractionTickResult Tick(float deltaTime);
        void Complete(InteractableBase host);
    }
}