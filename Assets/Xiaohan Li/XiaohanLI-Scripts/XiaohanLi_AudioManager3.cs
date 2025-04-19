using UnityEngine;

public class XiaohanLi_AudioManager3 : MonoBehaviour
{
    public static XiaohanLi_AudioManager3 Instance;

    public AudioClip gameOverSound; // 游戏结束音效

    private AudioSource soundEffectSource; // 用于播放一次性音效

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

        // 初始化两个 AudioSource
        soundEffectSource = gameObject.AddComponent<AudioSource>();

    }

    // 播放游戏结束音效
    public void PlayGameOverSound()
    {
        if (gameOverSound != null)
        {
            soundEffectSource.PlayOneShot(gameOverSound); // 使用 PlayOneShot 播放一次性音效
        }
    }
}