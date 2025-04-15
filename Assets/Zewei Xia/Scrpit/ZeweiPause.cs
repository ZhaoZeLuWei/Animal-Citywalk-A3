using UnityEngine;

public class ZeweiPause : MonoBehaviour
{
    // 暂停场景（绑定到暂停按钮）
    public void PauseEntireScene()
    {
        Time.timeScale = 0;

    }

    // 恢复场景（绑定到继续按钮）
    public void ResumeEntireScene()
    {
        Time.timeScale = 1;
    }


}