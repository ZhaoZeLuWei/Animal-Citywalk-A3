using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;        // ��קָ����Ҷ���
    public float smoothSpeed = 0.1f; // ƽ���ƶ�ϵ����0-1��

    private Vector3 initialOffset;   // ��ʼλ��ƫ��
    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        // ��¼��ʼ���λ�ù�ϵ
        initialOffset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        // ����Ŀ��λ�ã����ֳ�ʼ���λ�ã�
        Vector3 targetPosition = player.transform.position + initialOffset;

        // ��ƽ���ƶ�λ�ã����޸���ת��
        transform.position = Vector3.SmoothDamp(
            current: transform.position,
            target: targetPosition,
            currentVelocity: ref velocity,
            smoothTime: smoothSpeed);
    }

}