using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform playerTransform; // �÷��̾��� ��ġ�� ����
    public float xFixedPosition = 0f; // ī�޶��� ������ X��ǥ ��

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform != null)
        {
            // ī�޶��� X��ǥ�� �����ϰ�, Y��ǥ�� �÷��̾��� Y��ǥ�� ����
            Vector3 newPosition = new Vector3(xFixedPosition, playerTransform.position.y, transform.position.z);

            // ���ο� ī�޶� ��ġ ����
            transform.position = newPosition;

            //ī�޶� ������ ĳ���� ��Ż ����
            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

            if (pos.x < 0f) pos.x = 0f;
            if (pos.x > 1f) pos.x = 1f;
            if (pos.y < 0f) pos.y = 0f;
            if (pos.y > 1f) pos.y = 1f;

            transform.position = Camera.main.ViewportToWorldPoint(pos);
        }
    }
}
