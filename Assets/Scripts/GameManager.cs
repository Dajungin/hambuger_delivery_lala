using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public SpawnManager spawnManager; //���� ���� ������ �ִ� ��
    public ItemManager itemManager;
    public CloudCtrl cloudCtrl;
    public GameObject Cover; //Cover �巡�� �� �� ����

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnClickStartButton() //���� ��ư Ŭ�� �� 
    {
        Cover.SetActive(false);
        Time.timeScale = 1;

    }

    public void OnClickRestart()
    {
        //ù ����� �������� �ȴ�.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Cover.SetActive(false);
        Time.timeScale = 1;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
