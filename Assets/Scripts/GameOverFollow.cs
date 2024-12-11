using UnityEngine;
using UnityEngine.SceneManagement; // �� ���� ����� ���� ���ӽ����̽�
using UnityEngine.UI; // UI ����� ���� ���ӽ����̽�

public class GameOverFollow : MonoBehaviour
{
    public Transform player; // ĳ������ Transform
    public GameObject gameOverPanel; // GameOver UI �г�
    private float distanceBelowPlayer = 20f; // ĳ���Ϳ� GameOver â ������ �Ÿ�
    private float previousPlayerY; // ���� �������� ĳ���� Y ��ǥ
    private float fixedPanelY; // �г��� ������ Y ��ǥ

    void Start()
    {
        // GameOver â�� ó������ Ȱ��ȭ
        //gameOverPanel.SetActive(false);

        // ���� �� ĳ������ Y ��ǥ�� ���
        previousPlayerY = player.position.y;

        // �ʱ� �г� ��ġ ����
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

        // �÷��̾��� Y ��ǥ�� ����ϸ� �г��� ������Ʈ
        if (player.position.y > previousPlayerY)
        {
            fixedPanelY = player.position.y - distanceBelowPlayer;
        }

        // �г��� ��ġ�� ������ Y ������ ����
        Vector3 newPos = gameOverPanel.transform.position;
        newPos.y = fixedPanelY;
        gameOverPanel.transform.position = newPos;

        // ���� �������� ĳ���� Y ��ǥ�� ������ ���� �����Ӱ� ��
        previousPlayerY = player.position.y;
        */

    }

    // GameOver â�� Ȱ��ȭ�ϴ� �Լ� (�ʿ��� ������ ȣ�� ����)
    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }
  
}
