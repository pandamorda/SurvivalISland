using System;
using UnityEngine;

public class CameraShakeHandler : MonoBehaviour
{
    [SerializeField] private PlayerSurvival playerSurvival;
    [SerializeField] private CameraShake cameraShake;
    private void OnEnable()
    {
        playerSurvival.OnDamage += cameraShake.PlayShake;
    }

    private void OnDisable()
    {
        playerSurvival.OnDamage -= cameraShake.PlayShake;
    }
}
