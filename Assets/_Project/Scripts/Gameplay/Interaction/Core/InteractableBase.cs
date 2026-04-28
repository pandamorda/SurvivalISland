using UnityEngine;
namespace _Project.Scripts.Gameplay.Interaction
{
    public class InteractableBase : MonoBehaviour, IInteractable
    {
        public bool CanInteract => true;
        [SerializeField] private InteractKey key;
        public InteractKey Key => key;
        private Color originalColor;
        [SerializeField] private Color focusColor = Color.green;
        private MeshRenderer _renderer;
        void Awake()
        {
            _renderer = GetComponent<MeshRenderer>();
            originalColor = _renderer.material.color;
        }

        public void Focus()
        {
            _renderer.material.color = focusColor;
        }

        public void Unfocus()
        {
            _renderer.material.color = originalColor;
        }

        public void StartInteract()
        {
            Debug.Log("Interact");
        }

        public void StopInteract()
        {

        }

        public void Tick(float deltaTime)
        {

        }
    }
}

