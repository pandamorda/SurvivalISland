using System;
using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;


public class InventoryUI : MonoBehaviour
{
    private PlayerRoot root;

    [SerializeField] private UIDocument document;
    private VisualElement panel;
    private VisualElement itemsContainer;
    private VisualElement overlay;
    
    [SerializeField] private KeyCode openInventoryKey = KeyCode.Tab;
    private bool isOpen;

    private void Awake()
    {
        root = GetComponent<PlayerRoot>();
    }

    void OnEnable()
    {
        var rootUI = document.rootVisualElement;
        
        panel = rootUI.Q<VisualElement>("inventory-panel");
        itemsContainer =rootUI.Q<VisualElement>("items-container");
        overlay = rootUI.Q<VisualElement>("inventory-overlay");
        
        CloseMenu();

        if (root != null)
            root.Survival.OnDeath += Disable;
    }

    private void OnDisable()
    {
        if (root != null)
            root.Survival.OnDeath -= Disable;
    }

    void Disable()
    {
        CloseMenu(); 
        enabled = false;
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
        if (root == null) return;
        itemsContainer.Clear();

        foreach (var item in root.Inventory.Items)
        {
            var itemKey = item.Key;
            int itemCount = item.Value;
            var slot = CreateSlot(itemKey, itemCount);
            itemsContainer.Add(slot);
            
            slot.RegisterCallback<ClickEvent>(evt =>
            {
                root.Inventory.UseItem(itemKey);
                Refresh();
            }
                
                );
        }
        
    }
}
