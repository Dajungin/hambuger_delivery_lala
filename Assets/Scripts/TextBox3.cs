using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextBox3 : MonoBehaviour
{
    public GameObject[] images; // �̹����� �����ϴ� �迭
    public GameObject[] backgrounds; // ����� �����ϴ� �迭 (����� 2��)
    private int currentImageIndex = 0; // ���� Ȱ��ȭ�� �̹����� �ε���

    void Start()
    {
        // ��� �̹����� ��Ȱ��ȭ�ϰ� ù ��° �̹����� Ȱ��ȭ
        for (int i = 0; i < images.Length; i++)
        {
            images[i].SetActive(false);
        }

        if (images.Length > 0)
        {
            images[0].SetActive(true);
        }

        // ù ��° ����� Ȱ��ȭ�ϰ� �� ��° ����� ��Ȱ��ȭ
        if (backgrounds.Length >= 2)
        {
            backgrounds[0].SetActive(true);
            backgrounds[1].SetActive(false);
        }
    }

    void Update()
    {
        // ������: PC���� ���콺 Ŭ�� ó��
        if (Input.GetMouseButtonDown(0))
        {
            ShowNextImage();
        }
    }

    void ShowNextImage()
    {
        // ���� �̹����� ��Ȱ��ȭ
        images[currentImageIndex].SetActive(false);

        // ���� �̹����� �ִٸ� Ȱ��ȭ
        if (currentImageIndex < images.Length - 1)
        {
            currentImageIndex++;
            images[currentImageIndex].SetActive(true);

            // �̹��� �ε����� 8�̸� ����� �� ��° ������� ����
            if (currentImageIndex == 7 && backgrounds.Length >= 2)
            {
                backgrounds[0].SetActive(false);
                backgrounds[1].SetActive(true);
            }
        }
        else
        {
            // ������ �̹��� ���� �� ��ȯ
            SceneManager.LoadScene("Good_Ending2");
            Time.timeScale = 1;
        }
    }
}
