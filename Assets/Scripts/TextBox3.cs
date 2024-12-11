using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextBox3 : MonoBehaviour
{
    public GameObject[] images; // 이미지를 관리하는 배열
    public GameObject[] backgrounds; // 배경을 관리하는 배열 (배경은 2개)
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

        // 첫 번째 배경을 활성화하고 두 번째 배경을 비활성화
        if (backgrounds.Length >= 2)
        {
            backgrounds[0].SetActive(true);
            backgrounds[1].SetActive(false);
        }
    }

    void Update()
    {
        // 디버깅용: PC에서 마우스 클릭 처리
        if (Input.GetMouseButtonDown(0))
        {
            ShowNextImage();
        }
    }

    void ShowNextImage()
    {
        // 현재 이미지를 비활성화
        images[currentImageIndex].SetActive(false);

        // 다음 이미지가 있다면 활성화
        if (currentImageIndex < images.Length - 1)
        {
            currentImageIndex++;
            images[currentImageIndex].SetActive(true);

            // 이미지 인덱스가 8이면 배경을 두 번째 배경으로 변경
            if (currentImageIndex == 7 && backgrounds.Length >= 2)
            {
                backgrounds[0].SetActive(false);
                backgrounds[1].SetActive(true);
            }
        }
        else
        {
            // 마지막 이미지 이후 씬 전환
            SceneManager.LoadScene("Good_Ending2");
            Time.timeScale = 1;
        }
    }
}
