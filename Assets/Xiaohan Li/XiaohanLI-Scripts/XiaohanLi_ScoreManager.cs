using TMPro;
using UnityEngine;

public class XiaohanLi_ScoreManager : MonoBehaviour
{
    public static XiaohanLi_ScoreManager Instance;

    public int score = 0;
    public TMP_Text scoreText1; // 第一个面板的文本
    public TMP_Text scoreText2; // 第二个面板的文本
    public TMP_Text scoreText3; // 第三个面板的文本

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
        // 将分数转换为字符串
        string scoreString = score.ToString();

        // 更新所有三个面板的分数文本
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





