using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    public AudioSource audioSource; // �������ǵ�10�еı���

    void Start()
    {
        if (audioSource != null)
        {
            audioSource.Play(); // ��ȫ����
        }
        else
        {
            Debug.LogError("AudioSourceδ��ȷ��ֵ��"); // ��ʾ����
        }
    }
}



