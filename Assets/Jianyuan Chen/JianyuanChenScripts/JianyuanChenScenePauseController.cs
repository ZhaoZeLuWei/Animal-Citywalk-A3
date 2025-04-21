using UnityEngine;

public class JianyuanChenScenePauseController : MonoBehaviour
{

    public AudioSource bgmAudioSource;
    // ��ͣ�������󶨵���ͣ��ť��
    public void PauseEntireScene()
    {
        Time.timeScale = 0;
        //AudioListener.pause = true; // ��ͣ������Ƶ

        // ��ͣ BGM
        if (bgmAudioSource != null && bgmAudioSource.isPlaying)
        {
            bgmAudioSource.Pause();
        }

    }

    // �ָ��������󶨵�������ť��
    public void ResumeEntireScene()
    {
        Time.timeScale = 1;
        // AudioListener.pause = false; // �ָ���Ƶ

        // �ָ� BGM
        if (bgmAudioSource != null && !bgmAudioSource.isPlaying)
        {
            bgmAudioSource.UnPause();
        }

    }


}