using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XiaohanLi_PauseController : MonoBehaviour
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
