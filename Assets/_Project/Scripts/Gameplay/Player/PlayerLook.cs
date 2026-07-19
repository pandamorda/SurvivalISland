using System;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Player
{

    public class PlayerLook : MonoBehaviour
    {
        [SerializeField] private Transform viewPivot;
        [SerializeField, Range(10f, 500f)] private float sensitivity = 100f;


        private float _verticalRotation;
        private PlayerRoot _root;

        void Awake()
        {
            _root = GetComponent<PlayerRoot>();
            GameplayState.OnGameplayEnabledChanged += OnGameplayStateChanged;
        }
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            if (_root?.Survival != null)
                _root.Survival.OnDeath += OnDeath;
        }
        

        private void OnDisable()
        {
            if (_root?.Survival != null)
                _root.Survival.OnDeath -= OnDeath;
            
        }
        private void OnDeath()
        {
            enabled = false;
        }

        private void OnDestroy()
        {
            GameplayState.OnGameplayEnabledChanged -= OnGameplayStateChanged;
        }

        void LateUpdate()
        {
            float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

            transform.Rotate(Vector3.up * mouseX);

            _verticalRotation -= mouseY;
            _verticalRotation = Mathf.Clamp(_verticalRotation, -80, 80);

            viewPivot.localRotation = Quaternion.Euler(_verticalRotation, 0f, 0f);

        }

        private void OnGameplayStateChanged(bool value)
        {
            enabled = value;
        }

    }
}
