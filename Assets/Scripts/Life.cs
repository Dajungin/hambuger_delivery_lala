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

    public AudioSource gameoverBGM;
    public AudioSource backBGM;
    Animator anim;

    private void Awake()
    {
        life = Maxlife; // 처음은 최대 목숨으로 시작
    }

    void Start()
    {
        
        UpdateLivesDisplay(); // 모든 목숨 오브젝트를 활성화
        gameOverPanel.SetActive(false);

        /*
        //for (int i = 12; i < 18; i++) //ui life
        for (int i = 0; i < 6; i++)
        {
            Hamburgers[i].SetActive(false);
            Hamburgers[i + 12].SetActive(false);
        }
        */

        anim = GetComponent<Animator>(); //애니메이션 

    }



    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) // Enemy 태그를 가진 물체와 충돌
        {
            --life;
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
        if (collision.gameObject.CompareTag("End")) 
        {

            UpdateLivesDisplay();
            if (life == Maxlife)
            {
                SceneManager.LoadScene("Good_Ending");
            }
            else if (life >= 1)
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
            ++life;
            UpdateLivesDisplay();

            if (life >= Maxlife)
            {
                life = Maxlife;
            }
        }
    }

    void TriggerGameOver()
    {
        if (gameOverPanel.activeSelf) return;

        // 게임 오버 이미지(UI 패널) 활성화
        gameOverPanel.SetActive(true);
        Time.timeScale = 0; // 게임을 일시 정지

        //game over sound
        backBGM.Pause(); //일시정지
        gameoverBGM.Play();
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
        backBGM.UnPause();
    }


    void LifeUIUpdate()
    {
        if(life == Maxlife) Hamburgers[17].SetActive(true);
        //else Hamburgers[12].SetActive(false);

        for (int i = 0; i < Maxlife; i++)
        {
            Hamburgers[i].SetActive(false);
            Hamburgers[i+6].SetActive(true);
            Hamburgers[i + 12].SetActive(false);
        }
            //life //6 ~ 0
        for (int i = 0; i < life; i++)
        {
            Hamburgers[i].SetActive(true);
            Hamburgers[i + 6].SetActive(false);
            Hamburgers[i+12].SetActive(true);
        }               
    }

    void Update()
    {
        LifeUIUpdate();

        if (life <= 0)
        {
            TriggerGameOver(); // 목숨이 0일 때 게임 오버 호출
        }

        /*
        // 목숨에 따른 Hamburgers 업데이트
        switch (life)
        {
            case 6:
                {
                    Hamburgers[0].SetActive(true);
                    //이 밑부터는 별 목숨 리소스
                    Hamburgers[11].SetActive(true);
                    Hamburgers[17].SetActive(false);
                }
                break;
            case 5:
                {
                    Hamburgers[1].SetActive(true);
                    Hamburgers[0].SetActive(false);

                    //이 밑부터는 별 목숨 리소스
                    Hamburgers[17].SetActive(true);
                    Hamburgers[11].SetActive(false);
                    //목숨+
                    Hamburgers[10].SetActive(true);
                }
                break;
            case 4:
                {
                    Hamburgers[2].SetActive(true);
                    Hamburgers[1].SetActive(false);

                    //이 밑부터는 별 목숨 리소스
                    Hamburgers[16].SetActive(true);
                    Hamburgers[10].SetActive(false);
                    //목숨+
                    Hamburgers[9].SetActive(true);
                }
                break;
            case 3:
                {
                    Hamburgers[3].SetActive(true);
                    Hamburgers[2].SetActive(false);

                    //이 밑부터는 별 목숨 리소스
                    Hamburgers[15].SetActive(true);
                    Hamburgers[9].SetActive(false);
                    //목숨+
                    Hamburgers[8].SetActive(true);
                }
                break;
            case 2:
                {
                    Hamburgers[4].SetActive(true);
                    Hamburgers[3].SetActive(false);

                    //이 밑부터는 별 목숨 리소스
                    Hamburgers[14].SetActive(true);
                    Hamburgers[8].SetActive(false);
                    //목숨+
                    Hamburgers[7].SetActive(true);
                }
                break;
            case 1:
                {
                    Hamburgers[5].SetActive(true);
                    Hamburgers[4].SetActive(false);

                    //이 밑부터는 별 목숨 리소스
                    Hamburgers[13].SetActive(true);
                    Hamburgers[7].SetActive(false);
                    //목숨+
                    Hamburgers[6].SetActive(true);

                }
                break;
            case 0:
                {
                    Hamburgers[5].SetActive(false);
                    //이 밑부터는 별 목숨 리소스
                    Hamburgers[12].SetActive(true);
                    Hamburgers[6].SetActive(false);

                    TriggerGameOver(); // 목숨이 0일 때 게임 오버 호출
                }
                break;
        }
        */
    }
}
