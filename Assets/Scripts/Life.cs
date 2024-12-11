using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // UI ����� ���� ���ӽ����̽�
//using UnityEngine.SceneManagement;

public class Life : MonoBehaviour
{
    public GameObject[] Hamburgers; // ����� ��Ÿ���� ������Ʈ��
    public int life; // ���� ���
    public int Maxlife = 6; // �ִ� ���
    public GameObject gameOverPanel; // ���� ���� UI �г�

    public AudioSource gameoverBGM;
    public AudioSource backBGM;
    Animator anim;

    private void Awake()
    {
        life = Maxlife; // ó���� �ִ� ������� ����
    }

    void Start()
    {
        
        UpdateLivesDisplay(); // ��� ��� ������Ʈ�� Ȱ��ȭ
        gameOverPanel.SetActive(false);

        /*
        //for (int i = 12; i < 18; i++) //ui life
        for (int i = 0; i < 6; i++)
        {
            Hamburgers[i].SetActive(false);
            Hamburgers[i + 12].SetActive(false);
        }
        */

        anim = GetComponent<Animator>(); //�ִϸ��̼� 

    }



    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) // Enemy �±׸� ���� ��ü�� �浹
        {
            --life;
            UpdateLivesDisplay();
        }

        if (collision.gameObject.CompareTag("Heal")) // Heal �±׸� ���� ��ü�� �浹
        {
            GainLife();
            Destroy(collision.gameObject); // �浹 �� ȸ�� �������� ����
        }

        if (collision.gameObject.CompareTag("GameOver")) // GameOver �±׸� ���� ��ü�� �浹
        {
            life = 0;
            UpdateLivesDisplay();
            TriggerGameOver(); // ���� ���� ȣ��
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

            //�ӽ�
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

        // ���� ���� �̹���(UI �г�) Ȱ��ȭ
        gameOverPanel.SetActive(true);
        Time.timeScale = 0; // ������ �Ͻ� ����

        //game over sound
        backBGM.Pause(); //�Ͻ�����
        gameoverBGM.Play();
    }


    void UpdateLivesDisplay()
    {
        for (int i = 0; i < Hamburgers.Length; i++)
        {
            // ���� ��� ������ ���� �ε��������� Ȱ��ȭ, �� �̻��� ��Ȱ��ȭ
            //Hamburgers[i].SetActive(false);
        }

        // ����� 0�� �� ���� ���� ȣ��
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
            TriggerGameOver(); // ����� 0�� �� ���� ���� ȣ��
        }

        /*
        // ����� ���� Hamburgers ������Ʈ
        switch (life)
        {
            case 6:
                {
                    Hamburgers[0].SetActive(true);
                    //�� �غ��ʹ� �� ��� ���ҽ�
                    Hamburgers[11].SetActive(true);
                    Hamburgers[17].SetActive(false);
                }
                break;
            case 5:
                {
                    Hamburgers[1].SetActive(true);
                    Hamburgers[0].SetActive(false);

                    //�� �غ��ʹ� �� ��� ���ҽ�
                    Hamburgers[17].SetActive(true);
                    Hamburgers[11].SetActive(false);
                    //���+
                    Hamburgers[10].SetActive(true);
                }
                break;
            case 4:
                {
                    Hamburgers[2].SetActive(true);
                    Hamburgers[1].SetActive(false);

                    //�� �غ��ʹ� �� ��� ���ҽ�
                    Hamburgers[16].SetActive(true);
                    Hamburgers[10].SetActive(false);
                    //���+
                    Hamburgers[9].SetActive(true);
                }
                break;
            case 3:
                {
                    Hamburgers[3].SetActive(true);
                    Hamburgers[2].SetActive(false);

                    //�� �غ��ʹ� �� ��� ���ҽ�
                    Hamburgers[15].SetActive(true);
                    Hamburgers[9].SetActive(false);
                    //���+
                    Hamburgers[8].SetActive(true);
                }
                break;
            case 2:
                {
                    Hamburgers[4].SetActive(true);
                    Hamburgers[3].SetActive(false);

                    //�� �غ��ʹ� �� ��� ���ҽ�
                    Hamburgers[14].SetActive(true);
                    Hamburgers[8].SetActive(false);
                    //���+
                    Hamburgers[7].SetActive(true);
                }
                break;
            case 1:
                {
                    Hamburgers[5].SetActive(true);
                    Hamburgers[4].SetActive(false);

                    //�� �غ��ʹ� �� ��� ���ҽ�
                    Hamburgers[13].SetActive(true);
                    Hamburgers[7].SetActive(false);
                    //���+
                    Hamburgers[6].SetActive(true);

                }
                break;
            case 0:
                {
                    Hamburgers[5].SetActive(false);
                    //�� �غ��ʹ� �� ��� ���ҽ�
                    Hamburgers[12].SetActive(true);
                    Hamburgers[6].SetActive(false);

                    TriggerGameOver(); // ����� 0�� �� ���� ���� ȣ��
                }
                break;
        }
        */
    }
}
