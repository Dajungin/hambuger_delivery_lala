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
    bool Jump = false; //�ִϸ��̼� bool Ȯ��
    Animator anim; //�ִϸ��̼� ����


    int  CloudLayer;


    private Transform originalParent;

    void Start()
    {
        anim = GetComponent<Animator>(); //�ִϸ��̼� 
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

            anim.SetBool("Jump", true);//�ִϸ��̼� ���� üũ
            // ������ �浹 �ڽ� ��Ȱ��ȭ
            CloundCollider.enabled = false;
            // ���� �ð� �� �浹 �ڽ� �ٽ� Ȱ��ȭ (0.8�� ��)
            Invoke("EnableCloundCollider", 0.8f);


        }

    }

    void EnableCloundCollider()
    {
        CloundCollider.enabled = true;
        anim.SetBool("Jump", false);
    }
}
