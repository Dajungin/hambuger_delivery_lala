using UnityEngine;
using UnityEngine.SceneManagement; // �� ���� ����� ���� ���ӽ����̽�
using UnityEngine.UI; // UI ����� ���� ���ӽ����̽�

public class GameOverFollow : MonoBehaviour
{
    public Transform player; // ĳ������ Transform
    public GameObject gameOverPanel; // GameOver UI �г�
    private float distanceBelowPlayer = 30f; // ĳ���Ϳ� GameOver â ������ �Ÿ� 35
    private float previousPlayerY; // ���� �������� ĳ���� Y ��ǥ



    void Start()
    {
        // GameOver â�� ó������ ��Ȱ��ȭ�ϰų� �ʿ信 ���� Ȱ��ȭ
        gameOverPanel.SetActive(true);

        // ���� �� ĳ������ Y��ǥ�� ���
        previousPlayerY = player.position.y;


    }



    void Update()
    {
        // ĳ���Ͱ� ���� �����Ӻ��� ���� �̵����� ���� GameOver â�� ��ġ�� ������Ʈ
        if (player.position.y > previousPlayerY)
        {
            // GameOver â�� �׻� ĳ������ Y��ǥ �Ʒ� 13��ŭ ��ġ�ϰ� ����
            Vector3 newPos = gameOverPanel.transform.position;
            newPos.y = player.position.y - distanceBelowPlayer;
            gameOverPanel.transform.position = newPos;
        }

        // ���� �������� ĳ���� Y��ǥ�� ������ ���� �����Ӱ� ��
        previousPlayerY = player.position.y;
    }

    // GameOver â�� Ȱ��ȭ�ϴ� �Լ� (�ʿ��� ������ ȣ�� ����)
    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }

    // GameOver â�� ��Ȱ��ȭ�ϴ� �Լ� (�ʿ��� ��� ��� ����)
    public void HideGameOverPanel()
    {
        gameOverPanel.SetActive(false);
    }
}
