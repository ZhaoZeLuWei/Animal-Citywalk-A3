using UnityEngine;

public class emo_Player : MonoBehaviour


{
    public AudioSource Damage;
    private void OnTriggerEnter(Collider other)
    
    {
        if (other.CompareTag("Player"))
        {
            Damage.Play();
            emo_HealthManager.Instance.TakeDamage(1); 
        }
    }
}


