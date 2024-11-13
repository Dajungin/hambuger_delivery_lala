using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //æ¿ ¿Ãµø

public class SceanMove : MonoBehaviour
{
   public void SceneLoader(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

    }

}
