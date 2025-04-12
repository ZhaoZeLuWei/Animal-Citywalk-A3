using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class MovePlayer : MonoBehaviour
{
    private Rigidbody rb;
    private Vector2 input;
    public float speed = 8.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // ����������ת
    }

    void OnMove(InputValue value)
    {
        input = value.Get<Vector2>();
        Debug.Log($"Input: ({input.x}, {input.y})");
    }

    private void FixedUpdate()
    {
        // ʹ���ٶȿ���+����ƽ��
        Vector3 targetVelocity = new Vector3(input.y, 0, -input.x) * speed;
        rb.velocity = Vector3.Lerp(rb.velocity, targetVelocity, 0.5f);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            other.gameObject.SetActive(false);
        }

    }
}