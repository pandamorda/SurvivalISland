using System.Collections.Generic;
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
        
        private List<Color> originalColors = new List<Color>();
        public InteractKey Key => key;
        public IExtractionBehavior Behavior => behavior;
        [SerializeField] private Color focusColor = Color.green;
        private List<Renderer> _renderers = new List<Renderer>();
        private InteractionStateMachine _machine;
        private static readonly int BaseColorId = Shader.PropertyToID("_BaseColor");
        private static readonly int ColorId = Shader.PropertyToID("_Color");
        private List<int> _colorPropertyIds = new List<int>();
        
        void Awake()
        {
            var renderers = GetComponentsInChildren<Renderer>(true);
            foreach (var r in renderers)
            {
                if (r == null) continue;
                _renderers.Add(r);
        
                int propId = r.material.HasProperty(BaseColorId) ? BaseColorId : ColorId;
                _colorPropertyIds.Add(propId);
                originalColors.Add(r.material.GetColor(propId));
            }
    
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
            for (int i = 0; i < _renderers.Count; i++)
            {
                _renderers[i].material.SetColor(_colorPropertyIds[i], focusColor);
            }
            if (_progressBar != null) _progressBar.Show();
        }

        public void ApplyUnfocusedVisual()
        {
            for (int i = 0; i < _renderers.Count; i++)
            {
                _renderers[i].material.SetColor(_colorPropertyIds[i], originalColors[i]);
            }
            if (_progressBar != null) _progressBar.Hide();
        }
        public void UpdateProgress(float t)
        {
            if (_progressBar != null) _progressBar.SetProgress(t);
        }
    }
}

