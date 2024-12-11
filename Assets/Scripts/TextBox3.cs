using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextBox3 : MonoBehaviour
{
    public GameObject[] images; // �̹����� �����ϴ� �迭
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
    }

    void Update()
    {
        // ����� ��ġ �Է� ó��
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ShowNextImage();
        }
    }

    void ShowNextImage()
    {
        // ���� �̹����� ��Ȱ��ȭ
        images[currentImageIndex].SetActive(false);

        // ���� �̹����� �ִٸ� Ȱ��ȭ
        if (currentImageIndex < images.Length - 1) // ���� �ʰ� ����
        {
            currentImageIndex++;
            images[currentImageIndex].SetActive(true);
        }
        else
        {
            // ������ �̹��� ���� �� ��ȯ
            SceneManager.LoadScene("Good_Ending2");
            Time.timeScale = 1;
        }
    }
}
