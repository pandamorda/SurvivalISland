using UnityEngine;

namespace _Project.Scripts.Gameplay.Items.Effects
{
    public abstract class ItemEffect : ScriptableObject
    {
      public abstract void Apply(PlayerSurvival survival);
   }

}