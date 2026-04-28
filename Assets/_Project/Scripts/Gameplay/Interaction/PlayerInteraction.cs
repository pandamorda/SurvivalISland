/*using UnityEngine;
namespace _Project.Scripts.Gameplay.Interaction
{

    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] private float interactDistance = 3f;
        private Camera _playerCamera;
        [SerializeField] private KeyCode interactKey = KeyCode.E;

        private IInteractable _current;


        private void Awake()
        {
            _playerCamera = Camera.main;
        }

        void UpdateFocus()
        {
            Ray ray = _playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f));

            if (Physics.Raycast(ray, out var hit, interactDistance))
            {
                if (hit.collider.TryGetComponent(out IInteractable interactable))
                {
                    if (_current != interactable)
                    {
                        _current?.OnLoseFocus();
                        _current = interactable;
                        _current?.OnFocus();
                    }

                    return;
                }
            }

            if (_current != null)
            {
                _current.OnLoseFocus();
                _current = null;
            }
        }

        void HandleInteractionInput()
        {
            if (Input.GetKeyDown(interactKey) && _current != null)
            {
                _current.StartInteract();
            }
        }

        void Update()
        {
            UpdateFocus();
            HandleInteractionInput();
        }
    }
}*/