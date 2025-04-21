using UnityEngine;
using UnityEngine.SceneManagement;

public class JianyuanChenSceneRestarter : MonoBehaviour
{

    private string currentSceneName = "Train station"; // 当前场景名称（需与实际场景名称一致）

    // 绑定到Again按钮的点击事件
    public void RestartScene()
    {
        // 确保时间流速恢复正常
        Time.timeScale = 1;
        // 监听场景加载完成事件
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(currentSceneName, LoadSceneMode.Single);      // 重新加载场景

        // 可选：清除玩家偏好设置（如果需要）
        // PlayerPrefs.DeleteAll();
    }

    // 场景加载完成后的回调
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == currentSceneName)
        {
            // 重新播放BGM
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.RestartBGM();
            }

            // 移除事件监听，避免重复触发
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }

}