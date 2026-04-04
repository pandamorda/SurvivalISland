using UnityEngine;
using System.Collections;

public class PlayerSurvival : MonoBehaviour
{ 
    private Stat health;
    private Stat stamina;
    private Stat hunger;
    private Stat temperature;
    
    
    private bool isDead;

    [SerializeField] private TimeSystem timeSystem;
    [SerializeField] private float damagePerSecond;
    [SerializeField] private float coldDamagePerSecond;
    [SerializeField] private float minComfortTemperature = 15f;
    [SerializeField] private float maxComfortTemperature = 35f;
    public event System.Action OnDeath;
    public event System.Action OnDamage;

    public float StaminaNormalized() => stamina.Normalized();
    public float HungerNormalized() => hunger.Normalized();
    public float HealthNormalized() => health.Normalized();
    public float TemperatureNormalized() => temperature.Normalized();

    private void Awake()
    {
        health = new Stat(100);
        stamina = new Stat(100);
        hunger = new Stat(100);
        temperature = new Stat(50, 20);
        
    }

    public float GetTemperature()
    {
        return temperature.Current;
    }

    public void ModifyTemperature(float delta)
    {
        temperature.Increase(delta);
    }
    public void AddHunger(float amount)
    {
        hunger.Increase(amount * Time.deltaTime);
    }
    public void HandleTemperature()
    {
        float temp = temperature.Current;
        
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

    public void HandleHungry()
    {
         float dt = Time.deltaTime;
         hunger.Decrease(dt);
                                           
         if (hunger.Current <= 0f)
         {
             TakeDamage(damagePerSecond * dt);
         }
    }
    private void Update()
    {
        
        HandleTemperature();
        HandleHungry();

    }
    
    public void TakeDamage(float amount)
    {
        if (isDead || amount <= 0f)
        {
            return;
        }
        health.Decrease(amount);
        OnDamage?.Invoke();
        if (health.Current <= 0f)
        {
            isDead = true;
            OnDeath?.Invoke();
        }
    }

    public bool IsDead() => isDead;
    public bool HasStamina(float amount)
    {
        return stamina.Current >= amount;
    }
    
    public void ConsumeStamina(float amount)
    {
        stamina.Decrease(amount);
    }
    public void RecoverStamina(float amount)
    {
        stamina.Increase(amount);
    }
    
}
