using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public float speed; //�ӵ� ����


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("glass")) //Player �±׸� ���� ��ü
        {

            Destroy(this.gameObject); //�ε��� �� ������� �ϴ� �ڵ� 
                                      

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
