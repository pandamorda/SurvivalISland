using System;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Survival
{
    public class PlayerSurvival : MonoBehaviour
    { 
        private Stat _health;
        private Stat _stamina;
        private Stat _hunger;
        private Stat _temperature;
        private Stat _thirst;
    
    
        private bool _isDead;

        [SerializeField] private TimeSystem timeSystem;
        [SerializeField] private float damagePerSecond;
        [SerializeField] private float hungryPerSecond;
        [SerializeField] private float coldDamagePerSecond;
        [SerializeField] private float minComfortTemperature = 15f;
        [SerializeField] private float maxComfortTemperature = 35f;
        public event Action OnDeath;
        public event Action OnDamage;

        public float StaminaNormalized() => _stamina.Normalized();
        public float HungerNormalized() => _hunger.Normalized();
        public float HealthNormalized() => _health.Normalized();
        public float TemperatureNormalized() => _temperature.Normalized();
        public float ThirstyNormalized() => _thirst.Normalized();

        private void Awake()
        {
            _health = new Stat(100);
            _stamina = new Stat(100);
            _hunger = new Stat(100);
            _thirst = new Stat(100);
            _temperature = new Stat(50, 20);
        
        }

        public float GetTemperature()
        {
            return _temperature.Current;
        }

        public void ModifyTemperature(float delta)
        {
            _temperature.Increase(delta);
        }
        public void AddHunger(float amount)
        {
            _hunger.Increase(amount * Time.deltaTime);
        }

        public void Heal(float amount)
        {
            _health.Increase(amount * Time.deltaTime);
        }
        public void HandleTemperature()
        {
            float temp = _temperature.Current;
        
            if (temp < minComfortTemperature)
            {
                float coldFactor = 1f -  Mathf.InverseLerp(-10f,minComfortTemperature, temp);
                TakeDamage(damagePerSecond * coldFactor * Time.deltaTime);
            }
        
            if (temp > maxComfortTemperature)
            {
                float warmFactor = Mathf.InverseLerp(maxComfortTemperature, 50f, temp);
                TakeDamage(damagePerSecond * warmFactor * Time.deltaTime);
            }
        
        }

        
        public void HandleConsume()
        {
            float dt = Time.deltaTime;
            _hunger.Decrease(dt);
            _thirst.Decrease(dt*2f);
                                           
            if (_hunger.Current <= 0f)
            {
                TakeDamage(hungryPerSecond * dt);
            }

            if (_thirst.Current <= 0f)
            {
                TakeDamage(damagePerSecond * dt);
            }
        }
        public void HealInstant(float amount)
        {
            _health.Increase(amount);
        }

        public void AddHungerInstant(float amount)
        {
            _hunger.Increase(amount);
        }
        private void Update()
        {
        
            HandleTemperature();
            HandleConsume();
            

        }
    
        public void TakeDamage(float amount)
        {
            if (_isDead || amount <= 0f)
            {
                return;
            }
            _health.Decrease(amount);
            OnDamage?.Invoke();
            if (_health.Current <= 0f)
            {
                _isDead = true;
                OnDeath?.Invoke();
            }
        }

        public bool IsDead() => _isDead;
        public bool HasStamina(float amount)
        {
            return _stamina.Current >= amount;
        }
    
        public void ConsumeStamina(float amount)
        {
            _stamina.Decrease(amount);
        }
        public void RecoverStamina(float amount)
        {
            _stamina.Increase(amount);
        }
    
    }
}
