using UnityEngine;

public class JianyuanChenRotator : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        // Rotate the object on X, Y, and Z axes by specified amounts, adjusted for frame rate.
        transform.Rotate(new Vector3(150, 300, 450) * Time.deltaTime);
    }

}