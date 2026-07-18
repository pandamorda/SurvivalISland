using _Project.Scripts.Gameplay.Crafting;
using UnityEngine;


namespace _Project.Scripts.Gameplay.Interaction.Behaviors
{
    [System.Serializable]
    public class OpenCraftingBehavior : IExtractionBehavior
    {
        [SerializeField] private StationKind stationKind;
        
        public void Begin(InteractableBase host)
        {
            
        }

        public void OnInputReleased(InteractableBase host)
        {

        }

        public ExtractionTickResult Tick(float deltaTime)
        {
            return new ExtractionTickResult(ExtractionStatus.Completed, 1f);
        }

        public void Complete(InteractableBase host){

            if (InventoryUI.Instance != null)
                InventoryUI.Instance.OpenMenu(stationKind);
           
            
            
        }
    }
} 