using _Project.Scripts.Gameplay.Interaction.Behaviors;

namespace _Project.Scripts.Gameplay.Interaction.States
{
    public class InteractingState : IInteractionState
    {
        public void Enter(InteractableBase ctx)
        {
            ctx.Behavior.Begin(ctx);
        }

        public void Exit(InteractableBase ctx)
        {
            
        }

        public void OnFocus(InteractableBase ctx)
        {
            
        }

        public void OnUnfocus(InteractableBase ctx)
        {
            ctx.Behavior.OnInputReleased(ctx);
            ctx.TransitionTo(InteractionStateKind.Unfocused);
        }

        public void OnStartInteract(InteractableBase ctx)
        {
            
        }

        public void OnStopInteract(InteractableBase ctx)
        {
            ctx.Behavior.OnInputReleased(ctx);
            ctx.TransitionTo(InteractionStateKind.Focused);
        }

        public void Tick(InteractableBase ctx, float deltaTime)
        {
            var result = ctx.Behavior.Tick(deltaTime);
            ctx.UpdateProgress(result.Progress);
            if (result.Status == ExtractionStatus.Completed)
            {
                ctx.Behavior.Complete(ctx);
                ctx.TransitionTo(InteractionStateKind.Focused);
            }
            
        }
    }
}