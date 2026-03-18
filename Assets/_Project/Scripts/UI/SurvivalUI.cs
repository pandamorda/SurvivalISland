using System; using UnityEngine; using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class SurvivalUI : MonoBehaviour
{
    [SerializeField] private PlayerSurvival playerSurvival; 
    
    private UIDocument document; 
    private VisualElement staminaFill; 
    private VisualElement hungerFill;

    private void Awake()
    {
        document = GetComponent<UIDocument>();
    } 
    private void OnEnable() { 
        var root = document.rootVisualElement; 
        staminaFill = root.Q<VisualElement>("stamina-fill"); 
        hungerFill = root.Q<VisualElement>("hunger-fill"); }

    private void Update()
    {
        if (playerSurvival == null || staminaFill == null || hungerFill == null)
        {
            return;
        } 
        float staminaValue = playerSurvival.StaminaNormalized() * 100f; 
        float hungerValue = playerSurvival.HungerNormalized() * 100f; 
        staminaFill.style.width = Length.Percent(staminaValue); 
        hungerFill.style.width = Length.Percent(hungerValue);
    }
}