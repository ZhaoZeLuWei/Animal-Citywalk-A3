using UnityEngine;

public class ApplyVolumeOnSceneLoad : MonoBehaviour
{
    void Start()
    {
        // ����������ƵԴ������
        AudioManager.Instance.UpdateAllAudioSources();
    }
}