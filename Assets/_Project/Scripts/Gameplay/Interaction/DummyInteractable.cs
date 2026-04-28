using UnityEngine;
namespace _Project.Scripts.Gameplay.Interaction
{
    public class DummyInteractable : MonoBehaviour, IInteractable
    {
        public bool CanInteract => true;
        [SerializeField] private InteractKey key;
        public InteractKey Key => key;
        public void Focus()
        {
            Debug.Log($"[{name}] Focus");
        }

        public void Unfocus()
        {
            Debug.Log($"[{name}] Unfocus");
        }

        public void StartInteract()
        {
            Debug.Log($"[{name}] StartInteract");
        }

        public void StopInteract()
        {
            Debug.Log($"[{name}] StopInteract");
        }

        public void Tick(float deltaTime)
        {
            Debug.Log($"[{name}] Tick");
        }
    }
}