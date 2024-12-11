using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //public float speed; //�ӵ� ����
    [SerializeField][Header("�̵��Ÿ�")][Range(1f, 10f)] float dist = 7f;
    [SerializeField][Header("�̵��ӵ�")][Range(1f, 50f)] float speed = 5f;
    [SerializeField][Header("�ĵ���")][Range(1f, 40f)] float frequency = 20f;
    [SerializeField][Header("�ĵ�����")][Range(0.0f, 4f)] float waveHeight = 0.5f;

    Vector3 pos, localScale;
    bool dirRight = true;

    AudioSource hit; //����� ����
    public AudioClip hits; //����� �ִ� ����

    private void Awake()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.CompareTag("glass")) //Player �±׸� ���� ��ü
        if (collision.gameObject.CompareTag("Player")) //Player �±׸� ���� ��ü
        {
            GameObject.Find("crash").GetComponent< AudioSource >().Play();
            //hit.Play();

            Destroy(this.gameObject); //�ε��� �� ������� �ϴ� �ڵ� 
                                      //Destroy(collision.gameObject);
                                      //hit.PlayOneShot(hits); //���� ���� 
            
        }

    }

    public virtual void Move()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        localScale = transform.localScale;

        hit = GetComponent<AudioSource>();
    }



    // Update is called once per frame
    void Update()
    {
        if(transform.position.x>dist) 
            dirRight = false;
        else if(transform.position.x<-dist) 
            dirRight = true;

        if (dirRight)
            GoRight();
        else
            GoLeft();
    }

    void GoRight()
    {
        localScale.x = 3;// 1;
        transform.transform.localScale = localScale;
        pos += transform.right * Time.deltaTime * speed;
        transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency) * waveHeight;
    }

    void GoLeft()
    {
        localScale.x = -3;// -1 ;
        transform.transform.localScale = localScale;
        pos -= transform.right * Time.deltaTime * speed;
        transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency) * waveHeight;
    }


}
