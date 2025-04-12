using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;        // 拖拽指定玩家对象
    public float smoothSpeed = 0.1f; // 平滑移动系数（0-1）

    private Vector3 initialOffset;   // 初始位置偏移
    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        // 记录初始相对位置关系
        initialOffset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        // 计算目标位置（保持初始相对位置）
        Vector3 targetPosition = player.transform.position + initialOffset;

        // 仅平滑移动位置（不修改旋转）
        transform.position = Vector3.SmoothDamp(
            current: transform.position,
            target: targetPosition,
            currentVelocity: ref velocity,
            smoothTime: smoothSpeed);
    }

}