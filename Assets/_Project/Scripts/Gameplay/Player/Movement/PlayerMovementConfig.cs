using System;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Player.Movement
{
    [Serializable]
    public class PlayerMovementConfig 
    {
        [Header("Ground Movement")] 
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float sprintSpeed = 10f;
        [SerializeField] private KeyCode sprintKey = KeyCode.LeftShift;
        
        [Header("Stamina")]
        [SerializeField] private float staminaCostPerSecond = 10f;
        [SerializeField] private float staminaRecoveryPerSecond = 5f;
        
        [Header("Gravity & Jump")] 
        [SerializeField] private float gravity = -20f;
        [SerializeField] private float jumpForce = 7f;
        
        [Header("Swimming")]
        [SerializeField] private float swimSpeed = 4f;
        [SerializeField] private float swimAcceleration = 4f;
        [SerializeField] private float swimBuoyancySmooth = 5f;
        [SerializeField] private float swimFloatDepth = 0.3f;
        [SerializeField] private float diveDamping = 3f;
        [SerializeField] private float diveSpeed = 3f;
        [SerializeField] private float diveAccelerationMultiplier = 10f;


        [SerializeField] private float groundedYVelocity = -2f;
        [SerializeField] private float exitWaterBoost = 2f;
        
        public float MoveSpeed => moveSpeed;
        public float SprintSpeed => sprintSpeed;
        public KeyCode SprintKey => sprintKey;
        
        public float StaminaCostPerSecond => staminaCostPerSecond;
        public float StaminaRecoveryPerSecond => staminaRecoveryPerSecond;
        
        public float Gravity => gravity;
        public float JumpForce => jumpForce;
        
        public float SwimAcceleration => swimAcceleration;
        public float SwimBuoyancySmooth => swimBuoyancySmooth;
        public float SwimSpeed => swimSpeed;
        public float SwimFloatDepth => swimFloatDepth;
        public float DiveSpeed => diveSpeed;
        public float DiveAccelerationMultiplier => diveAccelerationMultiplier;
        public float DiveDamping => diveDamping;
        
        public float GroundedYVelocity => groundedYVelocity;
        public float ExitWaterBoost => exitWaterBoost;
    }
}

