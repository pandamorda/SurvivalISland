using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
   public Dictionary<string, int> items = new Dictionary<string, int>();

   public void AddItem(string item)
   {
      if (items.ContainsKey(item))
      {
         items[item]++;
      }
      else
      {
         items[item] = 1;
      }
      
      Debug.Log("item " + item + " add to inventory" );
   }
}
