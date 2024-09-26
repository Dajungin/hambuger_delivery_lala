using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Unit : MonoBehaviour
{
    UNIT_STATE state = UNIT_STATE.IDLE;

    Rigidbody2D rigid;
    Collider2D collid;

    float yDir = 0;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        collid = GetComponent<Collider2D>();

        yDir = transform.position.y;
    }

    private void Update()
    {
        if (state == UNIT_STATE.JUMP)
        {
            var y = transform.position.y;
            if (y < yDir)
            {
                collid.enabled = true;
            }
            yDir = y;
        }
    }

    public void Jump(float _jumpHeight)
    {
        Debug.Log("jump");

        if (rigid == null || collid == null) return;

        state = UNIT_STATE.JUMP;
        collid.enabled = false;
        yDir = transform.position.y;

        var g = Physics.gravity.magnitude;  // get the gravity value
        var vSpeed = Mathf.Sqrt(2 * g * _jumpHeight); // calculate the vertical speed
        rigid.velocity = new Vector2(0, vSpeed); // launch the projectile!
    }

    public void SetUnitState(UNIT_STATE _state)
    {
        state = _state;
    }
    public UNIT_STATE GetUnitState { get { return state; } }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        state = UNIT_STATE.IDLE;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {

    }
}
