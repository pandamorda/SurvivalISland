using UnityEngine;
using System.Collections;

public class PlayerSurvival : MonoBehaviour
{ 
    private Stat health;
    private Stat stamina;
    private Stat hunger;
    private bool isDead;

    [SerializeField] private float damagePerSecond;
    
    public event System.Action OnDeath;
    public event System.Action OnDamage;

    public float StaminaNormalized() => stamina.Normalized();
    public float HungerNormalized() => hunger.Normalized();
    public float HealthNormalized() => health.Normalized();

    private void Awake()
    {
        health = new Stat(100);
        stamina = new Stat(100);
        hunger = new Stat(100);
    }
    

    private void Update()
    {
        float dt = Time.deltaTime;
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
