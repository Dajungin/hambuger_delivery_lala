using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    public Transform player; // ĳ������ Transform
    public GameObject fallPanel; // GameOver UI �г�
    private float distanceBelowPlayer = 15f; // ĳ���Ϳ� GameOver â ������ �Ÿ�
    private float previousPlayerY; // ���� �������� ĳ���� Y ��ǥ

    private Rigidbody2D rb;
    private Collider2D fallCollider;
    private Animator anim; // �ִϸ��̼� ����

    void Start()
    {
        // fallPanel ó������ Ȱ��ȭ
        //fallPanel.SetActive(true);

        // ���� �� ĳ������ Y��ǥ�� ���
        previousPlayerY = player.position.y;

        // ������Ʈ �ʱ�ȭ
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        fallCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        /*
        // ĳ���Ͱ� ���� �����Ӻ��� ���� �̵����� ���� GameOver â�� ��ġ�� ������Ʈ
        if (player.position.y > previousPlayerY)
        {
            Vector3 newPos = fallPanel.transform.position;
            newPos.y = player.position.y - distanceBelowPlayer;
            fallPanel.transform.position = newPos;
        }

        // ���� �������� ĳ���� Y��ǥ�� ������ ���� �����Ӱ� ��
        previousPlayerY = player.position.y;
        */
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("fall"))
        {
            // �ִϸ��̼� Ȱ��ȭ
            anim.SetBool("falls", true);

            // �浹 �ڽ� ��Ȱ��ȭ
            fallCollider.enabled = false;

            // ���� �ð� �� �浹 �ڽ� �ٽ� Ȱ��ȭ (0.2�� ��)
            //Invoke("EnableFallCollider", 0.2f);
        }
    }

    // �浹 �ڽ��� �ٽ� Ȱ��ȭ�ϴ� �Լ�
    void EnableFallCollider()
    {
        fallCollider.enabled = true;
        anim.SetBool("falls", false);
    }
}
