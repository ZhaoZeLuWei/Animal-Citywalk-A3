using UnityEngine;
using UnityEngine.SceneManagement; // ��Ҫ���ó������������ռ�

public class JianyuanChenSceneLoader : MonoBehaviour
{
    // �����ťʱ�����ķ���
    public void LoadMenuScene()
    {
        // ������Ϊ "Menu" �ĳ�����ȷ������������ Build Settings ��һ�£�
        SceneManager.LoadScene("Menu");
    }
    public void LoadSecondScene()
    {
        Time.timeScale = 1;
        // ������Ϊ "Menu" �ĳ�����ȷ������������ Build Settings ��һ�£�
        SceneManager.LoadScene("XiaohanLiSences");
    }
}