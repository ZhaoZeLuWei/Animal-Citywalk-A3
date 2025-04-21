using UnityEngine;

public class XiaohanLi_AudioManager3 : MonoBehaviour
{
    public static XiaohanLi_AudioManager3 Instance;

    public AudioClip gameOverSound; // ��Ϸ������Ч

    private AudioSource soundEffectSource; // ���ڲ���һ������Ч

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

        // ��ʼ������ AudioSource
        soundEffectSource = gameObject.AddComponent<AudioSource>();

    }

    // ������Ϸ������Ч
    public void PlayGameOverSound()
    {
        if (gameOverSound != null)
        {
            soundEffectSource.PlayOneShot(gameOverSound); // ʹ�� PlayOneShot ����һ������Ч
        }
    }
}