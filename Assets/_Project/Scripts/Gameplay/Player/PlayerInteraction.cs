using System;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float interactDistance = 3f;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private KeyCode interactKey = KeyCode.E;
    
    private IInteractable current;
    private PlayerRoot root;

    private void Awake()
    {
        root = GetComponent<PlayerRoot>();
    }

    private void OnEnable()
    {
        if(root != null)
            root.Survival.OnDeath += Disable;
    }

    private void OnDisable()
    {
        if (root != null)
            root.Survival.OnDeath -= Disable;
    }

    void Disable()
    {
        enabled = false;
    }
    void UpdateFocus()
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
    void HandleInteractionInput()
    {
        if (Input.GetKeyDown(interactKey) && current != null)
        {
            current.Interact();
        }
    }
    void Update()
    {
        UpdateFocus();
        HandleInteractionInput();
    }
}
