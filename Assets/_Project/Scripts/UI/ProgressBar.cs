using UnityEngine;
using UnityEngine.UI;
namespace _Project.Scripts.Gameplay.Interaction.UI
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] private Image fillImage;
    
        public void SetProgress(float value)
        {
            fillImage.fillAmount = value;
            Debug.Log(fillImage.fillAmount);
            
        }
        public void Show()
        {
            gameObject.SetActive(true);
        }
    
        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}