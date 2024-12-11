using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //public float speed; //속도 변수
    [SerializeField][Header("이동거리")][Range(1f, 10f)] float dist = 7f;
    [SerializeField][Header("이동속도")][Range(1f, 50f)] float speed = 5f;
    [SerializeField][Header("파동빈도")][Range(1f, 40f)] float frequency = 20f;
    [SerializeField][Header("파동높이")][Range(0.0f, 4f)] float waveHeight = 0.5f;

    Vector3 pos, localScale;
    bool dirRight = true;

    AudioSource hit; //오디오 변수
    public AudioClip hits; //오디오 넣는 변수

    private void Awake()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.CompareTag("glass")) //Player 태그를 가진 물체
        if (collision.gameObject.CompareTag("Player")) //Player 태그를 가진 물체
        {
            GameObject.Find("crash").GetComponent< AudioSource >().Play();
            //hit.Play();

            Destroy(this.gameObject); //부딪힐 시 사라지게 하는 코드 
                                      //Destroy(collision.gameObject);
                                      //hit.PlayOneShot(hits); //음악 시작 
            
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
