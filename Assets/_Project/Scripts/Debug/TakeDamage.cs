#if UNITY_EDITOR

using System;
using _Project.Scripts.Gameplay.Survival;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    
    public PlayerSurvival ps;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            ps.TakeDamage(0.1f);
            
        }
    }
}

#endif
