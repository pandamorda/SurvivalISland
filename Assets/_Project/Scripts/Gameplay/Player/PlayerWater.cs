using UnityEngine;

namespace _Project.Scripts.Gameplay.Player
{
    public class PlayerWater : MonoBehaviour
    {
        private PlayerRoot root;
        private bool inWater;


        private float waterSurfaceY;


        [Header("Wave Sync (must match WaterGraph shader)")] [SerializeField]
        private float waveHeight1 = 0.2f;

        [SerializeField] private float waveFrequency1 = 2f;
        [SerializeField] private float waveSpeed1 = 1f;
        [SerializeField] private float waveHeight2 = 0.1f;
        [SerializeField] private float waveFrequency2 = 1.5f;
        [SerializeField] private float waveSpeed2 = 1f;


        public float WaterSurfaceY
        {
            get
            {
                float x = transform.position.x;
                float z = transform.position.z;
                float wave1 = Mathf.Sin(x * waveFrequency1 + Time.time * waveSpeed1) * waveHeight1;
                float wave2 = Mathf.Cos(z * waveFrequency2 + Time.time * waveSpeed2) * waveHeight2;
                return waterSurfaceY + wave1 + wave2;
            }
        }

       
        public float SubmersionDepth => WaterSurfaceY - transform.position.y;

        
        public bool InWater => inWater;

        void Awake()
        {
            root = GetComponent<PlayerRoot>();
        }

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