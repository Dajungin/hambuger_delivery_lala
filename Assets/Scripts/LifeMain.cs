using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeMain : MonoBehaviour
{
    public int playerLife = 6; //某腐磐 格见
    public Life gameDirector; //格见 函荐
    // Start is called before the first frame update
    void Start()
    {
        this.gameDirector.Init(this.playerLife);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
