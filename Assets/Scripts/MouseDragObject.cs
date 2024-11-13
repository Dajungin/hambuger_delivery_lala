using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MouseDragObject : MonoBehaviour
{ 
public float speed = 2f; // �÷��̾� �̵� �ӵ� ó�� 10�̾���. 

    void Update()
    {
        // ȭ�鿡 ��ġ�� �ϳ� �̻� ���� ���� ����
        if (Input.touchCount > 0)
        {
            // ù ��° ��ġ�� ������ (�ε��� 0)
            Touch touch = Input.GetTouch(0);

            // ��ġ�� �����̰ų� �����ǰ� ���� ���� ����
            if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                // ��ġ ��ġ�� ȭ�� ��ǥ���� ���� ��ǥ�� ��ȯ
                Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

                // X�� ��ǥ�� ��ġ ��ġ��, Y���� ���� ��ġ�� ����
                Vector2 newPosition = new Vector2(touchPosition.x, transform.position.y);

                // ���� ������ ����� �ε巴�� ĳ���͸� �̵� (���� ����)
                transform.position = Vector2.Lerp(transform.position, newPosition, speed * Time.deltaTime);
            }
        }
    }
}