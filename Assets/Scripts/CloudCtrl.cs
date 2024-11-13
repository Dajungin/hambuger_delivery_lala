using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudCtrl : MonoBehaviour
{
    public GameObject cloudPrefab;  // ���� ���� ������
    public float minX = -3f;  // X��ǥ �ּҰ�
    public float maxX = 3f;   // X��ǥ �ִ밪
    public float nextSpawnYOffset = 7f;  // �� ������ ���� ���� ���� �󸶳� ������ �������� (Y����)

    private List<Vector3> spawnedClouds = new List<Vector3>();  // ������ ������ ��ġ�� ����

    void Start()
    {
        // ���� ���� ���� ���� ��ƾ ����
        StartCoroutine(SpawnClouds());
    }

    IEnumerator SpawnClouds()
    {
        while (true)
        {
            // ȭ�鿡 ������ ������ �� ������ �⺻ ��ġ�� ����
            if (GameObject.FindGameObjectsWithTag("Cloud").Length == 0)
            {
                // ù ������ �⺻ Y��ǥ�� ���� (9f ��ġ�� ����)
                SpawnCloudAtY(9f);
            }
            else
            {
                // ���� ȭ�鿡�� Y��ǥ�� ���� ū ������ ã��
                float highestY = GetHighestCloudY();

                // �� ���� ���� ����(nextSpawnYOffset)�� �ΰ� �� ���� ����
                float spawnY = highestY + nextSpawnYOffset;

                // �ش� Y��ǥ�� ���� ����
                SpawnCloudAtY(spawnY);
            }

            // 1�ʸ��� ���� ����
            yield return new WaitForSeconds(1.0f);
        }
    }

    void SpawnCloudAtY(float y)
    {
        // X��ǥ�� �����ϰ� ����
        float randomX = Random.Range(minX, maxX);

        // ���� ����
        Vector3 spawnPosition = new Vector3(randomX, y, 0);
        Instantiate(cloudPrefab, spawnPosition, Quaternion.identity);

        // ������ ���� ��ġ ����
        spawnedClouds.Add(new Vector3(randomX, y));
    }

    // ȭ�� �� ���� �߿��� Y��ǥ�� ���� ū ���� ã��
    float GetHighestCloudY()
    {
        float highestY = float.MinValue;

        // ȭ�鿡 �ִ� ��� ���� ã��
        GameObject[] allClouds = GameObject.FindGameObjectsWithTag("Cloud");

        // �� ������ Y��ǥ�� Ȯ���Ͽ� ���� ū �� ã��
        foreach (GameObject cloud in allClouds)
        {
            float cloudY = cloud.transform.position.y;
            if (cloudY > highestY)
            {
                highestY = cloudY;
            }
        }

        return highestY;
    }

    void Update()
    {
        // ī�޶� �Ʒ��� ��� ���� ����
        GameObject[] allClouds = GameObject.FindGameObjectsWithTag("Cloud");
        foreach (GameObject cloud in allClouds)
        {
            if (cloud.transform.position.y < Camera.main.transform.position.y - 10f)
            {
                Destroy(cloud);
            }
        }
    }
}
