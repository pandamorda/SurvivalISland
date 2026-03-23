using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;


public class InventoryUI : MonoBehaviour
{
    [SerializeField] private PlayerInventory inventory;

    [SerializeField] private UIDocument document;
    private VisualElement panel;
    private VisualElement itemsContainer;
    
    [SerializeField] private KeyCode openInventoryKey = KeyCode.Tab;
    private bool isOpen;

    
    
    void OnEnable()
    {
        var root = document.rootVisualElement;
        panel = root.Q<VisualElement>("inventory-panel");
        itemsContainer =root.Q<VisualElement>("items-container");
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
        
        panel.style.display = DisplayStyle.None;
    }

    void OpenMenu()
    {
        if(panel == null) return;
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
        panel.style.display = DisplayStyle.Flex;
        Refresh();
        
    }

    void Refresh()
    {
        if (inventory == null) return;
        itemsContainer.Clear();

        foreach (var item in inventory.Items)
        {
            var itemKey = item.Key;
            var label = new Label($"{item.Key} x{item.Value}");
            
            label.AddToClassList("item");
            itemsContainer.Add(label);
            
            label.RegisterCallback<ClickEvent>(evt =>
            {
                inventory.UseItem(itemKey);
                Refresh();
            }
                
                );
        }
        
    }
}
