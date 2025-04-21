using UnityEngine;

public class ApplyVolumeOnSceneLoad : MonoBehaviour
{
    void Start()
    {
        // 更新所有音频源的音量
        AudioManager.Instance.UpdateAllAudioSources();
    }
}