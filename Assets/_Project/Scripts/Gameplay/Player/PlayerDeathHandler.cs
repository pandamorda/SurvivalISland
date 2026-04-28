using UnityEngine;

namespace _Project.Scripts.Gameplay.Player
{

    public class PlayerDeathHandler : MonoBehaviour
    {
         private PlayerRoot  _root;
        
         private void Awake()
         {
             _root = GetComponent<PlayerRoot>();
         }
        private void OnEnable()
        {
            if (_root != null)
                _root.Survival.OnDeath += OnPlayerDeath;
        }

        private void OnDisable()
        {
            if (_root != null)
                _root.Survival.OnDeath -= OnPlayerDeath;
        }

        private void OnPlayerDeath()
        {
            if (_root != null)
            {
                _root.Movement.enabled = false;
                _root.Look.enabled = false;
                //_root.Interaction.enabled = false;
            }
                

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            Debug.Log("Game Over");
        }
    }
}