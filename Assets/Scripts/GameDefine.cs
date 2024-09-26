using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//캐릭터의 점프 상태
public enum UNIT_STATE
{
    IDLE,
    JUMP,
}
//발판의 종류 - 앞서 언급했듯이 
//움직이는 발판, 사라지는 발판등을 추가할 예정이다.
//현재는 일반 발판만 기재하였다.
public enum PLATFORM_TYPE
{
    NORMAL,
}
public class GameDefine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
