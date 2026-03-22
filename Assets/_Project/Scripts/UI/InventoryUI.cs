using System;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

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

        panel.style.display = DisplayStyle.None;
    }

    void OpenMenu()
    {
        if(panel == null) return;

        panel.style.display = DisplayStyle.Flex;
        Refresh();
        
    }

    void Refresh()
    {
        itemsContainer.Clear();

        foreach (var item in inventory.Items)
        {
            var label = new Label($"{item.Key} x{item.Value}");
            label.AddToClassList("item");
            itemsContainer.Add(label);
        }
        
    }
}
