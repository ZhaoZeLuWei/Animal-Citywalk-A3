using UnityEngine;

public class damageRule : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Zewei_HealthManager.Instance.TakeDamage(1); 
        }
    }
}


