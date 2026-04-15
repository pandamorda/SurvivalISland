using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

namespace _Project.Scripts.Gameplay.Survival
{
    public class TimeSystem : MonoBehaviour
    {
        [Header("Lights")]
        [SerializeField] private Light sun;
        [SerializeField] private Light moon;

        private HDAdditionalLightData _sunHd;
        private HDAdditionalLightData _moonHd;

        [Header("Volume")]
        [SerializeField] private Volume globalVolume;

        private HDRISky _sky;
        private Exposure _exposure;

        [Header("Sky")]
        [SerializeField] private Cubemap daySky;
        [SerializeField] private Cubemap nightSky;

        [Header("Curves")]
        [SerializeField] private AnimationCurve luxCurve;
        [SerializeField] private AnimationCurve colorTemperatureCurve;
        [SerializeField] private AnimationCurve temperatureCurve;

        [Header("Time")]
        [SerializeField] private float dayDuration = 120f;

        private float _time = 0f;
        private int _dayCount = 0;

        public float TimeNormalized => _time;
        public int DayCount => _dayCount;

        private void Awake()
        {
            _sunHd = sun.GetComponent<HDAdditionalLightData>();
            _moonHd = moon.GetComponent<HDAdditionalLightData>();
        
            if (globalVolume.profile.TryGet(out _sky))
            {
                Debug.Log("HDRI Sky found");
            }

            if (globalVolume.profile.TryGet(out _exposure))
            {
                Debug.Log("Exposure found");
            }
        }

        private void Update()
        {
            _time += Time.deltaTime / dayDuration;

            UpdateSun();
            UpdateMoon();
            UpdateSky();
            UpdateExposure();

            if (_time >= 1f)
            {
                _time -= 1f;
                _dayCount++;
            }
        }

   
        private void UpdateSun()
        {
            sun.transform.rotation = Quaternion.Euler(_time * 360f - 90f, 170f, 0f);

            float intensity = luxCurve.Evaluate(_time);
            _sunHd.SetIntensity(intensity, LightUnit.Lux);

            _sunHd.SetColor(Color.white, colorTemperatureCurve.Evaluate(_time));
        }

   
        private void UpdateMoon()
        {
            moon.transform.rotation = Quaternion.Euler(_time * 360f + 90f, 170f, 0f);

            float sunValue = luxCurve.Evaluate(_time) / 100000f;
            float moonIntensity = 1f - sunValue;

            _moonHd.SetIntensity(Mathf.Clamp(moonIntensity * 500f, 0f, 500f), LightUnit.Lux);
        }

    
        private void UpdateSky()
        {
            if (_sky == null) return;

            bool isNight = _time < 0.25f || _time > 0.75f;
            _sky.hdriSky.value = isNight ? nightSky : daySky;
            float t = luxCurve.Evaluate(_time) / 100000f;
            float dayExposure = Mathf.Lerp(6f, 12f, t);
            float nightExposure = Mathf.Lerp(6f, 10f, 1f - t);

            _sky.exposure.value = isNight ? nightExposure : dayExposure;

        
            float nightGlow = Mathf.Lerp(1f, 5f, 1f - t); 
            float dayGlow = Mathf.Lerp(1f, 2f, t);

            _sky.multiplier.value = isNight ? nightGlow : dayGlow;
        }

    
        private void UpdateExposure()
        {
            if (_exposure == null) return;

            float t = luxCurve.Evaluate(_time) / 100000f;

            _exposure.mode.value = ExposureMode.Fixed;
            _exposure.fixedExposure.value = Mathf.Lerp(8f, 13f, t);
        }
    }
}