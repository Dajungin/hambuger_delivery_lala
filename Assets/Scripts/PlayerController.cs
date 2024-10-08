using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Collider2D playerCollider;
    float moveX;

    [SerializeField][Range(100f, 800f)] float moveSpeed =400f; //움직이는 속도
    [SerializeField][Range(100f, 800f)] float jumpFoce = 400f; //점프 높이

    int playerLayer, CloudLayer;


    private Transform originalParent;

    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();

        playerLayer = LayerMask.NameToLayer("Player");
        CloudLayer = LayerMask.NameToLayer("Cloud");
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
        // rb.velocity = new Vector3(moveX, rb.velocity.y);
        //
        // if(rb.velocity.y > 0)
        // {
        //     Physics2D.IgnoreLayerCollision(playerLayer, CloudLayer, true);
        // }
        // else
        //     Physics2D.IgnoreLayerCollision(playerLayer, CloudLayer, false);
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Cloud"))
        {
            Debug.Log("addada");

            rb.AddForce(Vector2.up * jumpFoce, ForceMode2D.Force);

            // 플레이어의 충돌 박스 비활성화
            playerCollider.enabled = false;

            // 일정 시간 후 충돌 박스 다시 활성화 (0.8초 뒤)
            Invoke("EnablePlayerCollider", 0.8f);
        }

        if(collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.SetActive(false);
        }

        
    }
    void EnablePlayerCollider()
    {
        playerCollider.enabled = true;
    }
}
