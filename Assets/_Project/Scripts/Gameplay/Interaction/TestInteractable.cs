using UnityEngine;

public class TestInteractable : MonoBehaviour, IInteractable
{
   [SerializeField] private Renderer renderer;
   private Color color;
   private bool isFocused;
   
   public void Interact()
   {
      Debug.Log("Interact");
   }
   public void OnFocus()
   {
      if(isFocused) return;
      
      color = renderer.material.color;
      renderer.material.color = Color.yellow;
      isFocused = true;
   }

   public void OnLoseFocus()
   {
      if(!isFocused) return;
      
      renderer.material.color = color;
      isFocused = false;
   }
}
