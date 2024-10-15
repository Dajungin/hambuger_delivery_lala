using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Life : MonoBehaviour
{
    public GameObject[] Hamburgers; 
    public int life; //현재 목숨
    public int Maxlife =6;//최대 목숨
   
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) //Enemy 태그를 가진 물체
        {
            life--;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        life = Maxlife; //처음은 최대 목숨으로 시작 

        UpdateLivesDisplay(); //모든 목숨 오브젝트를 활성화

    }


    // 목숨이 늘어날 때 호출되는 함수
    public void GainLife()
    {
        if (life < Maxlife)
        {
            life++;
            UpdateLivesDisplay();
        }
    }

    void UpdateLivesDisplay()
    {
        for (int i = 0; i < Hamburgers.Length; i++)
        {
            // 남은 목숨 수보다 적은 인덱스까지는 활성화, 그 이상은 비활성화
            //Hamburgers[i].SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        switch (life)
        {
            case 6:
                //SetLifeVisibility(6);
                //Hamburgers[0].SetActive(false);
                break;
            case 5:
                //SetLifeVisibility(5);
                Hamburgers[0].SetActive(false);
                break;
            case 4:
               // SetLifeVisibility(4);
                Hamburgers[1].SetActive(false);
                break;
            case 3:
                //SetLifeVisibility(3);
                Hamburgers[2].SetActive(false);
                break;
            case 2:
                Hamburgers[3].SetActive(false);
                //SetLifeVisibility(2);
                break;
            case 1:
                //SetLifeVisibility(1);
                Hamburgers[4].SetActive(false);
                break;
            case 0:
                Hamburgers[5].SetActive(false);
                //SetLifeVisibility(0);
                break;
        }
    }
  //void SetLifeVisibility(int activeLives)
  //{
  //    for (int i = 0; i < Hamburgers.Length; i++)
  //    {
  //        Hamburgers[i].SetActive(false);
  //    }
  //}
}
