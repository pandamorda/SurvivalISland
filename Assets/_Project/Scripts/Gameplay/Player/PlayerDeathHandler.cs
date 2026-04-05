using UnityEngine;

namespace _Project.Scripts.Gameplay.Player
{

    public class PlayerDeathHandler : MonoBehaviour
    {
         private PlayerRoot  root;
        
         private void Awake()
         {
             root = GetComponent<PlayerRoot>();
         }
        private void OnEnable()
        {
            if (root != null)
                root.Survival.OnDeath += OnPlayerDeath;
        }

        private void OnDisable()
        {
            if (root != null)
                root.Survival.OnDeath -= OnPlayerDeath;
        }

        private void OnPlayerDeath()
        {
            if (root != null)
            {
                root.Movement.enabled = false;
                root.Look.enabled = false;
                root.Interaction.enabled = false;
            }
                

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            Debug.Log("Game Over");
        }
    }
}