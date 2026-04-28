using System;
using UnityEngine;
namespace _Project.Scripts.Gameplay.Interaction
{
    public class TestCaller : MonoBehaviour
    {
        [SerializeField] private InteractableBase target;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                target.Focus();
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                target.StartInteract();
            }
            if (Input.GetKeyUp(KeyCode.Alpha3))
            {
                target.StopInteract();
            }
            if (Input.GetKey(KeyCode.Alpha3))
            {
                target.Tick(2);
            }
            if (Input.GetKeyUp(KeyCode.Alpha4))
            {
                target.Unfocus();
            }
        }
    }
}