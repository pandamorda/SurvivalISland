/*
using System;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
   private GameObject targetObject;
   private void Update()
   {
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      if (Physics.Raycast(ray,  out RaycastHit hit, 10))
      {
         IInteractable interactableItem = hit.transform.GetComponent<IInteractable>();
         if (interactableItem != null)
         {
            interactableItem.OnFocus();
            targetObject = hit.collider.gameObject;
         }
      }
      
   }
}
*/
