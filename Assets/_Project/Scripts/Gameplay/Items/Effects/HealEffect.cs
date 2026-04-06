using UnityEngine;

namespace _Project.Scripts.Gameplay.Items.Effects
{
    [CreateAssetMenu(fileName = "HealEffect", menuName = "Effects/Heal") ]
    public class HealEffect : ItemEffect
    {
        [SerializeField] private float value;
        
        public override void Apply(PlayerSurvival survival)
        {
            survival.Heal(value);
        }
    }
}