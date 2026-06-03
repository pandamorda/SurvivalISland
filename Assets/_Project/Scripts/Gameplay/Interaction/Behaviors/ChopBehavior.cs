using System;
using _Project.Scripts.Gameplay.Items;
using _Project.Scripts.Gameplay.Player;
using UnityEngine;


namespace _Project.Scripts.Gameplay.Interaction.Behaviors
{
    [Serializable]
    public class ChopBehavior : IExtractionBehavior
    {
        [SerializeField] private ItemData reward;
        private int _currentHits;
        [SerializeField] private int maxHits = 5;
        public void OnInputReleased(InteractableBase host)
        {
            
        }

        public void Begin(InteractableBase host)
        {
            _currentHits++;
        }

        public ExtractionTickResult Tick(float deltaTime)
        {
            if (_currentHits >= maxHits)
            {
                return new ExtractionTickResult(ExtractionStatus.Completed, 1);
            }
            else
            {
                return new ExtractionTickResult(ExtractionStatus.InProgress, (float)_currentHits / maxHits);
            }
        }

        public void Complete(InteractableBase host)
        {
            if (PlayerInventory.Instance != null)
                PlayerInventory.Instance.AddItem(reward);
            UnityEngine.Object.Destroy(host.gameObject);
        }
    }
}