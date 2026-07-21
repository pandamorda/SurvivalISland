using System;
using _Project.Scripts.Gameplay.Player;
using UnityEngine;
using UnityEngine.Rendering;

namespace _Project.Scripts.VFX
{
    public class UnderwaterEffectController : MonoBehaviour
    {
        [SerializeField] private PlayerRoot _root;
        [SerializeField] private Volume underwaterVolume;
         
        
        void Update()
        {
            bool shouldBeActive = _root.Water.InWater 
                                  && _root.transform.position.y < _root.Water.WaterSurfaceY;

            if (underwaterVolume.enabled != shouldBeActive)
            {
                underwaterVolume.enabled = shouldBeActive;
            }
        }
    }

    
}