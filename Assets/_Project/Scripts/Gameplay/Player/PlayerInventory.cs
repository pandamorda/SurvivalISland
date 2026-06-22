using System.Collections.Generic;
using _Project.Scripts.Gameplay.Items;
using UnityEngine;
using System;

namespace _Project.Scripts.Gameplay.Player
{

public class PlayerInventory : MonoBehaviour
{
   public static PlayerInventory Instance { get; private set; }
   private Dictionary<ItemData, int> items = new Dictionary<ItemData, int>();
   public IReadOnlyDictionary<ItemData, int> Items => items;

   private PlayerRoot root;
   public event Action OnChanged;

   private void Awake()
   {
      root = GetComponent<PlayerRoot>();
      Instance = this;
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
      OnChanged?.Invoke();
   }

   public void RemoveItem(ItemData item, int count)
   {
      if(item == null) return;
      if(!items.ContainsKey(item)) return;
      items[item] -= count;
      if (items[item] <= 0)
      {
         items.Remove(item);
      }
      OnChanged?.Invoke();
   }

   public void UseItem(ItemData item)
   {
      if (!items.ContainsKey(item))
      {
         return;
      }

      if (item.effects != null)
      {
         foreach (var effect in item.effects)
         {
            effect.Apply(root.Survival);
         }
      }
      
      items[item]--;
      
      if (items[item] <= 0)
      {
         items.Remove(item);
      }
      OnChanged?.Invoke();
   }
}
}