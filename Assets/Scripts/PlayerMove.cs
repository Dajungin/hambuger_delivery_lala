using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 6.0f; // 캐릭터 이동 속도
    public float riseAmount = 5.0f; // Y좌표 상승값
    public float riseSpeed = 5.0f; // 위로 올라가는 속도
    private Animator animator;
    private Rigidbody2D rb; // Rigidbody2D 변수
    private bool isRising = false; // Y좌표 상승 중인지 확인하는 플래그
    private Vector2 screenBounds; // 화면 경계 값 저장
 private GameObject hamburger; // 충돌한 햄버거 오브젝트를 저장할 변수
 float moveX;
 
 [SerializeField] [Range(100f, 800f)] float movespeed=400f;
 [SerializeField] [Range(100f, 800f)] float jumpForce = 500f;
 
 
 int playerLayer, CloudeLayer; //플레이어와 구름 레이어를 저장할 변수

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D 컴포넌트 가져오기
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

       //레이어 가져오기
       playerLayer = LayerMask.NameToLayer("Player");
       CloudeLayer = LayerMask.NameToLayer("Cloude");

    }

    void Update()
    {
        // 마우스 입력 처리
        if (Input.GetMouseButton(0)) // 마우스 왼쪽 버튼이 눌렸을 때
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // 마우스의 화면 좌표를 월드 좌표로 변환
            MoveToPosition(mousePosition.x); // X 좌표에 따라 이동
        }

     ClampPosition(); // 화면 밖으로 나가지 않게 위치 제한
      moveX = Input.GetAxis("Horizontal") * movespeed * Time.deltaTime;
      rb.velocity = new Vector2(moveX, rb.velocity.y);
    
      if(Input.GetButtonDown("Jump"))
      {
          if (rb.velocity.y == 0)
              rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Force);
      }
    
      if(rb.velocity.y > 0)
      {
          Physics2D.IgnoreLayerCollision(playerLayer, CloudeLayer, true);
      }
      else
          Physics2D.IgnoreLayerCollision(playerLayer, CloudeLayer, false);
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
      // 플레이어가 햄버거와 충돌했을 때 햄버거를 저장
   // if (collision.gameObject.CompareTag("hamburger") && !isRising)
   // {
   //     hamburger = collision.gameObject; // 햄버거 오브젝트 저장
   // }
     
         //충돌한 물체가 "Cloude" 태그를 가지고 있을 때
        if (collision.gameObject.CompareTag("Cloude") && !isRising)
        {
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

       //    // 만약 햄버거가 존재하면 햄버거도 같이 상승
       //    if (hamburger != null)
       //    {
       //        hamburger.transform.position = Vector2.MoveTowards(hamburger.transform.position, new Vector2(hamburger.transform.position.x, hamburger.transform.position.y + riseAmount), riseSpeed * Time.deltaTime);
       //    }

            yield return null; // 다음 프레임까지 대기
        }

        rb.gravityScale = 1;
        rb.velocity = new Vector2(0, -0.1f); // 자연스럽게 떨어지게 함

        isRising = false; // Y좌표 상승 완료
    }

    // 화면 밖으로 나가지 않게 위치 제한하는 함수 (X 좌표만 제한)
    private void ClampPosition()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -screenBounds.x + 0.5f, screenBounds.x - 0.5f); // X 좌표를 화면 안으로 제한
        transform.position = pos;
    }
}
