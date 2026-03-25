using UnityEngine;
using System.Collections;

public class PlayerSurvival : MonoBehaviour
{ 
    private Stat health;
    private Stat stamina;
    private Stat hunger;
    private Stat temperature;
    
    
    private bool isDead;

    [SerializeField] private float damagePerSecond;
    [SerializeField] private float coldDamagePerSecond;
    [SerializeField] private float minComfortTemperature = 30f;
    [SerializeField] private float maxComfortTemperature = 70f;
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
        temperature = new Stat(100);
    }
    

    private void Update()
    {
        float dt = Time.deltaTime;
        float temp = temperature.Current;
        
        if (temp < minComfortTemperature)
        {
            float coldFactor = Mathf.InverseLerp(minComfortTemperature, 0f, temp);
            TakeDamage(damagePerSecond * coldFactor * Time.deltaTime);
        }
        
        if (temp > maxComfortTemperature)
        {
            float coldFactor = Mathf.InverseLerp(maxComfortTemperature, 100f, temp);
            TakeDamage(damagePerSecond * coldFactor * Time.deltaTime);
        }
        hunger.Decrease(dt);
        
        if (hunger.Current <= 0f)
        {
            TakeDamage(damagePerSecond * dt);
        }

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
