using _Project.Scripts.Gameplay.Crafting;
using _Project.Scripts.Gameplay.Items;
using _Project.Scripts.Gameplay.Placement;
using _Project.Scripts.Gameplay.Player;
using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;


public class InventoryUI : MonoBehaviour
{
    [SerializeField] private PlayerRoot root;

    [SerializeField] private UIDocument document;
    [SerializeField] private CraftingPanelController craftingPanel;
    
    public static InventoryUI Instance { get; private set; }
    
    private VisualElement panel;
    private VisualElement itemsContainer;
    private VisualElement overlay;
    
    
    [SerializeField] private KeyCode openInventoryKey = KeyCode.Tab;
    private bool isOpen;
    

    void OnEnable()
    {
        Instance = this;
        var rootUI = document.rootVisualElement;
        
        panel = rootUI.Q<VisualElement>("inventory-panel");
        itemsContainer =rootUI.Q<VisualElement>("items-container");
        overlay = rootUI.Q<VisualElement>("inventory-overlay");
        CloseMenu();
       // root.Look.enabled = true;

    }
    void Start()
    {
        if (root == null) return;
    
        if (root.Survival != null)
            root.Survival.OnDeath += Disable;
    
        if (root.Inventory != null)
            root.Inventory.OnChanged += Refresh;
    }
    private void OnDisable()
    {
        if (root != null)
        {
            root.Survival.OnDeath -= Disable;
            root.Inventory.OnChanged -= Refresh;
            
        }
        
    }

    void Disable()
    {
        //root.Look.enabled = false;
        CloseMenu(); 
        gameObject.SetActive(false);
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(openInventoryKey))
        {
            isOpen = !isOpen;
            if (isOpen)
            {
                OpenMenu(StationKind.None);
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
        
        HidePanels();
    }
    void HidePanels()
    {
        if (panel == null) return;
        overlay.style.display = DisplayStyle.None;
        panel.style.display = DisplayStyle.None;
    }

    public void OpenMenu(StationKind station)
    {
        if(panel == null) return;
        isOpen = true;
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
        overlay.style.display = DisplayStyle.Flex;
        panel.style.display = DisplayStyle.Flex;
        
        Refresh();
        if (craftingPanel != null) craftingPanel.OpenForStation(station);
        
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
            
            slot.RegisterCallback<ClickEvent>(evt => HandleItemClick(itemKey));
        }
        
    }

    void HandleItemClick(ItemData item)
    {
        if (item.placementPrefab != null)
        {
            CloseMenu();
            isOpen = false;
            if(PlacementController.Instance != null)
                PlacementController.Instance.BeginPlacement(item);
            
        }
        else
        {
            root.Inventory.UseItem(item);
        }
    }
}
