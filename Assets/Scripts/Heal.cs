using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public float speed; //속도 변수
    AudioSource h; //오디오 변수
    public AudioClip hi; //오디오 넣는 변수

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.CompareTag("glass")) //Player 태그를 가진 물체
        if (collision.gameObject.CompareTag("Player")) //Player 태그를 가진 물체
        {
            //h.PlayOneShot(hi); //음악 시작
            //h.Play();
            GameObject.Find("heal").GetComponent<AudioSource>().Play();

            Destroy(this.gameObject); //부딪힐 시 사라지게 하는 코드 

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
