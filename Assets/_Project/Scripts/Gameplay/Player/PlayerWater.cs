using UnityEngine;

public class PlayerWater : MonoBehaviour
{
   private PlayerRoot root;
   private bool inWater;
   private float yHeight;
   public float YHeight => yHeight;
   public bool InWater => inWater;
   private float yWater;

   void Awake()
   {
      root = GetComponent<PlayerRoot>();
   }
   public void EnterWater(float yWater)
   {
      Debug.Log(gameObject.name + "in water");
      inWater = true;
      this.yWater = yWater;

   }

   public void ExitWater()
   {
      Debug.Log(gameObject.name + "not in water");
      inWater = false;
   }
   
   private void Update()
   {
      if (root != null)
      {
       
         float playerY = transform.position.y;
         yHeight = ( yWater - playerY );
      }
      
   }
}
