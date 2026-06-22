using _Project.Scripts.Gameplay.Player;

namespace _Project.Scripts.Gameplay.Crafting
{
    public class CraftingService
    {
        private readonly PlayerInventory _inventory;

        public CraftingService(PlayerInventory inventory)
        {
            _inventory = inventory;
        }

        private bool HasEnough(ItemAmount needed)
        {
            if (!_inventory.Items.ContainsKey(needed.item)) return false;
            return _inventory.Items[needed.item] >= needed.count;
        }

        public bool TryCraft(RecipeData recipe)
        {
            if (recipe == null) return false;
            foreach (var input in recipe.inputs)
            {
                if (!HasEnough(input)) return false;
            }
            foreach (var input in recipe.inputs)
            {
                _inventory.RemoveItem(input.item, input.count);
            }

            for (int i = 0; i < recipe.output.count; i++)
            {
                _inventory.AddItem(recipe.output.item);
            }

            return true;
        }

        public bool CanCraft(RecipeData recipe)
        {
            if (recipe == null) return false;
            foreach (var input in recipe.inputs)
            {
                if (!HasEnough(input)) return false;
            }

            return true;
        }
    }
}