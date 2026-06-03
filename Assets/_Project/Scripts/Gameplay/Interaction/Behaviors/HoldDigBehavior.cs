using UnityEngine;
using System;
using _Project.Scripts.Gameplay.Items;
using _Project.Scripts.Gameplay.Player;

namespace _Project.Scripts.Gameplay.Interaction.Behaviors
{

    [Serializable]
    public class HoldDigBehavior : IExtractionBehavior
    {
        [SerializeField] private ItemData reward;
        [SerializeField] private float duration = 2f;
        [SerializeField] private bool resetOnRelease = true;
        private float _elapsed;

        public void Begin(InteractableBase host)
        {

        }
        
        public void OnInputReleased(InteractableBase host)
        {
            if (resetOnRelease) _elapsed = 0f;
            
        }

        public ExtractionTickResult Tick(float deltaTime)
        {
            _elapsed += deltaTime;

            if (_elapsed >= duration)
            {
                return new ExtractionTickResult(ExtractionStatus.Completed, 1f);
            }

            return new ExtractionTickResult(ExtractionStatus.InProgress, _elapsed / duration);
        }

        public void Complete(InteractableBase host)
        {
            if (PlayerInventory.Instance != null)
                PlayerInventory.Instance.AddItem(reward);
            _elapsed = 0f;
            UnityEngine.Object.Destroy(host.gameObject);
        }
    }
}