using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(AudioSource))] // ȷ���Զ�������
public class ButtonClickSound : MonoBehaviour
{
    public AudioClip sound; // �������click-151673�ļ�

    private AudioSource _source;

    void Start()
    {
        // ��ȫ��ȡ���
        _source = GetComponent<AudioSource>();
        _source.playOnAwake = false;
        _source.clip = sound;

        // �ɿ����¼��󶨷�ʽ
        GetComponent<Button>().onClick.AddListener(OnButtonClick);
    }

    // רΪUnity�¼������ƵĹ�������
    public void OnButtonClick()
    {
        if (_source != null && sound != null)
        {
            _source.PlayOneShot(sound);
        }
    }
}