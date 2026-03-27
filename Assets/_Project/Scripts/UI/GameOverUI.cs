using System;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(UIDocument))]
public class GameOverUI : MonoBehaviour
{
    [SerializeField] private PlayerSurvival playerSurvival;
    private UIDocument document;
    private VisualElement panel;
    private Button restartButton;

    private void Awake()
    {
        
        document = GetComponent<UIDocument>();
    }

    void OnEnable()
    {
        var root = document.rootVisualElement;

        panel = root.Q<VisualElement>("game-over-panel");
        panel.pickingMode = PickingMode.Position;

        restartButton = panel.Q<Button>("restart-button");
        
        restartButton.style.width = 200;
        restartButton.style.height = 60;
        
        panel.style.display = DisplayStyle.None;
        
        restartButton.clicked += RestartGame;
        
        if (playerSurvival != null)
            playerSurvival.OnDeath += Show;
       
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
    private void OnDisable()
    {
        if (restartButton != null)
            restartButton.clicked -= RestartGame;

        if (playerSurvival != null)
            playerSurvival.OnDeath -= Show;
    }

    void Show()
    {
        panel.style.display = DisplayStyle.Flex;
    }
}





