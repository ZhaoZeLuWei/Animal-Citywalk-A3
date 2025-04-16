using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    public AudioSource audioSource; // 假设这是第10行的变量

    void Start()
    {
        if (audioSource != null)
        {
            audioSource.Play(); // 安全调用
        }
        else
        {
            Debug.LogError("AudioSource未正确赋值！"); // 提示错误
        }
    }
}



