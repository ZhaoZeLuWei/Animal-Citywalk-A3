using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XiaohanLi_ItemPickup10 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            XiaohanLi_ScoreManager.Instance.AddScore(10);
            Destroy(gameObject);
        }
    }
}
