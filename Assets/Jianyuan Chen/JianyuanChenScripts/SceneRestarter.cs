using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneRestarter : MonoBehaviour
{
    // �󶨵�Again��ť�ĵ���¼�
    public void RestartScene()
    {
        // ȷ��ʱ�����ٻָ�����
        Time.timeScale = 1;

        // ��ȡ��ǰ��������
        string currentSceneName = "Train station"; // ֱ��ָ���������Ƹ��ɿ�

        // ���¼��س���
        SceneManager.LoadScene(currentSceneName, LoadSceneMode.Single);

        // ��ѡ��������ƫ�����ã������Ҫ��
        // PlayerPrefs.DeleteAll();
    }
}