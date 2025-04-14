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
    public float rotationSpeed = 10f;
    
    [Header("Camera Settings")]
    public Transform cameraPivot;
    public float mouseSensitivity = 100f;
    [SerializeField] private float xRotation = 0f; // 添加SerializeField消除警告
    public bool enableMouseLook = true;
    
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
        
        scoreNumber = 0;
        score.text = scoreNumber.ToString();
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
        Vector3 moveDirection = (cameraPivot.forward * input.y + cameraPivot.right * input.x).normalized;
        moveDirection.y = 0;
        
        Vector3 targetVelocity = moveDirection * speed;
        rb.velocity = Vector3.Lerp(rb.velocity, targetVelocity, 0.5f);

        if (targetVelocity.magnitude > 0.1f)
        {
            float targetRotation = Mathf.Atan2(targetVelocity.x, targetVelocity.z) * Mathf.Rad2Deg;
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