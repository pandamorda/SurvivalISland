using System;
using UnityEngine;

public class Stat
{
    private float current;
    private float max;

    public float Current => current;
    public float Max => max;

    
    public bool IsEmpty => current <= 0f;
    public bool IsFull => current >= max;
    
    
    public Stat(float maxValue)
    {
        max = Mathf.Max(0f, maxValue);
        current = max;
    }

    public Stat(float maxValue, float startValue)
    {
        max = Mathf.Max(0f, maxValue);
        current = startValue;
    }

    public void Increase(float value)
    {
        current = Mathf.Clamp(current + value, 0f, max);
    }

    public void Decrease(float value)
    {
        current = Mathf.Clamp(current - value, 0f, max);
        
    }

    public void Set(float value)
    {
        current = Mathf.Clamp(value, 0f, max);
    }

    public float Normalized()
    {
        return max<=0f ? 0f : current / max;
    }
}
