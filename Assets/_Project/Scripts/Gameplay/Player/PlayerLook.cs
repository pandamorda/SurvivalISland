using System;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField]private Transform viewPivot;
    [SerializeField, Range(10f, 500f)] private float sensitivity = 100f;
    private PlayerRoot root;
   
    private float verticalRotation;

    private void Awake()
    {
        root = GetComponent<PlayerRoot>();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void LateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        
        transform.Rotate(Vector3.up * mouseX);
        
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -80, 80);
        
        viewPivot.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        
    }
    void OnEnable()
    {
        if (root != null)
            root.Survival.OnDeath += Disable;
    }

    void OnDisable()
    {
        if (root != null)
            root.Survival.OnDeath -= Disable;
    }

    void Disable()
    {
        enabled = false;
    }
}
