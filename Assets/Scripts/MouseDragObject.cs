using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MouseDragObject : MonoBehaviour
{ 
public float speed = 2f; // 플레이어 이동 속도 처음 10이었다. 

    void Update()
    {
        // 화면에 터치가 하나 이상 있을 때만 실행
        if (Input.touchCount > 0)
        {
            // 첫 번째 터치를 가져옴 (인덱스 0)
            Touch touch = Input.GetTouch(0);

            // 터치가 움직이거나 유지되고 있을 때만 실행
            if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                // 터치 위치를 화면 좌표에서 월드 좌표로 변환
                Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

                // X축 좌표는 터치 위치로, Y축은 현재 위치를 유지
                Vector2 newPosition = new Vector2(touchPosition.x, transform.position.y);

                // 선형 보간을 사용해 부드럽게 캐릭터를 이동 (선택 사항)
                transform.position = Vector2.Lerp(transform.position, newPosition, speed * Time.deltaTime);
            }
        }
    }
}