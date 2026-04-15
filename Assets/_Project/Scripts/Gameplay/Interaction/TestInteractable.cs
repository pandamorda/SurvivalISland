using UnityEngine;

namespace _Project.Scripts.Gameplay.Interaction
{
   public class TestInteractable : MonoBehaviour, IInteractable
   {
      [SerializeField] private new Renderer renderer;
      private Color _color;
      private bool _isFocused;
   
      public void Interact()
      {
         Debug.Log("Interact");
      }
      public void OnFocus()
      {
         if(_isFocused) return;
      
         _color = renderer.material.color;
         renderer.material.color = Color.yellow;
         _isFocused = true;
      }

      public void OnLoseFocus()
      {
         if(!_isFocused) return;
      
         renderer.material.color = _color;
         _isFocused = false;
      }
   }
}
