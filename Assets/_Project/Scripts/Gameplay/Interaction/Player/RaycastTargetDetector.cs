using _Project.Scripts.Gameplay.Interaction;
using UnityEngine;


public class RaycastTargetDetector : MonoBehaviour, ITargetDetector
{
   

    IInteractable FindCurrentTarget()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.TryGetComponent<IInteractable>(out IInteractable inter))
            {
                return inter;
            }
        }

        return null;
    }
}
