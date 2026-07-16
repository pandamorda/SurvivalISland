using System;
using UnityEngine;
using _Project.Scripts.Gameplay.Items;
using _Project.Scripts.Gameplay.Player;

namespace _Project.Scripts.Gameplay.Interaction.Behaviors
{
    [Serializable]
    public class ChestOpenBehavior : IExtractionBehavior
    {
        [SerializeField] private ItemData reward;
        private bool _opened;
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

        public void Complete(InteractableBase host)
        {
            if(_opened) return;
            _opened = true;
            if(PlayerInventory.Instance != null)
                PlayerInventory.Instance.AddItem(reward);
        }
    }
}