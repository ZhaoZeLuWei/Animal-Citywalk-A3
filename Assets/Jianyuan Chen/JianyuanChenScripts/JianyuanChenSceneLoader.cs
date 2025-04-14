using UnityEngine;
using UnityEngine.SceneManagement; // 需要引用场景管理命名空间

public class JianyuanChenSceneLoader : MonoBehaviour
{
    // 点击按钮时触发的方法
    public void LoadMenuScene()
    {
        // 加载名为 "Menu" 的场景（确保场景名称与 Build Settings 中一致）
        SceneManager.LoadScene("Menu");
    }
    public void LoadSecondScene()
    {
        // 加载名为 "Menu" 的场景（确保场景名称与 Build Settings 中一致）
        SceneManager.LoadScene("XiaohanLiSences");
    }
}