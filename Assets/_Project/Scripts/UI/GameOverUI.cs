using _Project.Scripts.Gameplay.Survival;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using System.Collections;
using Cursor = UnityEngine.Cursor;

namespace _Project.Scripts.UI
{
    [RequireComponent(typeof(UIDocument))]
    public class GameOverUI : MonoBehaviour
    {
        [SerializeField] private PlayerSurvival playerSurvival;
        private UIDocument _document;
        private VisualElement _panel;
        private Button _restartButton;

        private void Awake()
        {
        
            _document = GetComponent<UIDocument>();
        }

        void OnEnable()
        {
            var root = _document.rootVisualElement;

            _panel = root.Q<VisualElement>("game-over-panel");
            _panel.pickingMode = PickingMode.Position;

            _restartButton = _panel.Q<Button>("restart-button");
        
            _restartButton.style.width = 200;
            _restartButton.style.height = 60;
        
            _panel.style.display = DisplayStyle.None;
        
            _restartButton.clicked += RestartGame;
        
            if (playerSurvival != null)
                playerSurvival.OnDeath += Show;
       
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
        }
        private void OnDisable()
        {
            if (_restartButton != null)
                _restartButton.clicked -= RestartGame;

            if (playerSurvival != null)
                playerSurvival.OnDeath -= Show;
        }
        
        void Show()
        {
            _panel.style.display = DisplayStyle.Flex;
            StartCoroutine(UnlockCursor());
        }

        private IEnumerator UnlockCursor()
        {
            yield return null; 
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}





