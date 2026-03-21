using System; using UnityEngine; using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class SurvivalUI : MonoBehaviour
{
    [SerializeField] private PlayerSurvival playerSurvival; 
    
    private UIDocument document; 
    private VisualElement staminaFill; 
    private VisualElement hungerFill;
    private VisualElement healthFill;

    private void Awake()
    {
        document = GetComponent<UIDocument>();
    } 
    private void OnEnable() { 
        var root = document.rootVisualElement; 
        staminaFill = root.Q<VisualElement>("stamina-fill"); 
        hungerFill = root.Q<VisualElement>("hunger-fill"); 
        healthFill = root.Q<VisualElement>("health-fill"); 
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
        
        staminaFill.style.width = Length.Percent(staminaValue); 
        hungerFill.style.width = Length.Percent(hungerValue);
        healthFill.style.width = Length.Percent(healthValue);
    }
}