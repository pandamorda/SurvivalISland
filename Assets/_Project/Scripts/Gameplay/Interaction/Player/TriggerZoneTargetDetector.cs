using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Interaction.Player
{
    public class TriggerZoneTargetDetector : MonoBehaviour, ITargetDetector
    {
        private readonly HashSet<IInteractable> _interactableObjects = new();
        public IInteractable FindCurrentTarget()
        {
            float minDistance = float.MaxValue;
            IInteractable closest = null; 
            foreach (var interactable in _interactableObjects)
            {
                if (interactable is not MonoBehaviour mb) continue;
                float distance = Vector3.Distance(transform.position, mb.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closest = interactable;
                }
            }
            return closest;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<IInteractable>(out IInteractable interactObject))
            {
                _interactableObjects.Add(interactObject);
            }
         
            
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.TryGetComponent<IInteractable>(out IInteractable interactObject))
            {
                _interactableObjects.Remove(interactObject);
            }
        }
    }
}