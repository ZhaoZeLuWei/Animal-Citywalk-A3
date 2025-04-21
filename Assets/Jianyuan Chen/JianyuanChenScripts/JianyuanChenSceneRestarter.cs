using UnityEngine;
using UnityEngine.SceneManagement;

public class JianyuanChenSceneRestarter : MonoBehaviour
{

    private string currentSceneName = "Train station"; // ��ǰ�������ƣ�����ʵ�ʳ�������һ�£�

    // �󶨵�Again��ť�ĵ���¼�
    public void RestartScene()
    {
        // ȷ��ʱ�����ٻָ�����
        Time.timeScale = 1;
        // ����������������¼�
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(currentSceneName, LoadSceneMode.Single);      // ���¼��س���

        // ��ѡ��������ƫ�����ã������Ҫ��
        // PlayerPrefs.DeleteAll();
    }

    // ����������ɺ�Ļص�
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == currentSceneName)
        {
            // ���²���BGM
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.RestartBGM();
            }

            // �Ƴ��¼������������ظ�����
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }

}