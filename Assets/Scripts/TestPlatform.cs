using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlatform : MonoBehaviour
{
    [SerializeField] PlatformManager platform;
    [SerializeField] Unit unit;

    // Start is called before the first frame update
    void Start()
    {
        //유닛의 초기 위치 지정
        unit.transform.position = new Vector3(0, -4, 0);
        //platform의 시작위치와 간격을 설정
        platform.MakePlatforms(1, 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            //유닛 점프 - platform의 간격보다 조금 높게 점프
            unit.Jump(2.2f);
        }

        //유닛의 현재위치로 발판을 갱신해준다
        platform.UpdatePlatform(unit.transform.position.y);
    }
}
