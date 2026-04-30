using UnityEngine;

namespace _Project.Scripts.Gameplay.Interaction.Player
{
    public class RaycastTargetDetector : MonoBehaviour, ITargetDetector
    {
        [SerializeField] private float _interactDistance = 10f;
        [SerializeField] private LayerMask _layer;
        [SerializeField] private Camera _camera;
        public IInteractable FindCurrentTarget()
        {
            Ray ray = new Ray(GetComponent<Camera>().transform.position, GetComponent<Camera>().transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, _interactDistance, _layer))
            {
                if (hit.collider.TryGetComponent<IInteractable>(out IInteractable inter))
                {
                    return inter;
                }
            }
    
            return null;
        }
    }
}

