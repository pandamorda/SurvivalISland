using UnityEngine;

public class PickableItem : MonoBehaviour, IInteractable
{
    [SerializeField] private ItemData itemName;
    [SerializeField] private PlayerInventory inventory;
    public void Interact()
    {
        inventory.AddItem(itemName);
        Debug.Log("Picked up " + itemName);
        Destroy(gameObject, 0.01f);
    }

    public void OnFocus() { }
    public void OnLoseFocus() { }
}
