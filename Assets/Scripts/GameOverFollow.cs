using UnityEngine;
using UnityEngine.SceneManagement; // 씬 관리 기능을 위한 네임스페이스
using UnityEngine.UI; // UI 기능을 위한 네임스페이스

public class GameOverFollow : MonoBehaviour
{
    public Transform player; // 캐릭터의 Transform
    public GameObject gameOverPanel; // GameOver UI 패널
    private float distanceBelowPlayer = 30f; // 캐릭터와 GameOver 창 사이의 거리 35
    private float previousPlayerY; // 이전 프레임의 캐릭터 Y 좌표



    void Start()
    {
        // GameOver 창을 처음부터 비활성화하거나 필요에 따라 활성화
        gameOverPanel.SetActive(true);

        // 시작 시 캐릭터의 Y좌표를 기록
        previousPlayerY = player.position.y;


    }



    void Update()
    {
        // 캐릭터가 이전 프레임보다 위로 이동했을 때만 GameOver 창의 위치를 업데이트
        if (player.position.y > previousPlayerY)
        {
            // GameOver 창이 항상 캐릭터의 Y좌표 아래 13만큼 위치하게 설정
            Vector3 newPos = gameOverPanel.transform.position;
            newPos.y = player.position.y - distanceBelowPlayer;
            gameOverPanel.transform.position = newPos;
        }

        // 현재 프레임의 캐릭터 Y좌표를 저장해 다음 프레임과 비교
        previousPlayerY = player.position.y;
    }

    // GameOver 창을 활성화하는 함수 (필요한 곳에서 호출 가능)
    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }

    // GameOver 창을 비활성화하는 함수 (필요한 경우 사용 가능)
    public void HideGameOverPanel()
    {
        gameOverPanel.SetActive(false);
    }
}
