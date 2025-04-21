using UnityEngine;

public class damageRule : MonoBehaviour
{
    public AudioSource damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Zewei_HealthManager.Instance.TakeDamage(1); 
            damage.Play();
        }
    }
}


