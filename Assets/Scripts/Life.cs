using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // UI 기능을 위한 네임스페이스
//using UnityEngine.SceneManagement;

public class Life : MonoBehaviour
{
    public GameObject[] Hamburgers; // 목숨을 나타내는 오브젝트들
    public int life; // 현재 목숨
    public int Maxlife = 6; // 최대 목숨
    public GameObject gameOverPanel; // 게임 오버 UI 패널
    public GameObject gameEndPanel; // 게임  UI 패널

    void Start()
    {
        life = Maxlife; // 처음은 최대 목숨으로 시작
        UpdateLivesDisplay(); // 모든 목숨 오브젝트를 활성화
        gameOverPanel.SetActive(false);
        gameEndPanel.SetActive(false);

        for(int i=12;i<18;i++)
        {
            Hamburgers[i].SetActive(false);
        }

    }

    

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) // Enemy 태그를 가진 물체와 충돌
        {
            life--;
            UpdateLivesDisplay();
        }

        if (collision.gameObject.CompareTag("Heal")) // Heal 태그를 가진 물체와 충돌
        {
            GainLife();
            Destroy(collision.gameObject); // 충돌 후 회복 아이템을 제거
        }

        if (collision.gameObject.CompareTag("GameOver")) // GameOver 태그를 가진 물체와 충돌
        {
            life = 0;
            UpdateLivesDisplay();
            TriggerGameOver(); // 게임 오버 호출
        }
        if (collision.gameObject.CompareTag("End")) // GameOver 태그를 가진 물체와 충돌
        {
           
            UpdateLivesDisplay();
            //TriggerGameEnd(); // 게임 오버 호출 //엔딩이 나오게 해야하는 데 안 나옴 
            if(life== Maxlife)
            {
                SceneManager.LoadScene("Good_Ending"); 
            }
            else if(life>=1)
            {
                SceneManager.LoadScene("Nomal_Ending");
            }

            //임시
            GameObject.FindObjectOfType<PlayerController>().SetInitPlayerGravity();
        }
    }

    public void GainLife()
    {
        if (life < Maxlife)
        {
            life++;
            UpdateLivesDisplay();

            if (life >= Maxlife)
            {
                life = Maxlife;
            }
        }
    }

    void TriggerGameOver()
    {
        // 게임 오버 이미지(UI 패널) 활성화
        gameOverPanel.SetActive(true);
        Time.timeScale = 0; // 게임을 일시 정지
    }

    void TriggerGameEnd()
    {
        // 게임 오버 이미지(UI 패널) 활성화
        gameEndPanel.SetActive(true);
        Time.timeScale = 0; // 게임을 일시 정지
    }


    void UpdateLivesDisplay()
    {
        for (int i = 0; i < Hamburgers.Length; i++)
        {
            // 남은 목숨 수보다 적은 인덱스까지는 활성화, 그 이상은 비활성화
            //Hamburgers[i].SetActive(false);
        }

        // 목숨이 0일 때 게임 오버 호출
        if (life <= 0)
        {
            TriggerGameOver();
        }
    }

    public void Restart_Btu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

   

    void Update()
    {
       
        // 목숨에 따른 Hamburgers 업데이트
        switch (life)
        {
            case 6:
                Hamburgers[0].SetActive(true);
                Hamburgers[12].SetActive(false);
                Hamburgers[11].SetActive(true);
                
                break;
            case 5:

                Hamburgers[0].SetActive(false);
                Hamburgers[1].SetActive(true);
                Hamburgers[11].SetActive(false);
                Hamburgers[10].SetActive(true);
                Hamburgers[13].SetActive(false);
                Hamburgers[12].SetActive(true);
                

                break;
            case 4:

                Hamburgers[1].SetActive(false);
                Hamburgers[2].SetActive(true);
                Hamburgers[10].SetActive(false);
                Hamburgers[9].SetActive(true);
                Hamburgers[14].SetActive(false);
                Hamburgers[13].SetActive(true);
                
                break;
            case 3:

                Hamburgers[2].SetActive(false);
                Hamburgers[3].SetActive(true);
                Hamburgers[9].SetActive(false);
                Hamburgers[8].SetActive(true);
                Hamburgers[15].SetActive(false);
                Hamburgers[14].SetActive(true);
                
                break;
            case 2:
                Hamburgers[3].SetActive(false);
                Hamburgers[4].SetActive(true);
                Hamburgers[8].SetActive(false);
                Hamburgers[7].SetActive(true);
                Hamburgers[15].SetActive(true);
                Hamburgers[17].SetActive(true);
                Hamburgers[16].SetActive(false);

                break;
            case 1:

                Hamburgers[4].SetActive(false);
                Hamburgers[5].SetActive(true);
                Hamburgers[7].SetActive(false);
                Hamburgers[6].SetActive(true);
                Hamburgers[17].SetActive(false);
                Hamburgers[16].SetActive(true);
                
                break;
            case 0:
                Hamburgers[5].SetActive(false);

                Hamburgers[6].SetActive(false);
                

                TriggerGameOver(); // 목숨이 0일 때 게임 오버 호출
                break;
        }
    }
}
