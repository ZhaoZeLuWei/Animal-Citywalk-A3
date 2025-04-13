using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;//
using UnityEngine.SceneManagement; // 新增的命名空间引用

[RequireComponent(typeof(Rigidbody))]
public class JianyuanChenPlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector2 input;
    private int count;
    private bool isGrounded;//1



    [Header("Health Settings")]
    public int maxHealth = 3;
    public TextMeshProUGUI healthText; // 新增血量显示文本
    private int health;


    [Header("Movement Settings")]
    public float speed = 5f;
    [Range(5f, 170f)] public float jumpForce = 12f;
    public float gravityMultiplier = 2f; // 新增重力增强系数



    [Header("Ground Detection")]
    public float groundCheckRadius = 0.4f;
    public LayerMask groundLayer;
    public Vector3 groundCheckOffset = new Vector3(0, -0.5f, 0);

    public TextMeshProUGUI countText;

    private float initialGravity; // 记录初始重力值

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // 冻结物理旋转、
        initialGravity = Physics.gravity.y; // 保存初始重力值
        count = 0;
        SetCountText();//
        health = maxHealth;
        SetHealthText(); // 初始化血量显示
    }

    void OnMove(InputValue value)
    {
        input = value.Get<Vector2>();
        Debug.Log($"Input: ({input.x}, {input.y})");
    }

    void Update()//1
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
        {
            // 使用速度修改确保高度一致性
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
    }
    void SetCountText()//
    {
        countText.text = ": " + count.ToString();//
    }

    void SetHealthText()
    {
        healthText.text = ": " + health.ToString();
    }

    private void FixedUpdate()
    {
        // 增强重力效果
        rb.AddForce(Vector3.up * initialGravity * (gravityMultiplier - 1), ForceMode.Acceleration);

        // 改进的地面检测
        isGrounded = Physics.CheckSphere(
            transform.position + groundCheckOffset,
            groundCheckRadius,
            groundLayer
        );


        // 使用速度控制+输入平滑
        Vector3 targetVelocity = new Vector3(input.x, 0, input.y) * speed;
        rb.velocity = Vector3.Lerp(rb.velocity, targetVelocity, 0.5f);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("StopSign")) // 新增扣血判断
        {
            TakeDamage(1);
            other.gameObject.SetActive(false); // 可选：使停止标志消失
        }
    }

    void TakeDamage(int damage)
    {
        health = Mathf.Max(health - damage, 0);
        SetHealthText();

        if (health <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {

        Debug.Log("Game Over!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 重新加载当前场景
    }


}