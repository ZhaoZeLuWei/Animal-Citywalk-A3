using TMPro;
using UnityEngine;

public class Xiaohan_PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 5f;
    private bool canMove = true;

    // 记录初始位置
    private Vector3 initialPosition;

    // 分数和血量
    public int score = 0;
    public int health = 3;

    // UI元素
    public TMP_Text scoreText; // 显示分数的 UI 文本
    public TMP_Text healthText; // 显示血量的 UI 文本

    // 拾取的物品预设
    public GameObject[] collectiblePrefabs; // 存储可拾取物品的预设
    public Transform[] spawnPoints; // 存储物品生成位置

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeRotation;

        // 记录角色的初始位置
        initialPosition = transform.position;

        // 初始化 UI
        UpdateUI();

        // 生成物品
        SpawnCollectibles();
    }

    void Update()
    {
        if (canMove)
        {
            float movementX = Input.GetAxis("Horizontal");
            float movementY = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(movementX, 0.0f, movementY) * speed;

            rb.velocity = new Vector3(movement.x, 0, movement.z);
        }
    }

    public void SetMovement(bool enable)
    {
        canMove = enable;
    }

    public void ResetPosition()
    {
        // 将角色位置重置为初始位置
        transform.position = initialPosition;

        // 重置分数和血量
        score = 0;
        health = 3;

        // 更新 UI
        UpdateUI();

        // 重新生成物品
        SpawnCollectibles();
    }

    private void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
        if (healthText != null)
            healthText.text = "Health: " + health;
    }

    private void SpawnCollectibles()
    {
        // 清除之前的物品
        foreach (var collectible in GameObject.FindGameObjectsWithTag("Collectible"))
        {
            Destroy(collectible);
        }

        // 生成新的物品
        foreach (var spawnPoint in spawnPoints)
        {
            int randomIndex = Random.Range(0, collectiblePrefabs.Length);
            Instantiate(collectiblePrefabs[randomIndex], spawnPoint.position, Quaternion.identity);
        }
    }
}









