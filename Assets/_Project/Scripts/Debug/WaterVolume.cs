using System;
using UnityEngine;

public class WaterVolume : MonoBehaviour
{
   public float SurfaceY => transform.position.y;
   private PlayerRoot root;

   private void OnTriggerEnter(Collider other)
   {
      Debug.Log(other.name + " in water");
      root = other.gameObject.GetComponent<PlayerRoot>();
      if (root != null)
      {
         root.Water.EnterWater(SurfaceY);
      }
   }

   private void OnTriggerExit(Collider other)
   {
      Debug.Log(other.name + " not in water");
      root = other.gameObject.GetComponent<PlayerRoot>();
      if (root != null)
      {
         root.Water.ExitWater();
      }
   }
}
