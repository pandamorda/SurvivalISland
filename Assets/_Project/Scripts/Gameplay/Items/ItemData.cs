using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class ItemData : ScriptableObject
{
   public string itemName;
   public Sprite icon;
   public ResourceType resourceType;
   [TextArea]public string description;
   
   public EffectsType effectType;
   public float value;
   public bool isPositive;

}
