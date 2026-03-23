using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;


public class InventoryUI : MonoBehaviour
{
    [SerializeField] private PlayerInventory inventory;

    [SerializeField] private UIDocument document;
    private VisualElement panel;
    private VisualElement itemsContainer;
    private VisualElement overlay;
    
    [SerializeField] private KeyCode openInventoryKey = KeyCode.Tab;
    private bool isOpen;

    
    
    void OnEnable()
    {
        var root = document.rootVisualElement;
        panel = root.Q<VisualElement>("inventory-panel");
        itemsContainer =root.Q<VisualElement>("items-container");
        overlay = root.Q<VisualElement>("inventory-overlay");
        CloseMenu();
    }

    private void Update()
    {
        if (Input.GetKeyDown(openInventoryKey))
        {
            isOpen = !isOpen;
            if (isOpen)
            {
                OpenMenu();
            }
            else
            {
                CloseMenu();
            }
        }
    }

    void CloseMenu()
    {
        if(panel == null) return;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        overlay.style.display = DisplayStyle.None;
        panel.style.display = DisplayStyle.None;
    }

    void OpenMenu()
    {
        if(panel == null) return;
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
        overlay.style.display = DisplayStyle.Flex;
        panel.style.display = DisplayStyle.Flex;
        Refresh();
        
    }

    VisualElement CreateSlot(ItemData item, int count)
    {
        var slot = new VisualElement();
        slot.AddToClassList("item-slot");
        
        var icon = new VisualElement();
        icon.AddToClassList("item-icon");
        icon.style.backgroundImage = new StyleBackground(item.icon);

        var itenCount = new Label(count.ToString());
        itenCount.AddToClassList("item-count");
        
        slot.Add(icon);
        slot.Add(itenCount);
        return slot;
    }
    void Refresh()
    {
        if (inventory == null) return;
        itemsContainer.Clear();

        foreach (var item in inventory.Items)
        {
            var itemKey = item.Key;
            int itemCount = item.Value;
            var slot = CreateSlot(itemKey, itemCount);
            itemsContainer.Add(slot);
            
            slot.RegisterCallback<ClickEvent>(evt =>
            {
                inventory.UseItem(itemKey);
                Refresh();
            }
                
                );
        }
        
    }
}
