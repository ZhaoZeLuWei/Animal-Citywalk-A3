using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(AudioSource))] // 确保自动添加组件
public class ButtonClickSound : MonoBehaviour
{
    public AudioClip sound; // 拖入你的click-151673文件

    private AudioSource _source;

    void Start()
    {
        // 安全获取组件
        _source = GetComponent<AudioSource>();
        _source.playOnAwake = false;
        _source.clip = sound;

        // 可靠的事件绑定方式
        GetComponent<Button>().onClick.AddListener(OnButtonClick);
    }

    // 专为Unity事件面板设计的公开方法
    public void OnButtonClick()
    {
        if (_source != null && sound != null)
        {
            _source.PlayOneShot(sound);
        }
    }
}