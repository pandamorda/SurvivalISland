using System;
using UnityEngine;

public class Stat
{
    private float _current;
    private float _max;

    public float Current => _current;
    public float Max => _max;

    
    public bool IsEmpty => _current <= 0f;
    public bool IsFull => _current >= _max;
    
    
    public Stat(float maxValue)
    {
        _max = Mathf.Max(0f, maxValue);
        _current = _max;
    }

    public Stat(float maxValue, float startValue)
    {
        _max = Mathf.Max(0f, maxValue);
        _current = startValue;
    }

    public void Increase(float value)
    {
        _current = Mathf.Clamp(_current + value, 0f, _max);
    }

    public void Decrease(float value)
    {
        _current = Mathf.Clamp(_current - value, 0f, _max);
        
    }

    public void Set(float value)
    {
        _current = Mathf.Clamp(value, 0f, _max);
    }

    public float Normalized()
    {
        return _max<=0f ? 0f : _current / _max;
    }
}
