using UnityEngine;
using System.Collections;

public class PlayerSurvival : MonoBehaviour
{ 
    private Stat health;
    private Stat stamina;
    private Stat hunger;

    public float StaminaNormalized() => stamina.Normalized();

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
    }

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
