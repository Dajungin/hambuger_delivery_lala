using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed; //속도 변수
    private Life gameDirector;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("glass")) //Player 태그를 가진 물체
        {
           
            Destroy(this.gameObject); //부딪힐 시 사라지게 하는 코드 
            //Destroy(collision.gameObject);
            this.gameDirector.AddScore(1);
            
        }
      
    }

    public virtual void Move()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        this.gameDirector=GameObject.Find("lifes").GetComponent<Life>();
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
