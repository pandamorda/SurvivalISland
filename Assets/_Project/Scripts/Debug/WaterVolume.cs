using System;
using UnityEngine;

public class WaterVolume : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
   {
      Debug.Log(other.name + " in water");
      PlayerRoot root = other.gameObject.GetComponent<PlayerRoot>();
      if (root != null)
      {
         root.Water.EnterWater();
      }
   }

   private void OnTriggerExit(Collider other)
   {
      Debug.Log(other.name + " not in water");
      PlayerRoot root = other.gameObject.GetComponent<PlayerRoot>();
      if (root != null)
      {
         root.Water.ExitWater();
      }
   }
}
