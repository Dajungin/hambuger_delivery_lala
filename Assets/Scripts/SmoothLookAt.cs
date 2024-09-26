using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothLookAt : MonoBehaviour
{
    //카메라가 따라다닐 대상
    Transform target;
    //부드러움의 강도
    float smooth = 0.25f;

    Vector2 velocity = Vector2.zero;

    void Start()
    {
        target = GameObject.Find("character").transform;
    }

    //RigidBody2d 점프를 따라 이동할것이기 때문에 FixedUpdate를 사용
    private void FixedUpdate()
    {
        Vector2 smoothPos = Vector2.SmoothDamp(transform.position, target.position, ref velocity, smooth);
        transform.position = new Vector3(0, smoothPos.y, -10);
    }
}
