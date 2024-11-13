using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Enemy    //Enemy 기능을 가져오기 위해 상속 받았다.
{
    // Start is called before the first frame update
    void Start()
    {
       // Move();
    }

    public override void Move()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.right * 50); //오른쪽으로 이동
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
