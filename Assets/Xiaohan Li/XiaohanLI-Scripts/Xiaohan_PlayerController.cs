using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class Xiaohan_PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    private Rigidbody rb;
    private Vector2 input;
    public float speed = 8.0f;
    public float rotationSpeed = 10f;

    [Header("Camera Settings")]
    public Transform cameraPivot;
    public float mouseSensitivity = 100f;
    [SerializeField] private float xRotation = 0f;
    public bool enableMouseLook = true;

    [Header("Height Settings")]
    private float initialHeight; // 记录初始高度

    void Start()
    {
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (cameraPivot == null) cameraPivot = transform;

        // 记录角色的初始高度
        initialHeight = transform.position.y;
    }

    void OnMove(InputValue value)
    {
        input = value.Get<Vector2>();
    }

    void OnLook(InputValue value)
    {
        if (enableMouseLook)
        {
            Vector2 mouseInput = value.Get<Vector2>();
            HandleCameraRotation(mouseInput);
        }
    }

    void Update()
    {
        if (Keyboard.current.tabKey.wasPressedThisFrame)
        {
            ToggleMouseControl();
        }
    }

    void ToggleMouseControl()
    {
        enableMouseLook = !enableMouseLook;
        Cursor.lockState = enableMouseLook ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !enableMouseLook;
    }

    void HandleCameraRotation(Vector2 mouseInput)
    {
        float mouseX = mouseInput.x * mouseSensitivity * Time.deltaTime;
        float mouseY = mouseInput.y * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        cameraPivot.localRotation = Quaternion.Euler(xRotation, 0, 0);

        transform.Rotate(Vector3.up * mouseX);
    }

    void FixedUpdate()
    {
        HandleMovement();

        // 锁定角色的 Y 轴位置到初始高度
        Vector3 newPosition = transform.position;
        newPosition.y = initialHeight;
        transform.position = newPosition;
    }

    void HandleMovement()
    {
        // 获取摄像机的前向和右向方向
        Vector3 forward = cameraPivot.forward;
        Vector3 right = cameraPivot.right;
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        // 计算移动方向
        Vector3 moveDirection = forward * input.y + right * input.x;

        // 设置目标速度
        Vector3 targetVelocity = moveDirection * speed;
        rb.velocity = new Vector3(targetVelocity.x, 0, targetVelocity.z); // Y 轴速度始终为 0

        // 如果玩家正在移动，则调整角色朝向
        if (moveDirection.magnitude > 0.1f && input.y >= 0)
        {
            float targetRotation = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
            Quaternion targetQuat = Quaternion.Euler(0, targetRotation, 0);
            rb.rotation = Quaternion.Slerp(rb.rotation, targetQuat, rotationSpeed * Time.fixedDeltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            other.gameObject.SetActive(false); // 拾取金币后隐藏金币
        }
    }
}








