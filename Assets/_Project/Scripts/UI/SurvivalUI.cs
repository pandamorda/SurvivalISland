using _Project.Scripts.Gameplay.Survival;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Project.Scripts.UI
{
    [RequireComponent(typeof(UIDocument))]
    public class SurvivalUI : MonoBehaviour
    {
        [SerializeField] private PlayerSurvival playerSurvival; 
        [SerializeField] private TimeSystem timeSystem;
    
        private UIDocument _document; 
        private VisualElement _staminaFill; 
        private VisualElement _hungerFill;
        private VisualElement _thirstyFill;
        private VisualElement _healthFill;
        private VisualElement _temperatureFill;
    
        private Label _dayCount;
        private Label _temperature;
        private Label _time;
    
        private VisualElement _damageOverlay;
    
        private float _damageFlash;

        private void Awake()
        {
            _document = GetComponent<UIDocument>();
        } 
        private void OnEnable() { 
            var root = _document.rootVisualElement; 
            _staminaFill = root.Q<VisualElement>("stamina-fill"); 
            _hungerFill = root.Q<VisualElement>("hunger-fill"); 
            _healthFill = root.Q<VisualElement>("health-fill");
            _temperatureFill = root.Q<VisualElement>("temperature-fill");
            _thirstyFill = root.Q<VisualElement>("thirsty-fill");

            _dayCount = root.Q<Label>("day-count-label");
            _time = root.Q<Label>("time-label");

            _damageOverlay = root.Q<VisualElement>("damage-overlay");
            playerSurvival.OnDamage += OnDamageTaken;
        }

        private void OnDisable()
        {
            playerSurvival.OnDamage -= OnDamageTaken;
        }

        private void Update()
        {
            if (playerSurvival == null || _staminaFill == null || _hungerFill == null || _healthFill == null)
            {
                return;
            } 
            float staminaValue = playerSurvival.StaminaNormalized() * 100f; 
            float hungerValue = playerSurvival.HungerNormalized() * 100f;
            float healthValue = playerSurvival.HealthNormalized() * 100f;
            float tempNormalized = playerSurvival.TemperatureNormalized();
            float thirstyValue = playerSurvival.ThirstyNormalized() * 100f;
        
            _temperatureFill.style.backgroundColor = GetTemperatureColor(tempNormalized);
            _staminaFill.style.width = Length.Percent(staminaValue); 
            _hungerFill.style.width = Length.Percent(hungerValue);
            _healthFill.style.width = Length.Percent(healthValue);
            _thirstyFill.style.width = Length.Percent(thirstyValue);

            _dayCount.text = "Day " + timeSystem.DayCount.ToString();
            _time.text = $"{timeSystem.Hours:00}:{timeSystem.Minutes:00}";
        
            _damageFlash -= Time.deltaTime * 2f;
            _damageFlash = Mathf.Clamp01(_damageFlash);
        
            if (_damageOverlay != null)
            {
                _damageOverlay.style.opacity = _damageFlash * _damageFlash;
            }
       
        }
        Color GetTemperatureColor(float normalized)
        {
            if (normalized < 0.5f)
            {
                return Color.Lerp(Color.blue, Color.green, normalized * 2f);
            }
            else
            {
                return Color.Lerp(Color.green, Color.red, (normalized - 0.5f) * 2f);
            }
        }
        private void OnDamageTaken()
        {
            _damageFlash = 1f;
        }
    }
}