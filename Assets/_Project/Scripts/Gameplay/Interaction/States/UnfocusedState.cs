namespace _Project.Scripts.Gameplay.Interaction.States
{
    public class UnfocusedState : IInteractionState
    {
        public void Enter(InteractableBase ctx)
        {
            ctx.ApplyUnfocusedVisual();
        }
        public void Exit(InteractableBase ctx)
        { 
            
        }

        public void OnFocus(InteractableBase ctx)
        {
            ctx.TransitionTo(InteractionStateKind.Focused);
        }

           public void Tick(InteractableBase ctx, float dt)
            {
                
            }

            public void OnUnfocus(InteractableBase ctx)
            {
                
            }

            public void OnStartInteract(InteractableBase ctx)
            {
                
            }

            public void OnStopInteract(InteractableBase ctx)
            {
                
            }
            
    }
}