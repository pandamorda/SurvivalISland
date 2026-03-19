#if UNITY_EDITOR

using System;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    
    public PlayerSurvival ps;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            ps.TakeDamage(10);
            
        }
    }
}

#endif
