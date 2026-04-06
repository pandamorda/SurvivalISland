using UnityEngine;

namespace _Project.Scripts.Gameplay.Items.Effects
{
    [CreateAssetMenu(fileName = "StaminaEffect", menuName = "Effects/Stamina")]
    public class StaminaEffect : ItemEffect
    {
        [SerializeField] private float value;

        public override void Apply(PlayerSurvival survival)
        {
            survival.RecoverStamina(value);
        }
    }
    
}

