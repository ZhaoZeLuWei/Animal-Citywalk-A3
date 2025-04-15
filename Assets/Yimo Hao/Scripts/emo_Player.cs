using UnityEngine;

public class emo_Player : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            emo_HealthManager.Instance.TakeDamage(1); 
        }
    }
}


