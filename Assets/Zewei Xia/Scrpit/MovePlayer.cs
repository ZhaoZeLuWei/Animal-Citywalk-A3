using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

[RequireComponent(typeof(Rigidbody))]
public class MovePlayer : MonoBehaviour
{
    private Rigidbody rb;
    private Vector2 input;
    public float speed = 8.0f;
    public TextMeshProUGUI score;
    public  TextMeshProUGUI life;
    private int scoreNumber;
    private int lifeNumber;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // ����������ת
        scoreNumber = 0;
        score.text = scoreNumber.ToString();
        lifeNumber = 3;
        life.text = lifeNumber.ToString();
    }

    void OnMove(InputValue value)
    {
        input = value.Get<Vector2>();
        Debug.Log($"Input: ({input.x}, {input.y})");
    }

    private void FixedUpdate()
    {
        Vector3 targetVelocity = new Vector3(input.y, 0, -input.x) * speed;
        rb.velocity = Vector3.Lerp(rb.velocity, targetVelocity, 0.5f);

                // 立即旋转
        if (targetVelocity.magnitude > 0.1f)
        {
            float targetRotation = Mathf.Atan2(targetVelocity.x, targetVelocity.z) * Mathf.Rad2Deg;
            rb.rotation = Quaternion.Euler(0, targetRotation, 0);
        }

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