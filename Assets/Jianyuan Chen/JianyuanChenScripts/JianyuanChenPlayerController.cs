using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;//
using UnityEngine.SceneManagement; // 

[RequireComponent(typeof(Rigidbody))]
public class JianyuanChenPlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector2 input;
    private int count;
    private bool isGrounded;//1


    // 音效相关变量
    [Header("Audio Settings")]
    public AudioClip coinSound; // Coin 的音效
    public AudioClip stopSignSound; // StopSign 的音效
    private AudioSource audioSource; // AudioSource 组件


   //Public AudioSource bgmAudioSource; // 在检查器中拖入 BGM 的 AudioSource
    //public AudioClip winMusic; // 胜利音乐
   // public AudioClip loseMusic; // 失败音乐


    [Header("UI Settings")]
    public GameObject losePanel; // 
    public GameObject gameInfoPanel; // 
    public TextMeshProUGUI[] countTexts; //
    public GameObject winPanel;  // 


    [Header("Health Settings")]
    public int maxHealth = 3;
    public TextMeshProUGUI[] healthTexts; // 
    private int health;


    [Header("Movement Settings")]
    public float speed = 5f;
    [Range(5f, 170f)] public float jumpForce = 12f;
    public float gravityMultiplier = 2f; // 



    [Header("Ground Detection")]
    public float groundCheckRadius = 0.4f;
    public LayerMask groundLayer;
    public Vector3 groundCheckOffset = new Vector3(0, -0.5f, 0);


    private float initialGravity; //

    void Start()
    {
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // 
        initialGravity = Physics.gravity.y; //
        count = 0;
        SetCountText();//
        health = maxHealth;
        SetHealthText(); // 
        if (losePanel != null) losePanel.SetActive(false);
        if (gameInfoPanel != null) gameInfoPanel.SetActive(true);
        if (winPanel != null) winPanel.SetActive(false);

        // 初始化 AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false; // 禁止自动播放


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
            // 
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
    }
    void SetCountText()//
    {
        foreach (var text in countTexts)
        {
            if (text != null)
                text.text = $": {count}"; // 
        }
    }

    void SetHealthText()
    {
        foreach (var text in healthTexts)
        {
            if (text != null)
                text.text = $": {health}"; // 
        }
    }

    private void FixedUpdate()
    {

        rb.AddForce(Vector3.up * initialGravity * (gravityMultiplier - 1), ForceMode.Acceleration);


        isGrounded = Physics.CheckSphere(
            transform.position + groundCheckOffset,
            groundCheckRadius,
            groundLayer
        );


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
            // 播放 Coin 音效
            if (coinSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(coinSound);
            }
        }
        else if (other.gameObject.CompareTag("StopSign")) //
        {
            TakeDamage(1);
            other.gameObject.SetActive(false); // 
                                               // 播放 StopSign 音效
            if (stopSignSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(stopSignSound);
            }
        }
        else if (other.CompareTag("Win")) // 
        {
            Victory();
        }
    }
    void Victory()
    {
        Debug.Log("Victory!");
        // 暂停原BGM并播放胜利音乐
        AudioManager.Instance.PauseBGM();
        AudioManager.Instance.PlayWinMusic();



        if (gameInfoPanel != null)
        {
            gameInfoPanel.SetActive(false);
        }

        if (winPanel != null)
        {
            winPanel.SetActive(true);
        }

        Time.timeScale = 0;


        GetComponent<PlayerInput>().enabled = false;

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
        // 暂停原BGM并播放失败音乐
        AudioManager.Instance.PauseBGM();
        AudioManager.Instance.PlayLoseMusic();
        if (gameInfoPanel != null)
        {
            gameInfoPanel.SetActive(false);
        }
        if (losePanel != null)
        {
            losePanel.SetActive(true);
        }


        Time.timeScale = 0;

        GetComponent<PlayerInput>().enabled = false;


    }
}