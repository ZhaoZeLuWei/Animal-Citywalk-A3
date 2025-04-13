using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneRestarter : MonoBehaviour
{
    // 绑定到Again按钮的点击事件
    public void RestartScene()
    {
        // 确保时间流速恢复正常
        Time.timeScale = 1;

        // 获取当前场景名称
        string currentSceneName = "Train station"; // 直接指定场景名称更可靠

        // 重新加载场景
        SceneManager.LoadScene(currentSceneName, LoadSceneMode.Single);

        // 可选：清除玩家偏好设置（如果需要）
        // PlayerPrefs.DeleteAll();
    }
}