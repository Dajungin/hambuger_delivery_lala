using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 10.0f; // 캐릭터 이동 속도
    public float riseAmount = 10.0f; // Y좌표 상승값
    public float riseSpeed = 5.0f; // 위로 올라가는 속도
    private Animator animator;
    private Rigidbody2D rb; // Rigidbody2D 변수
    private bool isRising = false; // Y좌표 상승 중인지 확인하는 플래그
    private bool isTouching = false; // 터치 중인지 확인하는 플래그

    private Vector2 savedPosition; // 좌표 저장 변수

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D 컴포넌트 가져오기
        savedPosition = transform.position; // 시작할 때 위치 저장
    }

    void Update()
    {
        Debug.Log(Screen.width);
        Debug.Log(Screen.height);

        // 터치 입력 처리
        if (Input.touchCount > 0)
        {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            MoveToPosition(touchPosition.x);
        }
        // 마우스 입력 처리
        else if (Input.GetMouseButton(0)) // 마우스 왼쪽 버튼이 눌렸을 때
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // 마우스의 화면 좌표를 월드 좌표로 변환
            MoveToPosition(mousePosition.x); // X 좌표에 따라 이동
        }
        else
        {
            // 애니메이션 상태를 멈추고 마지막 위치에 머무름
            isTouching = false;
            animator.SetBool("RunStart", false);
        }

        SavePosition(); // 이동할 때마다 좌표 저장
    }

    // X 좌표에 따라 캐릭터 이동하는 함수
    private void MoveToPosition(float targetX)
    {
        if (!isRising) // 점프 중이 아닐 때만 이동
        {
            float direction = targetX - transform.position.x;
            if (Mathf.Abs(direction) > 0.1f) // 최소 이동량 설정
            {
                rb.velocity = new Vector2(Mathf.Sign(direction) * speed, rb.velocity.y); // 방향에 따라 이동
                animator.SetBool("RunStart", true);
                transform.localScale = new Vector2(Mathf.Sign(direction), 1); // 방향에 따라 캐릭터 스케일 변경
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y); // 너무 가까우면 멈춤
            }
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

    // Y좌표를 부드럽게 10만큼 올리는 코루틴 (중력 비활성화 포함)
    IEnumerator RiseUp()
    {
        isRising = true; // Y좌표 상승 중임을 표시
        rb.gravityScale = 0; // 중력 비활성화
        rb.velocity = Vector2.zero; // Y축 이동 시 속도 초기화

        Vector2 targetPosition = new Vector2(transform.position.x, transform.position.y + riseAmount); // 목표 위치

        while (transform.position.y < targetPosition.y)
        {
            // 현재 위치에서 목표 위치까지 부드럽게 이동
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, riseSpeed * Time.deltaTime);
            yield return null; // 다음 프레임까지 대기
        }

        // 중력 다시 활성화 후, 점프가 끝난 후 바로 떨어질 수 있게 속도 설정
        rb.gravityScale = 1;
        rb.velocity = new Vector2(0, -0.1f); // 가벼운 중력 효과를 주어 자연스럽게 떨어지게 함

        isRising = false; // Y좌표 상승 완료
    }

    // 현재 좌표를 저장하는 함수
    private void SavePosition()
    {
        savedPosition = transform.position; // 현재 위치 저장
        Debug.Log("Saved Position: " + savedPosition); // 디버그로 확인 가능
    }
}
