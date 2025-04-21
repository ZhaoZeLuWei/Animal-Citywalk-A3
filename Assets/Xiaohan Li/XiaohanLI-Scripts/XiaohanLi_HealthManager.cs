using TMPro;
using UnityEngine;

public class XiaohanLi_HealthManager : MonoBehaviour
{
    public static XiaohanLi_HealthManager Instance;

    public int maxHealth = 3;
    private int currentHealth;

    public TMP_Text healthText;
    public TMP_Text otherPanelHealthText;
    public GameObject currentPanel;
    public GameObject gameOverPanel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = ": " + currentHealth;
        }


        if (otherPanelHealthText != null)
        {
            otherPanelHealthText.text = "" + currentHealth;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            GameOver();
        }
        UpdateHealthUI();
    }

    private void GameOver()
    {
        currentPanel.SetActive(false);
        gameOverPanel.SetActive(true);
        if (XiaohanLi_AudioManager3.Instance != null)
        {
            XiaohanLi_AudioManager3.Instance.PlayGameOverSound();
        }
    }
}








