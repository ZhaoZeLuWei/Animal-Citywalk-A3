using UnityEngine;

public class XiaohanLi_ItemPickup : MonoBehaviour
{
    public static event System.Action OnItemPickedUp;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            XiaohanLi_ScoreManager.Instance.AddScore(1); 
            Destroy(gameObject);
        }
    }
}




