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
        // 获取完全水平的摄像机方向
        Vector3 forward = GetFlattenedDirection(cameraPivot.forward);
        Vector3 right = GetFlattenedDirection(cameraPivot.right);

        Vector3 movement = (forward * inputVector.y + right * inputVector.x).normalized;

        // 使用Impulse模式确保立即响应
        rb.AddForce(movement * speed * Time.fixedDeltaTime, ForceMode.Impulse);

        // 应用地面阻力
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