using UnityEngine;

namespace _Project.Scripts.Gameplay.Items.Effects
{
    
    [CreateAssetMenu(fileName = "HungerEffect", menuName = "Effects/Hunger")]
    public class HungerEffect : ItemEffect
    {
        [SerializeField] private float value;

        public override void Apply(PlayerSurvival survival)
        { 
            survival.AddHunger(value);
        }


    }
}