using System;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Interaction.Behaviors
{
    [Serializable]
    public class PickUpBehavior : IExtractionBehavior
    {
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
            UnityEngine.Object.Destroy(host.gameObject);
        }
    }
}