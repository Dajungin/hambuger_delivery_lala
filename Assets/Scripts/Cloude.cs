using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cloude : MonoBehaviour
{
    Rigidbody2D rb;
    Collider2D playerCollider;
    Collider2D CloundCollider;
    float moveX;
    bool Jump = false; //애니메이션 bool 확인
    Animator anim; //애니메이션 변수


    int  CloudLayer;


    private Transform originalParent;

    void Start()
    {
        anim = GetComponent<Animator>(); //애니메이션 
        rb = GetComponent<Rigidbody2D>();

        CloundCollider = GetComponent<BoxCollider2D>();
        CloudLayer = LayerMask.NameToLayer("Cloud");

    }


    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            anim.SetBool("Jump", true);//애니메이션 점프 체크
            // 구름의 충돌 박스 비활성화
            CloundCollider.enabled = false;
            // 일정 시간 후 충돌 박스 다시 활성화 (0.8초 뒤)
            Invoke("EnableCloundCollider", 0.8f);


        }

    }

    void EnableCloundCollider()
    {
        CloundCollider.enabled = true;
        anim.SetBool("Jump", false);
    }
}
