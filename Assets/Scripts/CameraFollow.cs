using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // 플레이어를 따라가는 변수
    public float smoothSpeed = 0.125f; // 부드러운 카메라 이동 속도
    private Vector3 offset; // 카메라의 초기 오프셋

    void Start()
    {
        offset = transform.position - player.position; // 초기 오프셋 계산
    }

    void LateUpdate()
    {
        // 플레이어의 Y좌표만 따라감, X좌표는 고정
        Vector3 targetPosition = new Vector3(transform.position.x, player.position.y + offset.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
    }
}
