using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    public AudioSource audioSource; // 引用音频源

    void Start()
    {
        // 获取按钮组件并添加点击事件
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        // 播放音效
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}



