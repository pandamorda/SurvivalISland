using _Project.Scripts.Gameplay.Items.Effects;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class ItemData : ScriptableObject
{
   public string itemName;
   public Sprite icon;
   [TextArea]public string description;

   public ItemEffect[] effects;



}
