using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
   private Dictionary<ItemData, int> items = new Dictionary<ItemData, int>();
   public Dictionary<ItemData, int> Items => items;

   public void AddItem(ItemData item)
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

   public void UseItem(ItemData item)
   {
      if (!items.ContainsKey(item))
      {
         return;
      }

      items[item]--;
      
      if (items[item] <= 0)
      {
         items.Remove(item);
      }
   }
}
