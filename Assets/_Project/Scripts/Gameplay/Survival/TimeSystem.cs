using System;
using UnityEngine;

public class TimeSystem : MonoBehaviour
{
    [SerializeField] private float dayDuration;
    [SerializeField] private Light sun;
    [SerializeField] private AnimationCurve lightIntensityCurve;
    
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
