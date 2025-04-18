using UnityEngine;

public class XiaohanLi_PickupSound : MonoBehaviour
{
    // 定义拾取音效
    public AudioClip pickupSound;

    private AudioSource audioSource;

    private void Start()
    {
        // 获取或添加 AudioSource 组件
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // 订阅事件
        XiaohanLi_ItemPickup.OnItemPickedUp += PlayPickupSound;
    }

    private void PlayPickupSound()
    {
        // 播放拾取音效
        if (pickupSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(pickupSound);
        }
    }

    private void OnDestroy()
    {
        // 取消订阅事件，防止内存泄漏
        XiaohanLi_ItemPickup.OnItemPickedUp -= PlayPickupSound;
    }
}
