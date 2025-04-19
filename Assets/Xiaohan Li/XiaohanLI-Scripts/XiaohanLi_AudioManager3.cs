using UnityEngine;

public class XiaohanLi_AudioManager3 : MonoBehaviour
{
    public static XiaohanLi_AudioManager3 Instance { get; private set; }

    public AudioClip backgroundMusic;

    private AudioSource audioSource;
    private AudioSource musicSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("AudioManager initialized and set as singleton.");
        }
        else
        {
            Destroy(gameObject);
            Debug.LogWarning("Duplicate AudioManager instance detected and destroyed.");
        }

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;

        // ��ʼ���������ֲ�����
        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.playOnAwake = false;
        musicSource.priority = 0; // ����������ȼ���ֵԽ�����ȼ�Խ�ߣ�
        musicSource.volume = 1f;  // ȷ����������

        Debug.Log("AudioManager initialized.");
    }

    public void PlaySound(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
        else
        {
            Debug.LogError("Audio clip or AudioSource is missing!");
        }
    }

    public void PlayBackgroundMusic()
    {
        if (backgroundMusic != null && musicSource != null)
        {
            if (!musicSource.isPlaying)
            {
                Debug.Log("Attempting to play background music.");
                musicSource.clip = backgroundMusic;
                musicSource.Play();

                Debug.Log($"Music Source Volume: {musicSource.volume}, Mute: {musicSource.mute}, Priority: {musicSource.priority}, Clip: {musicSource.clip.name}");
            }
        }
        else
        {
            Debug.LogError("Background music or AudioSource is missing!");
        }
    }

    public void StopBackgroundMusic()
    {
        if (musicSource != null && musicSource.isPlaying)
        {
            musicSource.Stop();
        }
    }
}
