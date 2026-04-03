using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class TimeSystem : MonoBehaviour
{
    [Header("Lights")]
    [SerializeField] private Light sun;
    [SerializeField] private Light moon;

    private HDAdditionalLightData sunHD;
    private HDAdditionalLightData moonHD;

    [Header("Volume")]
    [SerializeField] private Volume globalVolume;

    private HDRISky sky;
    private Exposure exposure;

    [Header("Sky")]
    [SerializeField] private Cubemap daySky;
    [SerializeField] private Cubemap nightSky;

    [Header("Curves")]
    [SerializeField] private AnimationCurve luxCurve;
    [SerializeField] private AnimationCurve colorTemperatureCurve;
    [SerializeField] private AnimationCurve temperatureCurve;

    [Header("Time")]
    [SerializeField] private float dayDuration = 120f;

    private float time = 0f;
    private int dayCount = 0;

    public float TimeNormalized => time;
    public int DayCount => dayCount;

    private void Awake()
    {
        sunHD = sun.GetComponent<HDAdditionalLightData>();
        moonHD = moon.GetComponent<HDAdditionalLightData>();
        
        if (globalVolume.profile.TryGet(out sky))
        {
            Debug.Log("HDRI Sky found");
        }

        if (globalVolume.profile.TryGet(out exposure))
        {
            Debug.Log("Exposure found");
        }
    }

    private void Update()
    {
        time += Time.deltaTime / dayDuration;

        UpdateSun();
        UpdateMoon();
        UpdateSky();
        UpdateExposure();

        if (time >= 1f)
        {
            time -= 1f;
            dayCount++;
        }
    }

   
    private void UpdateSun()
    {
        sun.transform.rotation = Quaternion.Euler(time * 360f - 90f, 170f, 0f);

        float intensity = luxCurve.Evaluate(time);
        sunHD.SetIntensity(intensity, LightUnit.Lux);

        sunHD.SetColor(Color.white, colorTemperatureCurve.Evaluate(time));
    }

   
    private void UpdateMoon()
    {
        moon.transform.rotation = Quaternion.Euler(time * 360f + 90f, 170f, 0f);

        float sunValue = luxCurve.Evaluate(time) / 100000f;
        float moonIntensity = 1f - sunValue;

        moonHD.SetIntensity(Mathf.Clamp(moonIntensity * 500f, 0f, 500f), LightUnit.Lux);
    }

    
    private void UpdateSky()
    {
        if (sky == null) return;

        bool isNight = time < 0.25f || time > 0.75f;
        sky.hdriSky.value = isNight ? nightSky : daySky;
        float t = luxCurve.Evaluate(time) / 100000f;
        float dayExposure = Mathf.Lerp(6f, 12f, t);
        float nightExposure = Mathf.Lerp(6f, 10f, 1f - t);

        sky.exposure.value = isNight ? nightExposure : dayExposure;

        
        float nightGlow = Mathf.Lerp(1f, 5f, 1f - t); 
        float dayGlow = Mathf.Lerp(1f, 2f, t);

        sky.multiplier.value = isNight ? nightGlow : dayGlow;
    }

    
    private void UpdateExposure()
    {
        if (exposure == null) return;

        float t = luxCurve.Evaluate(time) / 100000f;

        exposure.mode.value = ExposureMode.Fixed;
        exposure.fixedExposure.value = Mathf.Lerp(8f, 13f, t);
    }
}