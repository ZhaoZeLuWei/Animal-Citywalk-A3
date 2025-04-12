using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {

            Destroy(gameObject);
        }
    }
}

