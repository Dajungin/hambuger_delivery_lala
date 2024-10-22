using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseStop : MonoBehaviour
{
    public GameObject stopWindow;
    
    public void OnClickStopBtn()
    {
        Time.timeScale = 0;
        stopWindow.SetActive(true);
    }

    public void ONClickContinBtn()
    {
        Time.timeScale = 1;
        stopWindow.SetActive(false);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
