namespace _Project.Scripts.Gameplay.Interaction.States
{
    public class FocusedState : IInteractionState
    {
        public void Enter(InteractableBase ctx)
        {
            ctx.ApplyFocusedVisual();
        }

        public void Exit(InteractableBase ctx)
        {
            
        }

        public void OnFocus(InteractableBase ctx)
        {
            
        }

        public void OnUnfocus(InteractableBase ctx)
        {
            ctx.TransitionTo(InteractionStateKind.Unfocused);
        }

        public void OnStartInteract(InteractableBase ctx)
        {
            ctx.TransitionTo(InteractionStateKind.Interacting);
        }

        public void OnStopInteract(InteractableBase ctx)
        {
            
        }

        public void Tick(InteractableBase ctx, float deltaTime)
        {
            
        } 
    }
}