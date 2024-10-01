using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    //화면 아래를 벗어 나면  제거 
    // Update is called once per frame
    void Update()
    {
        //월드 좌표를 스크린 좌표로 변환 
        Vector3 view = Camera.main.WorldToScreenPoint(transform.position);
        if(view.y<-50)
        {
            Destroy(gameObject);
        }
    }
}
