using System;
using UnityEngine;

public class PlayerDeathHandler : MonoBehaviour
{
    [SerializeField] private PlayerSurvival playerSurvival;
    [SerializeField] private PlayerMovement playerMovement;

    private void OnEnable()
    {
        if (playerSurvival != null)
            playerSurvival.OnDeath += OnPlayerDeath;
    }

    private void OnDisable()
    {
        if (playerSurvival != null)
            playerSurvival.OnDeath -= OnPlayerDeath;
    }

    private void OnPlayerDeath()
    {
        if (playerMovement != null)
        {
            playerMovement.enabled = false;
            Debug.Log("Game Over");
        }
            
        
    }
}
