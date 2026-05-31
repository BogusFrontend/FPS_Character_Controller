using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [Header("Movement")] 
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float sensitivity = 2f;
    [SerializeField] private float maxPitch = 90f;

    private float _pitch;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;
        
        transform.Rotate(Vector3.up * mouseX);
        
        _pitch -= mouseY;
        _pitch = Mathf.Clamp(_pitch, -maxPitch, maxPitch);
        
        cameraTransform.localRotation = Quaternion.Euler(_pitch, 0f, 0f);
    }
}