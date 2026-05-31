using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    [Header("Скорости")] 
    [SerializeField] private float walkSpeed = 4f;
    [SerializeField] private float sprintSpeed = 7f;
    [SerializeField] private float crouchSpeed = 2f;

    [Header("Прыжок и гравитация")] 
    [SerializeField] private float jumpHeight = 1.2f;
    [SerializeField] private float gravity = -20f;

    [Header("Присед")] 
    [SerializeField] private float standHeight = 2f;
    [SerializeField] private float crouchHeight = 1f;

    [Header("FOV при беге")] 
    [SerializeField] private Camera cam;
    [SerializeField] private float normalFov = 60f;
    [SerializeField] private float sprintFov = 70f;
    [SerializeField] private float fovSpeed = 8f;
    
    private CharacterController _controller;
    private Vector3 _velocity;
    private bool _isCrouching;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        HandleCrouch();
        HandleMovement();
        
        float _h = Input.GetAxis("Horizontal");
        float _v = Input.GetAxis("Vertical");


        bool moving = new Vector2(_h, _v).sqrMagnitude > 0.01f;
        bool isSprinting = Input.GetKey(KeyCode.LeftShift) && moving && !_isCrouching;
        
        HandleFov(isSprinting);
    }

    private void HandleMovement()
    {
        // [1] Стоим ли на земле
        bool grounded = _controller.isGrounded;
        
        if (grounded && _velocity.y < 0f)
        {
             _velocity.y = -2f;
        }
        
        // [2] Ввод
        float _h = Input.GetAxis("Horizontal");
        float _v = Input.GetAxis("Vertical");


        Vector3 move = transform.right * _h + transform.forward * _v;
        
        float speed = _isCrouching ? crouchSpeed : Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed;
        
        _controller.Move(move * (speed * Time.deltaTime));

        if (Input.GetButtonDown("Jump") && grounded && !_isCrouching)
        {
            _velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        
        _velocity.y += gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);
    }

    private void HandleFov(bool isSprinting)
    {
        float target = isSprinting ? sprintFov : normalFov;
        
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, target, fovSpeed * Time.deltaTime);
    }

    private void HandleCrouch()
    {
        _isCrouching = Input.GetKey(KeyCode.LeftControl);
        _controller.height = _isCrouching ? crouchHeight : standHeight; 
    }
}
