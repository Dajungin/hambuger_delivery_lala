using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fall : MonoBehaviour
{
    public Transform player; // 캐릭터의 Transform
    public GameObject fallPanel; // GameOver UI 패널
    private float distanceBelowPlayer = 15; // 캐릭터와 GameOver 창 사이의 거리 20
    private float previousPlayerY; // 이전 프레임의 캐릭터 Y 좌표

    Rigidbody2D rb;
    Collider2D fallCollider;
    float moveX;
    bool falls = false; //애니메이션 bool 확인
    Animator anim; //애니메이션 변수
    int fallLayer;
    private Transform originalParent;

    void Start()
    {
        // fall 처음부터 활성화
        fallPanel.SetActive(true);

        // 시작 시 캐릭터의 Y좌표를 기록
        previousPlayerY = player.position.y;

        anim = GetComponent<Animator>(); //애니메이션 
        rb = GetComponent<Rigidbody2D>();

        fallCollider = GetComponent<BoxCollider2D>();
        fallLayer = LayerMask.NameToLayer("fall");

    }



    void Update()
    {
        // 캐릭터가 이전 프레임보다 위로 이동했을 때만 GameOver 창의 위치를 업데이트
        if (player.position.y > previousPlayerY)
        {
            // GameOver 창이 항상 캐릭터의 Y좌표 아래 13만큼 위치하게 설정
            Vector3 newPos = fallPanel.transform.position;
            newPos.y = player.position.y - distanceBelowPlayer;
            fallPanel.transform.position = newPos;
        }

        // 현재 프레임의 캐릭터 Y좌표를 저장해 다음 프레임과 비교
        previousPlayerY = player.position.y;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("fall"))
        {

            anim.SetBool("falls", true);//애니메이션 점프 체크
            // 구름의 충돌 박스 비활성화
            fallCollider.enabled = false;
            // 일정 시간 후 충돌 박스 다시 활성화 (0.2초 뒤)
            Invoke("EnableCloundCollider", 0.2f);
            gameObject.GetComponent<BoxCollider>().enabled = false;
            
        }

    }
    public void HideGameOverPanel()
    {
        fallCollider.enabled = true;
        anim.SetBool("falls", false);
    }
}
