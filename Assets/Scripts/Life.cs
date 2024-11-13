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
    public GameObject gameEndPanel; // ����  UI �г�

    void Start()
    {
        life = Maxlife; // ó���� �ִ� ������� ����
        UpdateLivesDisplay(); // ��� ��� ������Ʈ�� Ȱ��ȭ
        gameOverPanel.SetActive(false);
        gameEndPanel.SetActive(false);

        for(int i=12;i<18;i++)
        {
            Hamburgers[i].SetActive(false);
        }

    }

    

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) // Enemy �±׸� ���� ��ü�� �浹
        {
            life--;
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
        if (collision.gameObject.CompareTag("End")) // GameOver �±׸� ���� ��ü�� �浹
        {
           
            UpdateLivesDisplay();
            //TriggerGameEnd(); // ���� ���� ȣ�� //������ ������ �ؾ��ϴ� �� �� ���� 
            if(life== Maxlife)
            {
                SceneManager.LoadScene("Good_Ending"); 
            }
            else if(life>=1)
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
        // ���� ���� �̹���(UI �г�) Ȱ��ȭ
        gameOverPanel.SetActive(true);
        Time.timeScale = 0; // ������ �Ͻ� ����
    }

    void TriggerGameEnd()
    {
        // ���� ���� �̹���(UI �г�) Ȱ��ȭ
        gameEndPanel.SetActive(true);
        Time.timeScale = 0; // ������ �Ͻ� ����
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
    }

   

    void Update()
    {
       
        // ����� ���� Hamburgers ������Ʈ
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
                

                TriggerGameOver(); // ����� 0�� �� ���� ���� ȣ��
                break;
        }
    }
}
