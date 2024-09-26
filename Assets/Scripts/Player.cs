using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    float moveX;

    [SerializeField][Range(100f, 800f)] float movespeed = 400f;
    [SerializeField][Range(100f, 800f)] float jumpForce = 500f;


    int playerLayer, CloudeLayer; //플레이어와 구름 레이어를 저장할 변수
     
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D 컴포넌트 가져오기
        //레이어 가져오기
        playerLayer = LayerMask.NameToLayer("Player");
        CloudeLayer = LayerMask.NameToLayer("Cloude");
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Horizontal") * movespeed * Time.deltaTime;
        rb.velocity = new Vector2(moveX, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            if (rb.velocity.y == 0)
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Force);
        }

        if (rb.velocity.y > 0)
        {
            Physics2D.IgnoreLayerCollision(playerLayer, CloudeLayer, true);
        }
        else
            Physics2D.IgnoreLayerCollision(playerLayer, CloudeLayer, false);
    }
}
