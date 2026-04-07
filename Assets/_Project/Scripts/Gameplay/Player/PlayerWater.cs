using UnityEngine;

namespace _Project.Scripts.Gameplay.Player
{
    public class PlayerWater : MonoBehaviour
    {
       
        private bool inWater;


        private float waterSurfaceY;

        public float WaterSurfaceY => waterSurfaceY;
        
        
        public bool InWater => inWater;

       

        public void EnterWater(float surfaceY)
        {
            inWater = true;
            waterSurfaceY = surfaceY;
            Debug.Log($"{gameObject.name} entered water at Y={surfaceY}");
        }

        public void ExitWater()
        {
            inWater = false;
            Debug.Log($"{gameObject.name} exited water");
        }
    }
}