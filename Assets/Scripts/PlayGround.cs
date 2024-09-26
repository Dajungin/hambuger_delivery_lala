using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//운동장
public class PlayGround : MonoBehaviour
{
    //캐릭터 지정
    Unit unit;
    // !!PlatformManager 변수 추가 
    PlatformManager platformManager;

    float screenJumpHeight = 0;
    float worldJumpHeight = 0;
    float jumpScreenRate = 0.6f;
    Vector2 bottomPosition;

    private void Awake()
    {
        //제일 먼저 자동으로 시작되는 함수
        //기본 정보들을 초기화 해주자
        //오브젝트가 활성화 되고 한반만 호출된다.
        //스크립트가 비활성화 되어있어도 호출된다.
        Debug.Log(gameObject.name + " : Awake");

        var _orthoSize = Camera.main.orthographicSize;
        screenJumpHeight = Screen.height * jumpScreenRate;
        worldJumpHeight = (_orthoSize * 2) * jumpScreenRate;

        Debug.Log("Jump Height : " + screenJumpHeight + " / " + worldJumpHeight + " / " + _orthoSize);
    }

    private void OnEnable()
    {
        //오브젝트가 활성화 될 때 마다 호출
        Debug.Log(gameObject.name + " : OnEnable");
    }

    private void Start()
    {
        //스크립트가 활성화 될때 한반만 호출된다.
        Debug.Log(gameObject.name + " : Start");

        FindUnit();

        //!!캐릭터 초기위치 설정 
        FindUnitStartPosition();

        //!!PlatformManager 를 찾기
        FindPlatformManager();
        //!!PlatformManager 에서 발판 생성
        PlacePlatformManager();
    }

    private void Update()
    {
        //프레임마다 호출
        TouchScreenEvent();

        //!!PlatformManager에서 character의 위치값 추적 
        platformManager.UpdatePlatform(unit.transform.position.y);
    }

    //!!캐릭터 초기위치 설정
    void FindUnitStartPosition()
    {
        //screen 의 위치와 오브젝트가 존재하는 위치는 계산되는 단위가 다르다.
        bottomPosition = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width * 0.5f, Screen.height * 0.1f));

        //스크린 상의 하단 중앙의 위치를 오브젝트가 존재하는 위치로 환산하여 유닛에게 적용될 위치를 보여준다.
        Debug.Log("BottomPosition : " + bottomPosition);

        //유닛에게 적용시킨다. - 주의 할점은 z 값을 0으로 지정해 줘야 화면에 표시된다.
        unit.transform.position = new Vector3(bottomPosition.x, bottomPosition.y, 0);
    }

    private void OnDisable()
    {
        //오브젝트가 비활성화 될 때 마다 호출
        Debug.Log(gameObject.name + " : OnDisable");
    }

    private void OnDestroy()
    {
        //오브젝트가 파괴될 때 호출
    }

    void FindUnit()
    {
        //캐릭터를 찾는다
        unit = GameObject.Find("character").GetComponent<Unit>();
    }

    void TouchScreenEvent()
    {
        //update 함수 안에서 터치 이벤트를 감지한다

        //화면을 눌렀을 때 이벤트
        if (Input.GetMouseButtonDown(0))
        {

        }

        //화면을 눌렀다가 땔때 이벤트
        if (Input.GetMouseButtonUp(0))
        {
            JumpUp();
        }
    }

    void JumpUp()
    {
        if (unit.GetUnitState != UNIT_STATE.IDLE) return;
        unit.Jump(worldJumpHeight);
    }

    //!!PlatformManager 를 찾기
    void FindPlatformManager()
    {
        platformManager = GameObject.Find("PlatformManager").GetComponent<PlatformManager>();
        platformManager.transform.position = Vector3.zero;
    }
    //!!PlatformManager 에서 발판 생성
    void PlacePlatformManager()
    {
        platformManager.MakePlatforms(bottomPosition.y, Camera.main.orthographicSize);
    }

}


