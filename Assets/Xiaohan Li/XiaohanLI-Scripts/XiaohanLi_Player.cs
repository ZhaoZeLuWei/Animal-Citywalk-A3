using UnityEngine;

public class XiaohanLi_Player : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            XiaohanLi_HealthManager.Instance.TakeDamage(1); 
        }
    }
}


