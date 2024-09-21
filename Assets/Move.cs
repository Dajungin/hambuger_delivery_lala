using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f; // 캐릭터 이동 속도
    private float fixedY = 10f; // 고정된 Y 좌표 값

    void Start()
    {
        // 물체의 현재 위치를 읽고 Y 좌표를 10으로 설정
        Vector3 currentPosition = transform.position;
        currentPosition.y = fixedY; // Y 좌표를 10으로 고정
        transform.position = currentPosition; // 물체의 위치 갱신
    }

    void Update()
    {
        // 터치 입력 처리
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // 터치한 위치를 월드 좌표로 변환
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.y = fixedY; // Y 좌표 고정 (10)

            // 터치한 위치로 부드럽게 이동
            transform.position = Vector2.Lerp(transform.position, new Vector2(touchPosition.x, fixedY), Time.deltaTime * speed);
        }
        // 마우스 입력 처리
        else if (Input.GetMouseButton(0)) // 마우스 왼쪽 버튼 클릭 시
        {
            // 마우스 클릭한 위치를 월드 좌표로 변환
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.y = fixedY; // Y 좌표 고정 (10)

            // 마우스 위치로 부드럽게 이동
            transform.position = Vector2.Lerp(transform.position, new Vector2(mousePosition.x, fixedY), Time.deltaTime * speed);
        }
    }
}
