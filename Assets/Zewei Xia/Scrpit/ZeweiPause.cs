using UnityEngine;

public class ZeweiPause : MonoBehaviour
{
    // 暂停场景（绑定到暂停按钮）
    public void PauseEntireScene()
    {
        Time.timeScale = 0;
        AudioListener.pause = true; // 暂停所有音频

    }

    // 恢复场景（绑定到继续按钮）
    public void ResumeEntireScene()
    {
        Time.timeScale = 1;
        AudioListener.pause = false; // 恢复音频

    }


}