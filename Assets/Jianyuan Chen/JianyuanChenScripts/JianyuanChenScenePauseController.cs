using UnityEngine;

public class JianyuanChenScenePauseController : MonoBehaviour
{
    // ��ͣ�������󶨵���ͣ��ť��
    public void PauseEntireScene()
    {
        Time.timeScale = 0;
        AudioListener.pause = true; // ��ͣ������Ƶ

    }

    // �ָ��������󶨵�������ť��
    public void ResumeEntireScene()
    {
        Time.timeScale = 1;
        AudioListener.pause = false; // �ָ���Ƶ

    }


}