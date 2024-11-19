using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Collider2D playerCollider;
    Collider2D CloundCollider;
    float moveX;
    //bool Jump = false; //애니메이션 bool 확인
    Animator anim; //애니메이션 변수
    AudioSource jump; //오디오 변수
    public AudioClip jumps; //오디오 넣는 변수


    [SerializeField][Range(100f, 800f)] float moveSpeed = 400f; //움직이는 속도
    [SerializeField][Range(100f, 800f)] float jumpFoce = 400f; //점프 높이

    int playerLayer, CloudLayer;


    private Transform originalParent;

    void Start()
    {
        anim = GetComponent<Animator>(); //애니메이션 
        rb = GetComponent<Rigidbody2D>();


        playerCollider = GetComponent<BoxCollider2D>();
        CloundCollider = GetComponent<BoxCollider2D>();


        playerLayer = LayerMask.NameToLayer("Player");
        CloudLayer = LayerMask.NameToLayer("Cloud");

        jump = GetComponent<AudioSource>();
    }

    IEnumerator SetGravitiy()
    {
        yield return new WaitForSeconds(2f);

        rb.gravityScale = 1f;
    }

    public void SetInitPlayerGravity()
    {
        rb.gravityScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;

        //Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
            if (hit)
            {
                switch (hit.collider.gameObject.name)
                {
                    case "glass":
                        {
                            rb.gravityScale = 1f;
                        }
                        break;
                }
                //Debug.Log(hit.collider.gameObject.name);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Cloud"))
        {
            rb.velocity = Vector2.zero;


            rb.AddForce(Vector2.up * jumpFoce, ForceMode2D.Force);
            jump.PlayOneShot(jumps); //음악 시작 

           // anim.SetBool("Jump", true);//애니메이션 점프 체크
            // 구름의 충돌 박스 비활성화
            CloundCollider.enabled = false;

            // 일정 시간 후 충돌 박스 다시 활성화 (0.8초 뒤)
            Invoke("EnableCloundCollider", 0.8f);
        }
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.SetActive(false);
        }

    }


    void EnableCloundCollider()
    {
        CloundCollider.enabled = true;
    }
}
