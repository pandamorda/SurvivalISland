using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class TimeSystem : MonoBehaviour
{ 
    [SerializeField] private Light sun;
    private HDAdditionalLightData sunHD;
    [SerializeField] private Volume globalVolume;
    [SerializeField] private AnimationCurve luxCurve;
    [SerializeField] private AnimationCurve colorTemperatureCurve;
    [SerializeField] private AnimationCurve temperatureCurve;
    [SerializeField] private Light moon;
    private HDAdditionalLightData moonHD;
    
    [SerializeField] private float dayDuration;
    [SerializeField] private float minTemperature;
    [SerializeField] private float maxTemperature;
    private float CurrentTemperature { get; set; }
    
    private int dayCount = 0;
    private float time = 0f;
    
    public int DayCount => dayCount;
    public float TimeNormalized => time;

    private void Awake()
    {
        sunHD = sun.GetComponent<HDAdditionalLightData>();
        moonHD = moon.GetComponent<HDAdditionalLightData>();
    }

    private void Update()
    {
        time += Time.deltaTime / dayDuration;
        
        UpdateSunRotation();
        UpdateSunLight();
        UpdateTemperature();
        UpdateVolume();
        UpdateMoonLight();
        
        
        if (time >= 1)
        {
            time -= 1;
            dayCount++;
        }
    }
    private void UpdateMoonLight()
    {
        float moonIntensity = 1f - luxCurve.Evaluate(time) / 100000f;
        moonHD.SetIntensity(Mathf.Clamp(moonIntensity * 500f, 0f, 500f), LightUnit.Lux);
        moon.transform.rotation = Quaternion.Euler(time * 360f + 90f, 170f, 0f);
    }
    void UpdateSunRotation()
    {
        sun.transform.rotation = Quaternion.Euler(time * 360f - 90f, 170f, 0f);
    }

    void UpdateSunLight()
    {
        sunHD.SetIntensity(luxCurve.Evaluate(time), LightUnit.Lux);
        sunHD.SetColor(Color.white, colorTemperatureCurve.Evaluate(time));
    }

    void UpdateVolume()
    {
        float t = luxCurve.Evaluate(time) / 100000f;

        if (globalVolume.profile.TryGet<Exposure>(out var exposure))
        {
            exposure.mode.value = ExposureMode.Fixed;
            exposure.fixedExposure.value = Mathf.Lerp(8f, 13f, t); 
        }
        if (globalVolume.profile.TryGet<HDRISky>(out var sky))
        {
            sky.exposure.value = Mathf.Lerp(2f, 12f, t); 
        }
    }

    void UpdateTemperature()
    {
        CurrentTemperature = Mathf.Lerp(minTemperature, maxTemperature, temperatureCurve.Evaluate(time));
    }
}
