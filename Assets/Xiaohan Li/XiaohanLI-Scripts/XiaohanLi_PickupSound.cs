using UnityEngine;

public class XiaohanLi_PickupSound : MonoBehaviour
{
    // ����ʰȡ��Ч
    public AudioClip pickupSound;

    private AudioSource audioSource;

    private void Start()
    {
        // ��ȡ����� AudioSource ���
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // �����¼�
        XiaohanLi_ItemPickup.OnItemPickedUp += PlayPickupSound;
    }

    private void PlayPickupSound()
    {
        // ����ʰȡ��Ч
        if (pickupSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(pickupSound);
        }
    }

    private void OnDestroy()
    {
        // ȡ�������¼�����ֹ�ڴ�й©
        XiaohanLi_ItemPickup.OnItemPickedUp -= PlayPickupSound;
    }
}
