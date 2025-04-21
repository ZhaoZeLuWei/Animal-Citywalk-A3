using UnityEngine;

public class SoundControlButtons : MonoBehaviour
{
    // �󶨵�"�ر�����"��ť�ĵ���¼�
    public void OnMuteButtonClicked()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.MuteAll();
        }
    }

    // �󶨵�"������"��ť�ĵ���¼�
    public void OnUnmuteButtonClicked()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.UnmuteAll();
        }
    }
}