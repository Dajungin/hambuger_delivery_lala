using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fall : MonoBehaviour
{
    public Transform player; // ĳ������ Transform
    public GameObject fallPanel; // GameOver UI �г�
    private float distanceBelowPlayer = 15; // ĳ���Ϳ� GameOver â ������ �Ÿ� 20
    private float previousPlayerY; // ���� �������� ĳ���� Y ��ǥ

    Rigidbody2D rb;
    Collider2D fallCollider;
    float moveX;
    bool falls = false; //�ִϸ��̼� bool Ȯ��
    Animator anim; //�ִϸ��̼� ����
    int fallLayer;
    private Transform originalParent;

    void Start()
    {
        // fall ó������ Ȱ��ȭ
        fallPanel.SetActive(true);

        // ���� �� ĳ������ Y��ǥ�� ���
        previousPlayerY = player.position.y;

        anim = GetComponent<Animator>(); //�ִϸ��̼� 
        rb = GetComponent<Rigidbody2D>();

        fallCollider = GetComponent<BoxCollider2D>();
        fallLayer = LayerMask.NameToLayer("fall");

    }



    void Update()
    {
        // ĳ���Ͱ� ���� �����Ӻ��� ���� �̵����� ���� GameOver â�� ��ġ�� ������Ʈ
        if (player.position.y > previousPlayerY)
        {
            // GameOver â�� �׻� ĳ������ Y��ǥ �Ʒ� 13��ŭ ��ġ�ϰ� ����
            Vector3 newPos = fallPanel.transform.position;
            newPos.y = player.position.y - distanceBelowPlayer;
            fallPanel.transform.position = newPos;
        }

        // ���� �������� ĳ���� Y��ǥ�� ������ ���� �����Ӱ� ��
        previousPlayerY = player.position.y;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("fall"))
        {

            anim.SetBool("falls", true);//�ִϸ��̼� ���� üũ
            // ������ �浹 �ڽ� ��Ȱ��ȭ
            fallCollider.enabled = false;
            // ���� �ð� �� �浹 �ڽ� �ٽ� Ȱ��ȭ (0.2�� ��)
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
