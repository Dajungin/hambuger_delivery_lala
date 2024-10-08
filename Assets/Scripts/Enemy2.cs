using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        Move();
    }

    public override void Move()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.left * 50); //왼쪽으로 이동
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
