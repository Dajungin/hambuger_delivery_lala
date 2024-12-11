using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    public Transform player; // 캐릭터의 Transform
    public GameObject fallPanel; // GameOver UI 패널
    private float distanceBelowPlayer = 15f; // 캐릭터와 GameOver 창 사이의 거리
    private float previousPlayerY; // 이전 프레임의 캐릭터 Y 좌표

    private Rigidbody2D rb;
    private Collider2D fallCollider;
    private Animator anim; // 애니메이션 변수

    void Start()
    {
        // fallPanel 처음부터 활성화
        //fallPanel.SetActive(true);

        // 시작 시 캐릭터의 Y좌표를 기록
        previousPlayerY = player.position.y;

        // 컴포넌트 초기화
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        fallCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        /*
        // 캐릭터가 이전 프레임보다 위로 이동했을 때만 GameOver 창의 위치를 업데이트
        if (player.position.y > previousPlayerY)
        {
            Vector3 newPos = fallPanel.transform.position;
            newPos.y = player.position.y - distanceBelowPlayer;
            fallPanel.transform.position = newPos;
        }

        // 현재 프레임의 캐릭터 Y좌표를 저장해 다음 프레임과 비교
        previousPlayerY = player.position.y;
        */
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("fall"))
        {
            // 애니메이션 활성화
            anim.SetBool("falls", true);

            // 충돌 박스 비활성화
            fallCollider.enabled = false;

            // 일정 시간 후 충돌 박스 다시 활성화 (0.2초 뒤)
            //Invoke("EnableFallCollider", 0.2f);
        }
    }

    // 충돌 박스를 다시 활성화하는 함수
    void EnableFallCollider()
    {
        fallCollider.enabled = true;
        anim.SetBool("falls", false);
    }
}
