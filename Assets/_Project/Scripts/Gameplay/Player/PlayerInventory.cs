using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Player
{

public class PlayerInventory : MonoBehaviour
{
   private Dictionary<ItemData, int> items = new Dictionary<ItemData, int>();
   public Dictionary<ItemData, int> Items => items;

   private PlayerRoot root;

   private void Awake()
   {
      root = GetComponent<PlayerRoot>();
   }

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
   }

  

   public void UseItem(ItemData item)
   {
      if (!items.ContainsKey(item))
      {
         return;
      }

      foreach (var effect in item.effects)
      {
         effect.Apply(root.Survival);
      }
      items[item]--;
      
      if (items[item] <= 0)
      {
         items.Remove(item);
      }
   }
}
}