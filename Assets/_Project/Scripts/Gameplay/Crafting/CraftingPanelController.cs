using System.Collections.Generic;
using _Project.Scripts.Gameplay.Player;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Project.Scripts.Gameplay.Crafting
{
    public class CraftingPanelController : MonoBehaviour
    {
        [SerializeField]private PlayerRoot _root;
        [SerializeField]private UIDocument _document;
        [SerializeField]private RecipeData[] _recipes;

        private RecipeData selectedRecipeData;
        private CraftingService _service;

        private VisualElement _recipesScroll;
        private VisualElement _craftGrid;
        private VisualElement _craftResultSlot;
        private Label _craftResultName;
        private Button _craftButton;
        
        private void OnEnable()
        {
            var rootUI = _document.rootVisualElement;
            _recipesScroll = rootUI.Q<VisualElement>("recipes-scroll");
            _craftGrid = rootUI.Q<VisualElement>("craft-grid");
            _craftResultSlot = rootUI.Q<VisualElement>("craft-result-slot");
            _craftResultName = rootUI.Q<Label>("craft-result-name");
            _craftButton = rootUI.Q<Button>("craft-button");
            _craftButton.clicked += OnCraftButtonClicked;
        }

        private void Start()
        {
            _service = new CraftingService(_root.Inventory);
            _root.Inventory.OnChanged += Refresh;
            BuildRecipeList();
            Refresh();
        }

        void OnDisable()
        {
            if (_root != null && _root.Inventory != null)
                _root.Inventory.OnChanged -= Refresh;
            if (_craftButton != null)
                _craftButton.clicked -= OnCraftButtonClicked;
        }
        void BuildRecipeList()
        {
            _recipesScroll.Clear();
            foreach (var recipe in _recipes)
            {
                if (recipe == null) continue;
                var card = CreateRecipeCard(recipe);
                _recipesScroll.Add(card);
            }
        }

        private void OnCraftButtonClicked()
        {
            if(selectedRecipeData == null) return;

            _service.TryCraft(selectedRecipeData);
        }
        void Refresh()
        {
            if (selectedRecipeData == null)
            {
                ClearCraftSlots();
                _craftResultSlot.style.backgroundImage = null;
                _craftResultName.text = "Select recipe";
                _craftButton.SetEnabled(false);
                return;
            }
            FillIngredientSlots(selectedRecipeData);
            var output = selectedRecipeData.output.item;
            _craftResultSlot.style.backgroundImage = output != null ? new StyleBackground(output.icon) : null;
            _craftResultName.text = output != null ? output.itemName : "?";
            _craftButton.SetEnabled(_service.CanCraft(selectedRecipeData));
        }
        
        private void FillIngredientSlots(RecipeData recipe)
        {
            for (int i = 0; i < 4; i++)
            {
                var slot = _craftGrid.Q<VisualElement>($"craft-slot-{i}");
                if (slot == null) continue;
        
                slot.Clear();
        
                if (i < recipe.inputs.Length)
                {
                    var input = recipe.inputs[i];
                    slot.style.backgroundImage = input.item != null ? new StyleBackground(input.item.icon) : null;
            
                    var countLabel = new Label($"x{input.count}");
                    countLabel.AddToClassList("item-count"); 
                    slot.Add(countLabel);
                }
                else
                {
                    slot.style.backgroundImage = null;
                }
            }
        }
        private void ClearCraftSlots()
        {
            for (int i = 0; i < 4; i++)
            {
                var slot = _craftGrid.Q<VisualElement>($"craft-slot-{i}");
                if (slot == null) continue;
                slot.style.backgroundImage = null;
                slot.Clear(); 
            }
        }

        private VisualElement CreateRecipeCard(RecipeData data)
        {
            var card = new VisualElement();
            card.AddToClassList("recipe-card");
            var title = new Label(data.output.item != null ? data.output.item.itemName : "?");
            title.AddToClassList("recipe-title");
            card.Add(title);
            List<string> components = new List<string>();
            foreach (var input in data.inputs)
            {
                components.Add($"{input.item.itemName} x{input.count}");
            }

            var description = new Label(string.Join(", ", components));
            
            description.AddToClassList("recipe-description");
            card.Add(description);
            card.RegisterCallback<ClickEvent>(evt => SelectRecipe(data));
    
            return card;
        }
        private void SelectRecipe(RecipeData recipe)
        {
            selectedRecipeData = recipe;
            Refresh();
        }
    }
}