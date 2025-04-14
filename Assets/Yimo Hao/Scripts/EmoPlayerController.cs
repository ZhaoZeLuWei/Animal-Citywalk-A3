using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

[RequireComponent(typeof(Rigidbody))]
public class EmoPlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    private Rigidbody rb;
    private Vector2 input;
    public float speed = 8.0f;
    public float rotationSpeed = 10f; // 新增：移动时的旋转平滑速度
    
    [Header("Camera Settings")]
    public Transform cameraPivot; // 摄像机旋转的支点（通常是玩家自身或空物体）
    public float mouseSensitivity = 100f;
    private float xRotation = 0f;
    
    [Header("UI Settings")]
    public TextMeshProUGUI score;
    public TextMeshProUGUI life;
    private int scoreNumber;
    private int lifeNumber;
    
    [Header("Physics Settings")]
    public float gravityStrength = -9.81f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        
        // 初始化UI
        scoreNumber = 0;
        score.text = scoreNumber.ToString();
        lifeNumber = 3;
        life.text = lifeNumber.ToString();
        
        // 锁定鼠标
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        // 如果没有指定cameraPivot，默认使用自身
        if (cameraPivot == null) cameraPivot = transform;
    }

    void OnMove(InputValue value)
    {
        input = value.Get<Vector2>();
    }

    void OnLook(InputValue value)
    {
        Vector2 mouseInput = value.Get<Vector2>();
        HandleCameraRotation(mouseInput);
    }

    private void FixedUpdate()
    {
        HandleMovement();
        ApplyGravity();
    }

    void HandleMovement()
    {
        // 基于摄像机方向的移动
        Vector3 moveDirection = (cameraPivot.forward * input.y + cameraPivot.right * input.x).normalized;
        moveDirection.y = 0; // 确保不会向上移动
        
        Vector3 targetVelocity = moveDirection * speed;
        rb.velocity = Vector3.Lerp(rb.velocity, targetVelocity, 0.5f);

        // 平滑旋转朝向移动方向
        if (targetVelocity.magnitude > 0.1f)
        {
            float targetRotation = Mathf.Atan2(targetVelocity.x, targetVelocity.z) * Mathf.Rad2Deg;
            Quaternion targetQuat = Quaternion.Euler(0, targetRotation, 0);
            rb.rotation = Quaternion.Slerp(rb.rotation, targetQuat, rotationSpeed * Time.fixedDeltaTime);
        }
    }

    void HandleCameraRotation(Vector2 mouseInput)
    {
        float mouseX = mouseInput.x * mouseSensitivity * Time.deltaTime;
        float mouseY = mouseInput.y * mouseSensitivity * Time.deltaTime;

        // 垂直旋转（上下看）
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        cameraPivot.localRotation = Quaternion.Euler(xRotation, 0, 0);

        // 水平旋转（左右转）
        transform.Rotate(Vector3.up * mouseX);
    }

    void ApplyGravity()
    {
        rb.AddForce(new Vector3(0, gravityStrength, 0), ForceMode.Acceleration);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            other.gameObject.SetActive(false);
            scoreNumber += 1;
            score.text = scoreNumber.ToString();
        }
        if (other.gameObject.CompareTag("car"))
        {
            lifeNumber -= 1;
            life.text = lifeNumber.ToString();
        }
    }
}