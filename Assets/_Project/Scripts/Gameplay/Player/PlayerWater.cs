using UnityEngine;

public class PlayerWater : MonoBehaviour
{
   private PlayerRoot root;
   private bool inWater;
   public bool InWater => inWater;

   void Awake()
   {
      root = GetComponent<PlayerRoot>();
   }
   public void EnterWater()
   {
      Debug.Log(gameObject.name + "in water");
      inWater = true;
      
   }

   public void ExitWater()
   {
      Debug.Log(gameObject.name + "not in water");
      inWater = false;
   }
}
