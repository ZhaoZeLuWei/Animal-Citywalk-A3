using UnityEngine;

public class JianyuanChenScenePauseController : MonoBehaviour
{

    public AudioSource bgmAudioSource;
    // ‘›Õ£≥°æ∞£®∞Û∂®µΩ‘›Õ£∞¥≈•£©
    public void PauseEntireScene()
    {
        Time.timeScale = 0;
        //AudioListener.pause = true; // ‘›Õ£À˘”–“Ù∆µ

        // ‘›Õ£ BGM
        if (bgmAudioSource != null && bgmAudioSource.isPlaying)
        {
            bgmAudioSource.Pause();
        }

    }

    // ª÷∏¥≥°æ∞£®∞Û∂®µΩºÃ–¯∞¥≈•£©
    public void ResumeEntireScene()
    {
        Time.timeScale = 1;
        // AudioListener.pause = false; // ª÷∏¥“Ù∆µ

        // ª÷∏¥ BGM
        if (bgmAudioSource != null && !bgmAudioSource.isPlaying)
        {
            bgmAudioSource.UnPause();
        }

    }


}