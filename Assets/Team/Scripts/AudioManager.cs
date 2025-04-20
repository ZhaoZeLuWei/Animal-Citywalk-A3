using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    // ����ʵ��
    public static AudioManager Instance { get; private set; }

    // ��ƵԴ���
    public AudioSource bgmSource; // BGM��AudioSource
    public AudioClip winMusic; // ʤ������
    public AudioClip loseMusic; // ʧ������

    // ��������
    public float masterVolume = 0.4f;

    // ����״̬
    private bool isMuted = false;

    // ���ӹ�����������¶isMuted
    public bool IsMuted
    {
        get { return isMuted; }
    }

    // ����ԭʼBGM��clip
    private AudioClip originalBGM;

    void Awake()
    {
        // ȷ��ֻ��һ��ʵ������
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject); // �糡��������

        // ��ʼ��BGM�����������clip��
        if (bgmSource != null && bgmSource.clip != null)
        {
            originalBGM = bgmSource.clip; // ����ԭʼBGM
            bgmSource.loop = true;
            bgmSource.volume = masterVolume;
            bgmSource.Play();
        }

        // ���ر������������
        LoadVolumeSettings();
        LoadMuteState();
    }

    // ע�᳡����������¼�
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // ȡ��ע���¼�����ֹ�ڴ�й©��
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // �����������ʱ����
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // �ڴ˴�������Ҫˢ�µĲ���
        // ���磺���¼���BGM��Ӧ����������
        if (bgmSource != null && originalBGM != null)
        {
            bgmSource.Stop();
            bgmSource.clip = originalBGM;
            bgmSource.loop = true;
            bgmSource.Play();
        }
    }

    // ������ط���
    public void MuteAll()
    {
        isMuted = true;
        AudioListener.pause = true; // ȫ����ͣ������Ƶ
        SaveMuteState();
    }

    public void UnmuteAll()
    {
        isMuted = false;
        AudioListener.pause = false; // �ָ�������Ƶ
        SaveMuteState();
    }

    // ���澲��״̬��PlayerPrefs
    private void SaveMuteState()
    {
        PlayerPrefs.SetInt("IsMuted", isMuted ? 1 : 0);
        PlayerPrefs.Save();
    }

    // ���ؾ���״̬
    private void LoadMuteState()
    {
        isMuted = PlayerPrefs.GetInt("IsMuted", 0) == 1;
        AudioListener.pause = isMuted; // ��ʼ��ʱӦ�þ���״̬
    }

    // ��������
    public void SaveVolumeSettings()
    {
        PlayerPrefs.SetFloat("MasterVolume", masterVolume);
        PlayerPrefs.Save();
    }

    public void LoadVolumeSettings()
    {
        masterVolume = PlayerPrefs.GetFloat("MasterVolume", 0.4f);
        UpdateAllAudioSources(); // Ӧ��������������ƵԴ
    }

    public void UpdateAllAudioSources()
    {
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.volume = masterVolume;
        }
    }

    // BGM����
    public void PlayBGM(AudioClip clip)
    {
        if (bgmSource == null) bgmSource = GetComponent<AudioSource>();
        originalBGM = clip; // ����ԭʼBGM
        bgmSource.clip = clip;
        bgmSource.loop = true;
        bgmSource.volume = masterVolume;
        bgmSource.Play();
    }

    public void PauseBGM()
    {
        if (bgmSource != null && bgmSource.isPlaying)
            bgmSource.Pause();
    }

    public void ResumeBGM()
    {
        if (bgmSource != null && !bgmSource.isPlaying)
            bgmSource.UnPause();
    }

    // ʤ��/ʧ�����֣�����ȴ��ָ���
    public void PlayWinMusic()
    {
        if (bgmSource != null)
        {
            // ���浱ǰBGM��clip�������Ҫ�����ָ���
            originalBGM = bgmSource.clip;
            bgmSource.Stop();
            bgmSource.clip = winMusic;
            bgmSource.loop = false;
            bgmSource.volume = masterVolume; // Ӧ��������
            bgmSource.Play();
            // ���ٵȴ��ָ������ֽ������ֹͣ
        }
    }

    public void PlayLoseMusic()
    {
        if (bgmSource != null)
        {
            // ���浱ǰBGM��clip�������Ҫ�����ָ���
            originalBGM = bgmSource.clip;
            bgmSource.Stop();
            bgmSource.clip = loseMusic;
            bgmSource.loop = false;
            bgmSource.volume = masterVolume; // Ӧ��������
            bgmSource.Play();
            // ���ٵȴ��ָ������ֽ������ֹͣ
        }
    }



    // ���¿�ʼBGM���ֶ��ָ���
    public void RestartBGM()
    {
        if (bgmSource != null && originalBGM != null)
        {
            bgmSource.Stop(); // ֹͣ��ǰ���ŵ���Ƶ
            bgmSource.clip = originalBGM;
            bgmSource.loop = true;
            bgmSource.Play(); // ���¿�ʼ����
        }
    }
}