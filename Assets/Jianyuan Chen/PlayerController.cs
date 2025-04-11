using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 500f;
    [SerializeField] private float groundDrag = 5f;

    [Header("Camera")]
    [SerializeField] private Transform cameraPivot;

    private Rigidbody rb;
    private Vector2 inputVector;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void OnMove(InputValue value)
    {
        inputVector = value.Get<Vector2>();
        Debug.Log($"Input: {inputVector}");
    }

    private void FixedUpdate()
    {
        // ��ȡ��ȫˮƽ�����������
        Vector3 forward = GetFlattenedDirection(cameraPivot.forward);
        Vector3 right = GetFlattenedDirection(cameraPivot.right);

        Vector3 movement = (forward * inputVector.y + right * inputVector.x).normalized;

        // ʹ��Impulseģʽȷ��������Ӧ
        rb.AddForce(movement * speed * Time.fixedDeltaTime, ForceMode.Impulse);

        // Ӧ�õ�������
        rb.drag = IsGrounded() ? groundDrag : 0f;
    }

    private Vector3 GetFlattenedDirection(Vector3 dir)
    {
        return new Vector3(dir.x, 0, dir.z).normalized;
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 0.1f);
    }
}