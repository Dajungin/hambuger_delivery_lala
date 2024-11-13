using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseStop : MonoBehaviour
{
    public GameObject stopWindow;
    public GameObject HomeWindow;
    
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

    public void SceneLoader(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
       
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
