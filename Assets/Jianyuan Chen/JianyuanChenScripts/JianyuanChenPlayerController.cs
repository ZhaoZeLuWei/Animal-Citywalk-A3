using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;//
using UnityEngine.SceneManagement; // �����������ռ�����

[RequireComponent(typeof(Rigidbody))]
public class JianyuanChenPlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector2 input;
    private int count;
    private bool isGrounded;//1



    [Header("Health Settings")]
    public int maxHealth = 3;
    public TextMeshProUGUI healthText; // ����Ѫ����ʾ�ı�
    private int health;


    [Header("Movement Settings")]
    public float speed = 5f;
    [Range(5f, 170f)] public float jumpForce = 12f;
    public float gravityMultiplier = 2f; // ����������ǿϵ��



    [Header("Ground Detection")]
    public float groundCheckRadius = 0.4f;
    public LayerMask groundLayer;
    public Vector3 groundCheckOffset = new Vector3(0, -0.5f, 0);

    public TextMeshProUGUI countText;

    private float initialGravity; // ��¼��ʼ����ֵ

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // ����������ת��
        initialGravity = Physics.gravity.y; // �����ʼ����ֵ
        count = 0;
        SetCountText();//
        health = maxHealth;
        SetHealthText(); // ��ʼ��Ѫ����ʾ
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
            // ʹ���ٶ��޸�ȷ���߶�һ����
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
        // ��ǿ����Ч��
        rb.AddForce(Vector3.up * initialGravity * (gravityMultiplier - 1), ForceMode.Acceleration);

        // �Ľ��ĵ�����
        isGrounded = Physics.CheckSphere(
            transform.position + groundCheckOffset,
            groundCheckRadius,
            groundLayer
        );


        // ʹ���ٶȿ���+����ƽ��
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
        else if (other.gameObject.CompareTag("StopSign")) // ������Ѫ�ж�
        {
            TakeDamage(1);
            other.gameObject.SetActive(false); // ��ѡ��ʹֹͣ��־��ʧ
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // ���¼��ص�ǰ����
    }


}