using UnityEngine;

namespace _Project.Scripts.Gameplay.Items.Effects
{
    
[CreateAssetMenu(fileName = "TemperatureEffect", menuName = "Effects/Temperature")]
    public class TemperatureEffect : ItemEffect
    {
        [SerializeField] private float value;

        public override void Apply(PlayerSurvival survival)
        {
            survival.ModifyTemperature(value);
        }

    }
}