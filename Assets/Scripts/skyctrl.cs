 using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class skyctrl : MonoBehaviour
{
    float speed = 0.03f;

    //ȭ�� ��ũ��
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float ofsX = speed * Time.time;
        transform.GetComponent<Renderer>().material.mainTextureOffset=new Vector2(ofsX, 0);
    }
}
