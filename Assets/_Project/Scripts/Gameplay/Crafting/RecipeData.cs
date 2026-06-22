using UnityEngine;

namespace _Project.Scripts.Gameplay.Crafting
{
    [CreateAssetMenu(menuName = "Crafting/Recipe")]
    public class RecipeData : ScriptableObject
    {
        public ItemAmount[] inputs;
        public ItemAmount output;
    }
}