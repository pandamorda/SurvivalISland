using _Project.Scripts.Gameplay.Interaction.Behaviors;
using _Project.Scripts.Gameplay.Interaction.States;
using UnityEngine;
using _Project.Scripts.Gameplay.Interaction.UI;

namespace _Project.Scripts.Gameplay.Interaction
{
    public class InteractableBase : MonoBehaviour, IInteractable
    {
        public bool CanInteract => true;
        [SerializeField] private InteractKey key;
        [SerializeReference, SubclassSelector] private IExtractionBehavior behavior;
        [SerializeField] private ProgressBar _progressBar;
        
        private Color originalColor;
        public InteractKey Key => key;
        public IExtractionBehavior Behavior => behavior;
        [SerializeField] private Color focusColor = Color.green;
        private MeshRenderer _renderer;
        private InteractionStateMachine _machine;
        
        void Awake()
        {
            _renderer = GetComponent<MeshRenderer>();
            originalColor = _renderer.material.color;
            _machine = new InteractionStateMachine(this);
            
        }
        public void Focus() => _machine.Current.OnFocus(this);
        public void Unfocus() => _machine.Current.OnUnfocus(this);
        public void StartInteract() => _machine.Current.OnStartInteract(this);
        public void StopInteract() => _machine.Current.OnStopInteract(this);
        public void Tick(float deltaTime) => _machine.Current.Tick(this, deltaTime);
        public void TransitionTo(InteractionStateKind kind) => _machine.TransitionTo(kind);
        public void ApplyFocusedVisual()
        {
            if (_renderer != null) _renderer.material.color = focusColor;
            if (_progressBar != null) _progressBar.Show();
        }

        public void ApplyUnfocusedVisual()
        {
            if (_renderer != null) _renderer.material.color = originalColor;
            if (_progressBar != null) _progressBar.Hide();
        }

        public void UpdateProgress(float t)
        {
            if (_progressBar != null) _progressBar.SetProgress(t);
        }
    }
}

