using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
   private Dictionary<string, int> items = new Dictionary<string, int>();
   public Dictionary<string, int> Items => items;

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
