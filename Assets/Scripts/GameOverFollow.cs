using UnityEngine;
using UnityEngine.SceneManagement; // 씬 관리 기능을 위한 네임스페이스
using UnityEngine.UI; // UI 기능을 위한 네임스페이스

public class GameOverFollow : MonoBehaviour
{
    public Transform player; // 캐릭터의 Transform
    public GameObject gameOverPanel; // GameOver UI 패널
    private float distanceBelowPlayer = 20f; // 캐릭터와 GameOver 창 사이의 거리
    private float previousPlayerY; // 이전 프레임의 캐릭터 Y 좌표
    private float fixedPanelY; // 패널이 고정될 Y 좌표

    void Start()
    {
        // GameOver 창을 처음부터 활성화
        //gameOverPanel.SetActive(false);

        // 시작 시 캐릭터의 Y 좌표를 기록
        previousPlayerY = player.position.y;

        // 초기 패널 위치 설정
        fixedPanelY = player.position.y - distanceBelowPlayer;
    }

    void Update()
    {
        if (player.position.y > previousPlayerY)
        {
            Vector3 pos = gameOverPanel.transform.position;
            pos.y = player.position.y - distanceBelowPlayer;

            gameOverPanel.transform.position = pos;
        }
        previousPlayerY = player.position.y;

        /*

        // 플레이어의 Y 좌표가 상승하면 패널을 업데이트
        if (player.position.y > previousPlayerY)
        {
            fixedPanelY = player.position.y - distanceBelowPlayer;
        }

        // 패널의 위치를 고정된 Y 값으로 설정
        Vector3 newPos = gameOverPanel.transform.position;
        newPos.y = fixedPanelY;
        gameOverPanel.transform.position = newPos;

        // 현재 프레임의 캐릭터 Y 좌표를 저장해 다음 프레임과 비교
        previousPlayerY = player.position.y;
        */

    }

    // GameOver 창을 활성화하는 함수 (필요한 곳에서 호출 가능)
    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }
  
}
