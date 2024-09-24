using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float speed = 10.0f; // 캐릭터 이동 속도
    private Animator animator;
    private Rigidbody2D rb; // Player의 Rigidbody2D를 사용하기 위한 변수
    private bool isRising = false; // Y좌표 상승 중인지 확인하는 플래그
    private float riseSpeed = 5.0f; // 위로 올라가는 속도
    


    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D 컴포넌트 가져오기
      
    }

    void Update()
    {
        Debug.Log(Screen.width);
        Debug.Log(Screen.height);

        // 터치 입력 처리
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                Debug.Log("Ended - 손가락이 화면 위를 벗어나 떨어지게 된 그 순간, 터치가 끝난 상태: " + Input.GetTouch(0).position);

                if (Input.GetTouch(0).position.x > (Screen.width / 2))
                {
                    // 화면의 오른쪽을 터치한 경우 캐릭터가 오른쪽으로 이동
                    transform.Translate(speed * Time.deltaTime, 0, 0);
                    animator.SetBool("RunStart", false);
                    transform.localScale = new Vector2(1, 1); // 캐릭터가 오른쪽을 바라보게 설정
                }
                else
                {
                    // 화면의 왼쪽을 터치한 경우 캐릭터가 왼쪽으로 이동
                    transform.Translate(-speed * Time.deltaTime, 0, 0);
                    animator.SetBool("RunStart", false);
                    transform.localScale = new Vector2(-1, 1); // 캐릭터가 왼쪽을 바라보게 설정
                }
            }
        }

        // 마우스 입력 처리
        else if (Input.GetMouseButton(0)) // 마우스 왼쪽 버튼이 눌렸을 때
        {
            Vector3 mousePosition = Input.mousePosition;
            Debug.Log("Mouse Position: " + mousePosition);

            if (mousePosition.x > (Screen.width / 2))
            {
                // 화면의 오른쪽을 클릭한 경우 캐릭터가 오른쪽으로 이동
                transform.Translate(speed * Time.deltaTime, 0, 0);
                animator.SetBool("RunStart", false);
                transform.localScale = new Vector2(1, 1); // 캐릭터가 오른쪽을 바라보게 설정
            }
            else
            {
                // 화면의 왼쪽을 클릭한 경우 캐릭터가 왼쪽으로 이동
                transform.Translate(-speed * Time.deltaTime, 0, 0);
                animator.SetBool("RunStart", false);
                transform.localScale = new Vector2(-1, 1); // 캐릭터가 왼쪽을 바라보게 설정
            }
        }

        // 아무런 입력이 없을 때 (터치나 마우스 입력이 없을 경우)
        else
        {
            // 애니메이터의 상태를 변경 (필요에 따라 주석 해제 가능)
            // animator.SetBool("RunStart", true);
        }
    }

    // 충돌 감지 처리
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 충돌한 물체가 "Cloude" 태그를 가지고 있을 때
        if (collision.gameObject.CompareTag("Cloude") && !isRising)
        {
            // Y좌표 상승 코루틴 시작
            StartCoroutine(RiseUp());
        }
    }

    // Y좌표를 부드럽게 10만큼 올리는 코루틴
    IEnumerator RiseUp()
    {
        isRising = true; // Y좌표 상승 중임을 표시
        Vector2 targetPosition = new Vector2(transform.position.x, transform.position.y + 10); // 목표 위치
        while (transform.position.y < targetPosition.y)
        {
            // 현재 위치에서 목표 위치까지 부드럽게 이동
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, riseSpeed * Time.deltaTime);
            yield return null; // 다음 프레임까지 대기
        }

        rb.velocity = Vector2.zero; // Y좌표 상승이 끝나면 속도 초기화
        isRising = false; // Y좌표 상승 완료
    }
}
