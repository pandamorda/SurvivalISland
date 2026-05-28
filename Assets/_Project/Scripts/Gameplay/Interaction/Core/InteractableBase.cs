using _Project.Scripts.Gameplay.Interaction.Behaviors;
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
            if (_progressBar != null)
            _progressBar.Show();
            _renderer.material.color = focusColor;
        }

        public void Unfocus()
        {
            if (this == null || _renderer == null) return;
            if (_progressBar != null)
            _progressBar.Hide();
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
            if (_progressBar != null)
            _progressBar.SetProgress(result.Progress);
            if (result.Status == ExtractionStatus.Completed)
            {
                behavior.Complete(this);
                if (_progressBar != null)
                _progressBar.Hide();
                _isInteracting = false;
            }
        }
    }
}

