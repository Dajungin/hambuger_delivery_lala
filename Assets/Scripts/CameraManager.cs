using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform playerTransform; // 플레이어의 위치를 참조
    public float xFixedPosition = 0f; // 카메라의 고정된 X좌표 값

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform != null)
        {
            // 카메라의 X좌표는 고정하고, Y좌표는 플레이어의 Y좌표를 따름
            Vector3 newPosition = new Vector3(xFixedPosition, playerTransform.position.y, transform.position.z);

            // 새로운 카메라 위치 설정
            transform.position = newPosition;

            //카메라 밖으로 캐릭터 이탈 금지
            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

            if (pos.x < 0f) pos.x = 0f;
            if (pos.x > 1f) pos.x = 1f;
            if (pos.y < 0f) pos.y = 0f;
            if (pos.y > 1f) pos.y = 1f;

            transform.position = Camera.main.ViewportToWorldPoint(pos);
        }
    }
}
