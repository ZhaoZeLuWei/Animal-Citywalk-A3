using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    // 单例实例
    public static AudioManager Instance { get; private set; }

    // 音频源
    public AudioSource bgmSource; // BGM 的 AudioSource
    public AudioClip winMusic; // 胜利音乐
    public AudioClip loseMusic; // 失败音乐

    // 主音量，范围限制在 0 到 1
    [Range(0f, 1f)]
    public float masterVolume = 0.4f;
    // BGM 音量缩放，用于控制 BGM 相对于主音量的比例，范围限制在 0 到 1
    [Range(0f, 1f)]
    public float bgmVolumeScale = 1f; // 默认为 1，表示 BGM 可以达到完整的主音量

    // 静音状态
    private bool isMuted = false;

    // 原始 BGM 的 clip
    private AudioClip originalBGM;

    // 是否静音的属性
    public bool IsMuted
    {
        get { return isMuted; }
    }

    void Awake()
    {
        // 确保只有一个 AudioManager 实例
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject); // 场景切换时不销毁

        // 初始化 BGM 音频源
        if (bgmSource != null && bgmSource.clip != null)
        {
            originalBGM = bgmSource.clip;
            bgmSource.loop = true;
            UpdateBGMVolume(); // 初始化 BGM 音量
            bgmSource.Play();
        }

        // 加载音量和静音设置
        LoadVolumeSettings();
        LoadMuteState();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // 场景加载完成时调用
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (bgmSource != null && originalBGM != null)
        {
            bgmSource.Stop();
            bgmSource.clip = originalBGM;
            bgmSource.loop = true;
            UpdateBGMVolume(); // 确保场景加载后 BGM 音量正确
            bgmSource.Play();
        }
    }

    // 静音所有声音
    public void MuteAll()
    {
        isMuted = true;
        AudioListener.pause = true; // 暂停所有音频监听器
        SaveMuteState();
    }

    // 取消静音
    public void UnmuteAll()
    {
        isMuted = false;
        AudioListener.pause = false; // 恢复所有音频监听器
        SaveMuteState();
    }

    // 保存静音状态到 PlayerPrefs
    private void SaveMuteState()
    {
        PlayerPrefs.SetInt("IsMuted", isMuted ? 1 : 0);
        PlayerPrefs.Save();
    }

    // 加载静音状态
    private void LoadMuteState()
    {
        isMuted = PlayerPrefs.GetInt("IsMuted", 0) == 1;
        AudioListener.pause = isMuted; // 初始化时应用静音状态
    }

    // 保存音量设置
    public void SaveVolumeSettings()
    {
        PlayerPrefs.SetFloat("MasterVolume", masterVolume);
        PlayerPrefs.Save();
    }

    // 加载音量设置
    public void LoadVolumeSettings()
    {
        masterVolume = PlayerPrefs.GetFloat("MasterVolume", 0.4f);
        UpdateAllAudioSources();
    }

    // 更新所有音频源的音量
    public void UpdateAllAudioSources()
    {
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audioSource in allAudioSources)
        {
            // 对 BGM 特殊处理，其他音频源直接应用主音量
            if (audioSource != bgmSource)
            {
                audioSource.volume = masterVolume;
            }
            else
            {
                UpdateBGMVolume();
            }
        }
    }

    // 专门更新 BGM 音量的函数
    private void UpdateBGMVolume()
    {
        if (bgmSource != null)
        {
            // BGM 的实际音量是主音量乘以缩放比例，但不能超过 0.3
            bgmSource.volume = Mathf.Min(masterVolume * bgmVolumeScale, 0.3f);
        }
    }

    // 播放 BGM
    public void PlayBGM(AudioClip clip)
    {
        if (bgmSource == null) bgmSource = GetComponent<AudioSource>();
        originalBGM = clip;
        bgmSource.clip = clip;
        bgmSource.loop = true;
        UpdateBGMVolume(); // 播放新的 BGM 时设置音量
        bgmSource.Play();
    }

    // 暂停 BGM
    public void PauseBGM()
    {
        if (bgmSource != null && bgmSource.isPlaying)
            bgmSource.Pause();
    }

    // 恢复 BGM
    public void ResumeBGM()
    {
        if (bgmSource != null && !bgmSource.isPlaying)
            bgmSource.UnPause();
    }

    // 播放胜利音乐
    public void PlayWinMusic()
    {
        if (bgmSource != null)
        {
            originalBGM = bgmSource.clip;
            bgmSource.Stop();
            bgmSource.clip = winMusic;
            bgmSource.loop = false;
            bgmSource.volume = masterVolume; // 胜利/失败音乐跟随主音量
            bgmSource.Play();
        }
    }

    // 播放失败音乐
    public void PlayLoseMusic()
    {
        if (bgmSource != null)
        {
            originalBGM = bgmSource.clip;
            bgmSource.Stop();
            bgmSource.clip = loseMusic;
            bgmSource.loop = false;
            bgmSource.volume = masterVolume; // 胜利/失败音乐跟随主音量
            bgmSource.Play();
        }
    }

    // 重新开始播放 BGM
    public void RestartBGM()
    {
        if (bgmSource != null && originalBGM != null)
        {
            bgmSource.Stop();
            bgmSource.clip = originalBGM;
            bgmSource.loop = true;
            UpdateBGMVolume(); // 重新开始播放时设置音量
            bgmSource.Play();
        }
    }

    // 设置主音量（供外部 UI 控件调用）
    public void SetMasterVolume(float newVolume)
    {
        masterVolume = Mathf.Clamp01(newVolume); // 确保音量在 0 到 1 之间
        UpdateAllAudioSources();
        SaveVolumeSettings();
    }

    // 可选：设置 BGM 音量缩放（如果需要更精细地控制 BGM 相对于其他声音的音量）
    public void SetBGMVolumeScale(float newScale)
    {
        bgmVolumeScale = Mathf.Clamp01(newScale);
        UpdateBGMVolume();
    }
}