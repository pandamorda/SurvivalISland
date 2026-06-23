using _Project.Scripts.Gameplay.Items;
using _Project.Scripts.Gameplay.Player;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Placement
{
    public class PlacementController : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private LayerMask _placementLayers;
        [SerializeField] private float _maxDistance = 10f;
        public static PlacementController  Instance { get; private set; }
        private ItemData _currentItem;
        private GameObject _ghostInstance;
        private bool _isPositionValid;
         
        public bool IsPlacing => _currentItem != null;

        public void Awake()
        {
            Instance = this;
        }

        void Update()
        {
            
            if(Input.GetMouseButtonDown(1)) Cancel();
            if(!IsPlacing) return;
           
            Ray ray = _camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if (Physics.Raycast(ray, out RaycastHit hit, _maxDistance, _placementLayers))
            {
               
                _ghostInstance.transform.position = hit.point;
                if(!_ghostInstance.activeSelf) _ghostInstance.SetActive(true);
                _isPositionValid = true;
            }
            else
            {
                _isPositionValid = false;
                _ghostInstance.SetActive(false);
            }
            if (Input.GetMouseButtonDown(0) && _isPositionValid)
            {
                Confirm();
            }
            
        }

        public void Confirm()
        {
            if(!IsPlacing || !_isPositionValid) return;
            Vector3 spawnPosition = _ghostInstance.transform.position;
            ItemData placedItem = _currentItem;
            Destroy(_ghostInstance);
            _ghostInstance = null;
            Instantiate(placedItem.placementPrefab, spawnPosition, Quaternion.identity);
            if (PlayerInventory.Instance != null)
                PlayerInventory.Instance.RemoveItem(placedItem, 1);
            _currentItem = null;
            _isPositionValid = false;
        }
        public void BeginPlacement(ItemData item)
        {
            if(item == null || item.placementPrefab == null) return;
            if (IsPlacing)
            {
                Cancel();
            }

            _currentItem = item;
            _ghostInstance = Instantiate(item.placementPrefab);
        }

        public void Cancel()
        {
            if (_ghostInstance != null)
            {
                Destroy(_ghostInstance);
                _ghostInstance = null;
            }

            _currentItem = null;
        }
    }
}