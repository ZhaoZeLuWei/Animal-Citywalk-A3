 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zewei_ItemPickup10 : MonoBehaviour
{
    public GameObject currentPanel; 
    public GameObject victoryPanel; 
    public AudioSource winSound;

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
            winSound.Play();
            Time.timeScale = 0;
        }
    }
}

