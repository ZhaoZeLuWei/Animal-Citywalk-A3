using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider volumeSlider;

    void Start()
    {
        // ��ʼ��Slider��ֵ
        volumeSlider.value = AudioManager.Instance.masterVolume;

        // ��Sliderֵ�仯�¼�
        volumeSlider.onValueChanged.AddListener(UpdateMasterVolume);
    }

    // ����������
    private void UpdateMasterVolume(float value)
    {
        AudioManager.Instance.masterVolume = value;
        AudioManager.Instance.SaveVolumeSettings(); // ��������
        AudioManager.Instance.UpdateAllAudioSources(); // ����������ƵԴ
    }
}
