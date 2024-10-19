using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public SpawnManager spawnManager; //적군 스폰 프리팹 넣는 곳
    public ItemManager itemManager;
    public CloudCtrl cloudCtrl;
    public GameObject Cover; //Cover 드래그 할 수 있음


  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnClickStartButton() //시작 버튼 클릭 시 
    {
        Cover.SetActive(false);
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
