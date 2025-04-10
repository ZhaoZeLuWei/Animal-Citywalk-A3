using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    public AudioSource audioSource; // ������ƵԴ

    void Start()
    {
        // ��ȡ��ť�������ӵ���¼�
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        // ������Ч
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}



