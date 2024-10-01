using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamburgerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isOnGlass = false;
    private Transform glassTransform;

    [SerializeField][Range(100f, 500f)] float bounceForce = 300f;
    [SerializeField][Range(0.1f, 2f)] float descentSpeed = 0.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 벽에 부딪힐 때 반사
        if (isOnGlass)
        {
            // 글래스 위에 있을 때 햄버거를 글래스와 같은 위치에 고정
            transform.position = new Vector3(glassTransform.position.x, glassTransform.position.y + 0.5f, transform.position.z);
        }

        // 내려오는 동안 천천히 하강
        if (rb.velocity.y < 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, -descentSpeed);
        }
    }

    public void Jump()
    {
        if (isOnGlass)
        {
            // 점프 시 위로 튕겨 나가기
            rb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
            isOnGlass = false; // 글래스에서 떨어짐
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("glass"))
        {
            // 글래스와 충돌 시 그 위로 올라가고 고정
            isOnGlass = true;
            glassTransform = collision.transform;
            rb.velocity = Vector2.zero; // 충돌 후 멈추기
        }
        //else if (collision.gameObject.CompareTag("Wall"))
        //{
        //    // 벽과 충돌 시 튕겨 나가기
        //    rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
        //}
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // 햄버거가 화면 밖으로 나가지 않도록 제한
        if (other.gameObject.CompareTag("Boundary"))
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8f, 8f), transform.position.y, transform.position.z);
        }
    }
}
