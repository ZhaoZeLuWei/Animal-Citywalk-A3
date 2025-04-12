using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionRotter : MonoBehaviour
{
    // private but access to unity?
    [SerializeField] float x;
    [SerializeField] float y;
    [SerializeField] float z;
    // Start is called before the first frame update
    void Update()
    {
        transform.Rotate(new Vector3(x,y,z) * Time.deltaTime); 
    }
}
