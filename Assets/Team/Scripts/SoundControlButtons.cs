using UnityEngine;

public class SoundControlButtons : MonoBehaviour
{
    // 绑定到"关闭声音"按钮的点击事件
    public void OnMuteButtonClicked()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.MuteAll();
        }
    }

    // 绑定到"打开声音"按钮的点击事件
    public void OnUnmuteButtonClicked()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.UnmuteAll();
        }
    }
}