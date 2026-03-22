using System;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float interactDistance = 3f;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private KeyCode interactKey = KeyCode.E;
    private IInteractable current;

    void HandleFocus()
    {
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f));

        if (Physics.Raycast(ray, out var hit, interactDistance))
        {
            if (hit.collider.TryGetComponent(out IInteractable interactable))
            {
                if (current != interactable)
                {
                    current?.OnLoseFocus();
                    current = interactable;
                    current?.OnFocus();
                }

                return;
            }
        }

        if (current != null)
        {
            current.OnLoseFocus();
            current = null;
        }
    }
    void HandleInput()
    {
        if (Input.GetKeyDown(interactKey) && current != null)
        {
            current.Interact();
        }
    }
    void Update()
    {
        HandleFocus();
        HandleInput();
    }
}
