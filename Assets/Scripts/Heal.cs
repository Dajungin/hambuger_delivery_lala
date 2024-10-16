using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public float speed; //속도 변수


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("glass")) //Player 태그를 가진 물체
        {

            Destroy(this.gameObject); //부딪힐 시 사라지게 하는 코드 
                                      

        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
