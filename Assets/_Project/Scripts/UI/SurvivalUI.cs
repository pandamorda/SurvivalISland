using System; using UnityEngine; using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class SurvivalUI : MonoBehaviour
{
    [SerializeField] private PlayerSurvival playerSurvival; 
    [SerializeField] private TimeSystem timeSystem;
    
    private UIDocument document; 
    private VisualElement staminaFill; 
    private VisualElement hungerFill;
    private VisualElement healthFill;
    private VisualElement temperatureFill;
    
    private Label dayCount;
    private Label temperature;
    private Label time;
    
    private VisualElement damageOverlay;
    
    private float damageFlash;

    private void Awake()
    {
        document = GetComponent<UIDocument>();
    } 
    private void OnEnable() { 
        var root = document.rootVisualElement; 
        staminaFill = root.Q<VisualElement>("stamina-fill"); 
        hungerFill = root.Q<VisualElement>("hunger-fill"); 
        healthFill = root.Q<VisualElement>("health-fill");
        temperatureFill = root.Q<VisualElement>("temperature-fill");

        dayCount = root.Q<Label>("day-count-label");
        

        damageOverlay = root.Q<VisualElement>("damage-overlay");
        playerSurvival.OnDamage += OnDamageTaken;
    }

    private void OnDisable()
    {
        playerSurvival.OnDamage -= OnDamageTaken;
    }

    private void Update()
    {
        if (playerSurvival == null || staminaFill == null || hungerFill == null || healthFill == null)
        {
            return;
        } 
        float staminaValue = playerSurvival.StaminaNormalized() * 100f; 
        float hungerValue = playerSurvival.HungerNormalized() * 100f;
        float healthValue = playerSurvival.HealthNormalized() * 100f;
        float tempNormalized = playerSurvival.TemperatureNormalized();
        
        temperatureFill.style.backgroundColor = GetTemperatureColor(tempNormalized);
        staminaFill.style.width = Length.Percent(staminaValue); 
        hungerFill.style.width = Length.Percent(hungerValue);
        healthFill.style.width = Length.Percent(healthValue);

        dayCount.text = "Day " + timeSystem.DayCount.ToString();
        
        
        damageFlash -= Time.deltaTime * 2f;
        damageFlash = Mathf.Clamp01(damageFlash);
        
        if (damageOverlay != null)
        {
             damageOverlay.style.opacity = damageFlash * damageFlash;
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
        damageFlash = 1f;
    }
}