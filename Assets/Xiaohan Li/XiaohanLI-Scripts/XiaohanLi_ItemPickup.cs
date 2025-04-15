using UnityEngine;

public class XiaohanLi_ItemPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            XiaohanLi_ScoreManager.Instance.AddScore(1); 
            Destroy(gameObject);
        }
    }
}




