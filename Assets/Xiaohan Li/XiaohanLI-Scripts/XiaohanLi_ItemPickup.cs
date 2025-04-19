using UnityEngine;

public class XiaohanLi_ItemPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player picked up an item.");
            XiaohanLi_ScoreManager.Instance.AddScore(1);

            XiaohanLi_AudioManager1.Instance.PlayPickupSound();

            Destroy(gameObject);
        }
    }
}




