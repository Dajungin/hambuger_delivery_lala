using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    public Text txtScore;
    private int totalScore;
    public GameObject[] lifes;

    public void Init (int playerLife)
    {
        for( int i=0;i<lifes.Length;i++)
        {
            this.lifes[i].SetActive(false);
        }
        for(int i=0; i<playerLife;i++)
        {
            this.lifes[i].SetActive(true);
        }
    }


    public void AddScore(int score)
    {
        this.totalScore += score;
        this.txtScore.text = totalScore.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }
 
}
