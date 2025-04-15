using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emo_ItemPickup10 : MonoBehaviour
{
    public GameObject currentPanel; 
    public GameObject victoryPanel; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HideCurrentPanel();
            ShowVictoryPanel();
            Destroy(gameObject); 
        }
    }

    private void HideCurrentPanel()
    {
        if (currentPanel != null)
        {
            currentPanel.SetActive(false); 
        }
    }

    private void ShowVictoryPanel()
    {
        if (victoryPanel != null)
        {
            victoryPanel.SetActive(true); 
        }
    }
}
