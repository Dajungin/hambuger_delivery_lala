using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextBox3 : MonoBehaviour
{
    public GameObject[] images; // 이미지를 관리하는 배열
    private int currentImageIndex = 0; // 현재 활성화된 이미지의 인덱스

    void Start()
    {
        // 모든 이미지를 비활성화하고 첫 번째 이미지만 활성화
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
        // 모바일 터치 입력 처리
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ShowNextImage();
        }
    }

    void ShowNextImage()
    {
        // 현재 이미지를 비활성화
        images[currentImageIndex].SetActive(false);

        // 다음 이미지가 있다면 활성화
        if (currentImageIndex < images.Length - 1) // 범위 초과 방지
        {
            currentImageIndex++;
            images[currentImageIndex].SetActive(true);
        }
        else
        {
            // 마지막 이미지 이후 씬 전환
            SceneManager.LoadScene("Good_Ending2");
            Time.timeScale = 1;
        }
    }
}
