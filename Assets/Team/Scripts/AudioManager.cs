using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    // 单例实例
    public static AudioManager Instance { get; private set; }

    // 音频源相关
    public AudioSource bgmSource; // BGM的AudioSource
    public AudioClip winMusic; // 胜利音乐
    public AudioClip loseMusic; // 失败音乐

    // 音量控制
    public float masterVolume = 1f;

    // 静音状态
    private bool isMuted = false;

    // 添加公共属性来暴露isMuted
    public bool IsMuted
    {
        get { return isMuted; }
    }

    // 保存原始BGM的clip
    private AudioClip originalBGM;

    void Awake()
    {
        // 确保只有一个实例存在
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject); // 跨场景不销毁

        // 初始化BGM（如果配置了clip）
        if (bgmSource != null && bgmSource.clip != null)
        {
            originalBGM = bgmSource.clip; // 保存原始BGM
            bgmSource.loop = true;
            bgmSource.volume = masterVolume;
            bgmSource.Play();
        }

        // 加载保存的音量设置
        LoadVolumeSettings();
        LoadMuteState();
    }

    // 注册场景加载完成事件
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // 取消注册事件（防止内存泄漏）
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // 场景加载完成时触发
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 在此处添加需要刷新的操作
        // 例如：重新加载BGM或应用音量设置
        if (bgmSource != null && originalBGM != null)
        {
            bgmSource.Stop();
            bgmSource.clip = originalBGM;
            bgmSource.loop = true;
            bgmSource.Play();
        }
    }

    // 静音相关方法
    public void MuteAll()
    {
        isMuted = true;
        AudioListener.pause = true; // 全局暂停所有音频
        SaveMuteState();
    }

    public void UnmuteAll()
    {
        isMuted = false;
        AudioListener.pause = false; // 恢复所有音频
        SaveMuteState();
    }

    // 保存静音状态到PlayerPrefs
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

    // 音量管理
    public void SaveVolumeSettings()
    {
        PlayerPrefs.SetFloat("MasterVolume", masterVolume);
        PlayerPrefs.Save();
    }

    public void LoadVolumeSettings()
    {
        masterVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);
        UpdateAllAudioSources(); // 应用音量到所有音频源
    }

    public void UpdateAllAudioSources()
    {
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.volume = masterVolume;
        }
    }

    // BGM控制
    public void PlayBGM(AudioClip clip)
    {
        if (bgmSource == null) bgmSource = GetComponent<AudioSource>();
        originalBGM = clip; // 更新原始BGM
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

    // 胜利/失败音乐（无需等待恢复）
    public void PlayWinMusic()
    {
        if (bgmSource != null)
        {
            // 保存当前BGM的clip（如果需要后续恢复）
            originalBGM = bgmSource.clip;
            bgmSource.Stop();
            bgmSource.clip = winMusic;
            bgmSource.loop = false;
            bgmSource.volume = masterVolume; // 应用主音量
            bgmSource.Play();
            // 不再等待恢复，音乐结束后会停止
        }
    }

    public void PlayLoseMusic()
    {
        if (bgmSource != null)
        {
            // 保存当前BGM的clip（如果需要后续恢复）
            originalBGM = bgmSource.clip;
            bgmSource.Stop();
            bgmSource.clip = loseMusic;
            bgmSource.loop = false;
            bgmSource.volume = masterVolume; // 应用主音量
            bgmSource.Play();
            // 不再等待恢复，音乐结束后会停止
        }
    }

    // 移除协程相关代码
    // private IEnumerator WaitForMusicCompletion(float duration) { ... }

    // 重新开始BGM（手动恢复）
    public void RestartBGM()
    {
        if (bgmSource != null && originalBGM != null)
        {
            bgmSource.Stop(); // 停止当前播放的音频
            bgmSource.clip = originalBGM;
            bgmSource.loop = true;
            bgmSource.Play(); // 重新开始播放
        }
    }
}