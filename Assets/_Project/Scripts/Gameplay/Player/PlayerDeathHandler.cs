using System;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Player
{

    public class PlayerDeathHandler : MonoBehaviour
    {
        [SerializeField] private PlayerSurvival playerSurvival;
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private PlayerLook playerLook;

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
                playerMovement.enabled = false;
            if (playerLook != null)
                playerLook.enabled = false;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            Debug.Log("Game Over");
        }
    }
}