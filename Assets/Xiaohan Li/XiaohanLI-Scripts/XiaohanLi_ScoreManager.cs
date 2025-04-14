using TMPro;
using UnityEngine;

public class XiaohanLi_ScoreManager : MonoBehaviour
{
    public static XiaohanLi_ScoreManager Instance;

    public int score = 0;
    public TMP_Text scoreText1; 
    public TMP_Text scoreText2; 
    public TMP_Text scoreText3; 

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
        UpdateScoreUI();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        string scoreString = score.ToString();

        if (scoreText1 != null)
        {
            scoreText1.text = scoreString;
        }
        if (scoreText2 != null)
        {
            scoreText2.text = scoreString;
        }
        if (scoreText3 != null)
        {
            scoreText3.text = scoreString;
        }
    }
}





