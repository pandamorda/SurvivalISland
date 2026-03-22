using System;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float interactDistance = 3f;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private KeyCode interactKey = KeyCode.E;

    void Interact()
    {
        if (!Input.GetKeyDown(interactKey))
        {
            return;
        }

        Ray ray =  playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f));
       
            if (Physics.Raycast(ray, out var hit, interactDistance))
            {
                if (hit.collider.TryGetComponent(out IInteractable interactable))
                {
                
                     interactable.Interact();
                }
            }
    }

    private void Update()
    {
        Interact();
    }
}
