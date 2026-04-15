using UnityEngine;

namespace _Project.Scripts.Gameplay.Player
{
    public class PlayerWater : MonoBehaviour
    {
       
        private bool _inWater;


        private float _waterSurfaceY;

        public float WaterSurfaceY => _waterSurfaceY;
        
        
        public bool InWater => _inWater;

       

        public void EnterWater(float surfaceY)
        {
            _inWater = true;
            _waterSurfaceY = surfaceY;
            Debug.Log($"{gameObject.name} entered water at Y={surfaceY}");
        }

        public void ExitWater()
        {
            _inWater = false;
            Debug.Log($"{gameObject.name} exited water");
        }
    }
}