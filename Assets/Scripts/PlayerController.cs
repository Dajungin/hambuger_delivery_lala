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
    //bool Jump = false; //�ִϸ��̼� bool Ȯ��
    Animator anim; //�ִϸ��̼� ����
    AudioSource jump; //����� ����
    public AudioClip jumps; //����� �ִ� ����


    [SerializeField][Range(100f, 800f)] float moveSpeed = 400f; //�����̴� �ӵ�
    [SerializeField][Range(100f, 800f)] float jumpFoce = 400f; //���� ����

    int playerLayer, CloudLayer;


    private Transform originalParent;

    void Start()
    {
        anim = GetComponent<Animator>(); //�ִϸ��̼� 
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
            jump.PlayOneShot(jumps); //���� ���� 

           // anim.SetBool("Jump", true);//�ִϸ��̼� ���� üũ
            // ������ �浹 �ڽ� ��Ȱ��ȭ
            CloundCollider.enabled = false;

            // ���� �ð� �� �浹 �ڽ� �ٽ� Ȱ��ȭ (0.8�� ��)
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
