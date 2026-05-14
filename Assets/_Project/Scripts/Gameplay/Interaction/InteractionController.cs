using _Project.Scripts.Gameplay.Player;
using _Project.Scripts.Gameplay.Player.Movement;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Interaction.Player
{
    public class InteractionController : MonoBehaviour
    {
        [SerializeField] private MonoBehaviour detectorComponent;
        private ITargetDetector _detector;
        private IInputService _input;
        private IInteractable _current;


        void Start()
        {
            _detector = detectorComponent as ITargetDetector;
            _input = GetComponent<PlayerMovement>().input;
        }

        void Update()
        {
            IInteractable next = _detector.FindCurrentTarget();
            if (next != _current)
            {

                if (_current != null)
                {
                    _current.Unfocus();
                }

                if (next != null)
                {
                    next.Focus();
                }

                _current = next;

            }

            HandleKey();
        }

        void HandleKey()
        {
            if (_current == null) return;

            InteractKey key = _current.Key;

            if (_input.IsPressed(key)) _current.StartInteract();
            if (_input.IsReleased(key)) _current.StopInteract();

            _current.Tick(Time.deltaTime);
        }
    }
}