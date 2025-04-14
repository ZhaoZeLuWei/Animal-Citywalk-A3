using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmoCameraFollow : MonoBehaviour
{
    public GameObject player;
    private Vector3 CameraPosition;
    void Start()
    {
        CameraPosition = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + CameraPosition;
    }
}
