using System.Collections.Generic;
namespace _Project.Scripts.Gameplay.Interaction.States
{
    public class InteractionStateMachine
    {
        private readonly InteractableBase _ctx;
        private readonly Dictionary<InteractionStateKind, IInteractionState> _states;
        public IInteractionState Current { get; private set; }

        public InteractionStateMachine(InteractableBase ctx)
        {
            _ctx = ctx;
            _states = new Dictionary<InteractionStateKind, IInteractionState>
            {
                { InteractionStateKind.Unfocused, new UnfocusedState() },
                { InteractionStateKind.Focused, new FocusedState() },
                { InteractionStateKind.Interacting, new InteractingState() },
            };
            Current = _states[InteractionStateKind.Unfocused];
            Current.Enter(_ctx);
        }

        public void  TransitionTo(InteractionStateKind kind)
        {
            if (!_states.ContainsKey(kind))
            {
                return;
            }

            if (_states[kind] == Current)
            {
                return;
            }
            Current.Exit(_ctx);
            Current = _states[kind];
            Current.Enter(_ctx);

        }
    }
}