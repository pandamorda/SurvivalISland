using System;
using UnityEngine;
using UnityEngine.UIElements;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private PlayerSurvival playerSurvival;
    public UIDocument gameOverUI;

    private void Awake()
    {
        gameOverUI.enabled = false;
    }

    void OnEnable()
    {
        if (playerSurvival != null)
            playerSurvival.OnDeath += GameOver;
       
    }

    private void OnDisable()
    {
        if (playerSurvival != null)
            playerSurvival.OnDeath -= GameOver;
    }

    void GameOver()
    {
        gameOverUI.enabled = true;
    }
}
