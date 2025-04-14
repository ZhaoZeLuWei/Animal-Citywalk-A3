using TMPro;
using UnityEngine;

public class Xiaohan_PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 5f;
    private bool canMove = true;

    // ��¼��ʼλ��
    private Vector3 initialPosition;

    // ������Ѫ��
    public int score = 0;
    public int health = 3;

    // UIԪ��
    public TMP_Text scoreText; // ��ʾ������ UI �ı�
    public TMP_Text healthText; // ��ʾѪ���� UI �ı�

    // ʰȡ����ƷԤ��
    public GameObject[] collectiblePrefabs; // �洢��ʰȡ��Ʒ��Ԥ��
    public Transform[] spawnPoints; // �洢��Ʒ����λ��

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeRotation;

        // ��¼��ɫ�ĳ�ʼλ��
        initialPosition = transform.position;

        // ��ʼ�� UI
        UpdateUI();

        // ������Ʒ
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
        // ����ɫλ������Ϊ��ʼλ��
        transform.position = initialPosition;

        // ���÷�����Ѫ��
        score = 0;
        health = 3;

        // ���� UI
        UpdateUI();

        // ����������Ʒ
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
        // ���֮ǰ����Ʒ
        foreach (var collectible in GameObject.FindGameObjectsWithTag("Collectible"))
        {
            Destroy(collectible);
        }

        // �����µ���Ʒ
        foreach (var spawnPoint in spawnPoints)
        {
            int randomIndex = Random.Range(0, collectiblePrefabs.Length);
            Instantiate(collectiblePrefabs[randomIndex], spawnPoint.position, Quaternion.identity);
        }
    }
}









