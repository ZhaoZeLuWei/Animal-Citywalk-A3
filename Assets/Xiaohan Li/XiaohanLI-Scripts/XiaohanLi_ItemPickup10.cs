using UnityEngine;

public class XiaohanLi_ItemPickup10 : MonoBehaviour
{
    public GameObject currentPanel; 
    public GameObject victoryPanel; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player picked up an item worth 10 points.");

            XiaohanLi_ScoreManager.Instance.AddScore(10);

            if (XiaohanLi_AudioManager.Instance != null)
            {
                XiaohanLi_AudioManager.Instance.PlayPickupSound();
            }
            else
            {
                Debug.LogError("XiaohanLi_AudioManager is missing in the scene!");
            }

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
        else
        {
            Debug.LogWarning("currentPanel is not assigned!");
        }
    }

    private void ShowVictoryPanel()
    {
        if (victoryPanel != null)
        {
            victoryPanel.SetActive(true); 
        }
        else
        {
            Debug.LogWarning("victoryPanel is not assigned!");
        }
    }
}

