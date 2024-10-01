using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Windows;

public class PlayerCtrl : MonoBehaviour
{
    public Transform Cloud;
    public Transform startPos;
    public Transform EndPos;

    Transform spPoint;
    //Transform newTile; //여기에 무언가를 넣어줘야 한다.
    float maxy = 0;

    int speedSide = 10; //좌우 이동 속도
    int speedJump =16; // 점프 속도
    int gravity = 25;  //추락 속도

    Vector3 moveDir = Vector3.zero;

    bool isDead = false;
    Animator anim;
    public Button retryGame;
  
    void Start()
    {
        anim=GetComponent<Animator>();

        //모바일 단말기 설정
        Screen.orientation = ScreenOrientation.LandscapeRight;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        spPoint = GameObject.Find("spPoint").transform;

        //Cursor.visible=false; //커서 감추기
        retryGame.gameObject.SetActive(false);
    }

    //게임 루프 

    // Update is called once per frame
    void Update()
    {
        if(isDead) return;
        mCamera(); //카메라 이동
        JumpPlayer(); //플레이어 점프
        MovePlayer(); //플레이어 이동
       
    }

    //플레이어 점프 
    void JumpPlayer()
    {
        RaycastHit2D hit;
        hit = Physics2D.Linecast(startPos.position, EndPos.position, 1 << LayerMask.NameToLayer("Time"));

        if(hit)
        {
            moveDir.y = speedJump;
            //AudioSource.PlayClipAtPoint(sndJump, transform.position);
        }
    }

    //플레이어 이동
    void MovePlayer()
    {
        Vector3 view = Camera.main.WorldToScreenPoint(transform.position);

        if(view.y < -50)
        {
            //화면 아래를 벗어나면
            isDead = true; //게임 오버
            GameOver();
            return;
        }

        moveDir.x = 0; //플레이어의 좌우 이동 방향

        //모바일 처리
        if(Application.platform == RuntimePlatform.Android || Application.platform== RuntimePlatform.IPhonePlayer) 
        {
            //중력 가속도 센서 읽기
            float x=Input.acceleration.x;

            //왼쪽으로 기울였나?
            if(x<-0.2f &&view.x >35)
            {
                moveDir.x = 2 * x * speedSide;
            }

            else
            {
                //keyboard 읽기
                float key = Input.GetAxis("Horizontal");
                if((key<0 &&view.x<Screen.width-35))
                {
                    moveDir.x = key * speedSide;
                }
            }
            //매 프레임마다 점프 속도 감소
            moveDir.y -= gravity * Time.deltaTime;
            transform.Translate(moveDir * Time.smoothDeltaTime);

            //애니메이션 설정
            if(moveDir.y > 0)
            {
                anim.Play("PlayerJump");
            }
            else
            {
                anim.Play("Playerldle");
            }

        }

       
        //게임 오버 설정
        void GameOver()
        {
            retryGame.gameObject.SetActive(true);
           
        }
        //재시작
    }
    public void RetryGame()
    {
        Application.LoadLevel("Test2");
    }
    void mCamera()
    {
        //Player 최대 높이 구하기
        if (transform.position.y > maxy)
        {
            maxy = transform.position.y;

            //카메라 위치 이동
            Camera.main.transform.position = new Vector3(0, maxy - 2.5f, -10);
            //score=(int)maxy*1000;.
        }
        //가장 최근의 Tile과 spPoint와의 거리 구하기
       // if (spPoint.position.y - newTile.position.y >= 4)
       // {
       //     //나뭇가지의 회전방향 설정
       //     int mx = (Random.Range(0, 2) == 0) ? -1 : -1;
       //     int my = (Random.Range(0, 2) == 0) ? -1 : -1;
       //     newTile.GetComponent<SpriteRenderer>().material.mainTextureScale = new Vector2(mx, my);
       //
       //     float x = Random.Range(-10f, 10f) * 0.5f;
       //     Vector3 pos = new Vector3(x, spPoint.position.y, 0.3f);
       //     newTile.GetComponent<SpriteRenderer>().material.mainTextureScale = new Vector2(mx, my);
       //
       //
       // }
    }
}

