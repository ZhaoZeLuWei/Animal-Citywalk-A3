using UnityEngine;
using UnityEngine.SceneManagement; // 

public class JianyuanChenSceneLoader : MonoBehaviour
{
    //
    public void LoadMenuScene()
    {
        // 
        SceneManager.LoadScene("Menu");
    }
    public void LoadSecondScene()
    {
        Time.timeScale = 1;
        // 
        SceneManager.LoadScene("XiaohanLiSences");
    }
}