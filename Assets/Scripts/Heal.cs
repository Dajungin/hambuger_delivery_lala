using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public float speed; //�ӵ� ����
    AudioSource h; //����� ����
    public AudioClip hi; //����� �ִ� ����

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.CompareTag("glass")) //Player �±׸� ���� ��ü
        if (collision.gameObject.CompareTag("Player")) //Player �±׸� ���� ��ü
        {
            //h.PlayOneShot(hi); //���� ����
            //h.Play();
            GameObject.Find("heal").GetComponent<AudioSource>().Play();

            Destroy(this.gameObject); //�ε��� �� ������� �ϴ� �ڵ� 

                  //
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        h = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
