using UnityEngine;

public class Xiaohan_PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float movementX = Input.GetAxis("Horizontal"); 
        float movementY = Input.GetAxis("Vertical"); 

        Vector3 movement = new Vector3(movementX, 0.0f, movementY) * speed;

        rb.velocity = movement;
    }
}

