using _Project.Scripts.Gameplay.Interaction.Behaviors;
using UnityEngine;
namespace _Project.Scripts.Gameplay.Interaction
{
    public class InteractableBase : MonoBehaviour, IInteractable
    {
        public bool CanInteract => true;
        [SerializeField] private InteractKey key;
        [SerializeReference, SubclassSelector] private IExtractionBehavior behavior;
        
        public InteractKey Key => key;
        private Color originalColor;
        [SerializeField] private Color focusColor = Color.green;
        private MeshRenderer _renderer;
        private bool _isInteracting;
        void Awake()
        {
            _renderer = GetComponent<MeshRenderer>();
            originalColor = _renderer.material.color;
        }

        public void Focus()
        {
            if (this == null || _renderer == null) return;
            _renderer.material.color = focusColor;
        }

        public void Unfocus()
        {
            if (this == null || _renderer == null) return;
            _renderer.material.color = originalColor;
        }

        public void StartInteract()
        {
            behavior.Begin(this);
            _isInteracting = true;
        }

        public void StopInteract()
        {
            behavior.OnInputReleased(this);
            _isInteracting = false;
        }

        public void Tick(float deltaTime)
        {
            if (!_isInteracting) return;
            ExtractionTickResult result = behavior.Tick(deltaTime);
            if (result.Status == ExtractionStatus.Completed)
            {
                behavior.Complete(this);
                _isInteracting = false;
            }
        }
    }
}

