using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider volumeSlider;

    void Start()
    {
        // 初始化Slider的值
        volumeSlider.value = AudioManager.Instance.masterVolume;

        // 绑定Slider值变化事件
        volumeSlider.onValueChanged.AddListener(UpdateMasterVolume);
    }

    // 更新主音量
    private void UpdateMasterVolume(float value)
    {
        AudioManager.Instance.masterVolume = value;
        AudioManager.Instance.SaveVolumeSettings(); // 保存设置
        AudioManager.Instance.UpdateAllAudioSources(); // 更新所有音频源
    }
}
