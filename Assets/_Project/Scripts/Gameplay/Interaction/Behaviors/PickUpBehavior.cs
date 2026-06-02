using System;
using _Project.Scripts.Gameplay.Items;
using _Project.Scripts.Gameplay.Player;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Interaction.Behaviors
{
    [Serializable]
    public class PickUpBehavior : IExtractionBehavior
    {
        [SerializeField] private ItemData item;
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
            if (PlayerInventory.Instance != null)
            {
                PlayerInventory.Instance.AddItem(item);
            }
            UnityEngine.Object.Destroy(host.gameObject);
        }
    }
}