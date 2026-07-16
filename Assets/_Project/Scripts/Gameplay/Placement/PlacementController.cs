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
        [SerializeField] private float _rotationStep = 15f;
        [SerializeField] private LayerMask _blockingLayers;
        [SerializeField]private Material _validMaterial;
        [SerializeField]private Material _invalidMaterial;
        [SerializeField] private float _gridSize = 1f;
        [SerializeField] private KeyCode _snapKey = KeyCode.LeftShift;
        
        public static PlacementController  Instance { get; private set; }
        private ItemData _currentItem;
        private GameObject _ghostInstance;
        private bool _isPositionValid;
        private float _currentRotation; 
        private Bounds _ghostBounds;
        private Vector3 _boundsOffset;
        Renderer[] _ghostRenderers;
        public bool IsPlacing => _currentItem != null;

        public void Awake()
        {
            Instance = this;
        }

        void Update()
        {
            
            if(Input.GetMouseButtonDown(1)) Cancel();
            if(!IsPlacing) return;
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            if (scroll != 0f)
            {
                _currentRotation += scroll > 0 ? _rotationStep : -_rotationStep;
                _ghostInstance.transform.rotation = Quaternion.Euler(0f, _currentRotation, 0f);
            }
            Ray ray = _camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if (Physics.Raycast(ray, out RaycastHit hit, _maxDistance, _placementLayers))
            {
               
                _ghostInstance.transform.position =  Input.GetKey(_snapKey) ? SnapToGrid(hit.point) : hit.point ;
                if(!_ghostInstance.activeSelf) _ghostInstance.SetActive(true);
                _isPositionValid = IsAreaClear(_ghostInstance.transform.position);
                ApplyGhostMaterial(_isPositionValid);
            }
            else
            {
                _isPositionValid = false;
                _ghostInstance.SetActive(false);
                ApplyGhostMaterial(false);
            }
            if (Input.GetMouseButtonDown(0) && _isPositionValid)
            {
                Confirm();
            }

           
           
            
        }

        private Vector3 SnapToGrid(Vector3 pos)
        {
            float snappedX = Mathf.Round(pos.x / _gridSize) * _gridSize;
            float snappedZ = Mathf.Round(pos.z / _gridSize)* _gridSize;

            return new Vector3(snappedX, pos.y, snappedZ);
        }

        private void SetLayerRecursively(GameObject obj, int layer)
        {
            obj.layer = layer;
            foreach (Transform child in obj.transform)
            {
                SetLayerRecursively(child.gameObject, layer);
            }
        }
        private void ApplyGhostMaterial(bool isValid)
        {
            foreach (var ghostRenderer in _ghostRenderers)
            {
                ghostRenderer.material = isValid ? _validMaterial : _invalidMaterial;
            }

        }
        public void Confirm()
        {
            if(!IsPlacing || !_isPositionValid) return;
            Vector3 spawnPosition = _ghostInstance.transform.position;
            ItemData placedItem = _currentItem;
            Destroy(_ghostInstance);
            _ghostInstance = null;
            Instantiate(placedItem.placementPrefab, spawnPosition, Quaternion.Euler(0f, _currentRotation, 0f));
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
            _currentRotation = 0f;
            _currentItem = item;
           
            _ghostInstance = Instantiate(item.placementPrefab);
            SetLayerRecursively(_ghostInstance, LayerMask.NameToLayer("Ghost"));
            var coliders = _ghostInstance.GetComponentsInChildren<Collider>();
           
            if (coliders.Length > 0)
            {
                _ghostBounds = coliders[0].bounds;
                for (int i = 1; i < coliders.Length; i++)
                {
                    _ghostBounds.Encapsulate(coliders[i].bounds);
                }
                _boundsOffset = _ghostBounds.center - _ghostInstance.transform.position;
            }
            _ghostRenderers = _ghostInstance.GetComponentsInChildren<Renderer>();
        }

         private bool IsAreaClear(Vector3 atPosition)
        {
            Vector3 halGhostBoundsExtents = _ghostBounds.extents * 0.95f;
            Vector3 position = atPosition + _boundsOffset ;
            Quaternion rotation = Quaternion.Euler(0, _currentRotation, 0);
            Collider[] colliders = Physics.OverlapBox(position, halGhostBoundsExtents, rotation,_blockingLayers);
            
            return colliders.Length == 0;
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