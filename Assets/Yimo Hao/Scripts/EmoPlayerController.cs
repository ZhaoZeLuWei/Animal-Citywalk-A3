using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

[RequireComponent(typeof(Rigidbody))]
public class EmoPlayerController : MonoBehaviour
{
    public AudioSource getCoin;
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
    
    [Header("UI Settings")]
    public TextMeshProUGUI score;
    public TextMeshProUGUI score1;
    public TextMeshProUGUI score2;
    public TextMeshProUGUI life;
    private int scoreNumber;
    private int score1Number;
    private int score2Number;
    private int lifeNumber;
    
    [Header("Physics Settings")]
    public float gravityStrength = -9.81f;

    
    void Start()
    {
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        
        scoreNumber = 0;
        score.text = scoreNumber.ToString();
        score1Number = -1;
        score1.text = score1Number.ToString();
        score2Number = 0;
        score2.text = score1Number.ToString();
        lifeNumber = 3;
        life.text = lifeNumber.ToString();
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
        if (cameraPivot == null) cameraPivot = transform;
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
        ApplyGravity();
    }

    void HandleMovement()
    {
        // 获取相机方向（忽略Y轴）
        Vector3 forward = cameraPivot.forward;
        Vector3 right = cameraPivot.right;
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        // 计算移动方向
        Vector3 moveDirection = forward * input.y + right * input.x;
        
        // 移动
        Vector3 targetVelocity = moveDirection * speed;
        rb.velocity = new Vector3(targetVelocity.x, rb.velocity.y, targetVelocity.z);

        // 只在有输入且不是向后移动时旋转角色
        if (moveDirection.magnitude > 0.1f && input.y >= 0)
        {
            float targetRotation = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
            Quaternion targetQuat = Quaternion.Euler(0, targetRotation, 0);
            rb.rotation = Quaternion.Slerp(rb.rotation, targetQuat, rotationSpeed * Time.fixedDeltaTime);
        }
    }

    void ApplyGravity()
    {
        rb.AddForce(new Vector3(0, gravityStrength, 0), ForceMode.Acceleration);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            getCoin.Play();
            other.gameObject.SetActive(false);
            scoreNumber += 1;
            score.text = scoreNumber.ToString();
            score1Number += 1;
            score1.text = score1Number.ToString();
            score2Number += 1;
            score2.text = score2Number.ToString();
        }
        if (other.gameObject.CompareTag("car"))
        {
            lifeNumber -= 1;
            life.text = lifeNumber.ToString();
        }
    }
}