using System;
using UnityEngine;

public class TimeSystem : MonoBehaviour
{
    [SerializeField] private Light sun;
    [SerializeField] private AnimationCurve lightIntensityCurve;
    
    [SerializeField] private float dayDuration;
    [SerializeField] private float minTemperature;
    [SerializeField] private float maxTemperature;
    private float CurrentTemperature { get; set; }
    
    private int dayCount = 0;
    private float time = 0f;
    
    public int DayCount => dayCount;
    public float TimeNormalized => time;

    private void Update()
    {
        time += Time.deltaTime / dayDuration;
        sun.transform.rotation = Quaternion.Euler(time * 360f - 90f, 170f, 0f);
        sun.intensity = lightIntensityCurve.Evaluate(time);
        
        if (time >= 1)
        {
            time -= 1;
            dayCount++;
        }
    }
}
