using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // �� ���� ����� ���� ���ӽ����̽�
using UnityEngine.UI; // UI ����� ���� ���ӽ����̽�

public class PauseControl : MonoBehaviour
{
    //[SerializeField] Text startPauseText;
    public GameObject stopWindow; // ���߱� UI �г�
    bool pauseActive = false;
    public GameObject Pause_Button;

    // Start is called before the first frame update


    public void pauseBtn()
    {
        if(pauseActive)
        {
            Time.timeScale = 0;
            pauseActive = true;
            Pause_Button.SetActive(false);
            stopWindow.SetActive(true);


        }
        else
        {
            Time.timeScale = 1;
            pauseActive = false;
            Pause_Button.SetActive(true);
            stopWindow.SetActive(false);
        }
       
    }
    void Start()
    {
        stopWindow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
