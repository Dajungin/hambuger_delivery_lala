using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudCtrl : MonoBehaviour
{
    public GameObject cloudPrefab;  // 구름 발판 프리팹
    public float minX = -3f;  // X좌표 최소값
    public float maxX = 3f;   // X좌표 최대값
    public float nextSpawnYOffset = 7f;  // 새 구름이 기존 구름 위로 얼마나 떨어져 생성될지 (Y간격)

    private List<Vector3> spawnedClouds = new List<Vector3>();  // 생성된 구름의 위치를 저장

    void Start()
    {
        // 무한 구름 발판 스폰 루틴 시작
        StartCoroutine(SpawnClouds());
    }

    IEnumerator SpawnClouds()
    {
        while (true)
        {
            // 화면에 구름이 없으면 새 구름을 기본 위치에 생성
            if (GameObject.FindGameObjectsWithTag("Cloud").Length == 0)
            {
                // 첫 구름을 기본 Y좌표에 생성 (9f 위치에 생성)
                SpawnCloudAtY(9f);
            }
            else
            {
                // 현재 화면에서 Y좌표가 가장 큰 구름을 찾음
                float highestY = GetHighestCloudY();

                // 그 위로 일정 간격(nextSpawnYOffset)을 두고 새 구름 생성
                float spawnY = highestY + nextSpawnYOffset;

                // 해당 Y좌표에 구름 생성
                SpawnCloudAtY(spawnY);
            }

            // 1초마다 구름 생성
            yield return new WaitForSeconds(1.0f);
        }
    }

    void SpawnCloudAtY(float y)
    {
        // X좌표는 랜덤하게 설정
        float randomX = Random.Range(minX, maxX);

        // 구름 생성
        Vector3 spawnPosition = new Vector3(randomX, y, 0);
        Instantiate(cloudPrefab, spawnPosition, Quaternion.identity);

        // 생성된 구름 위치 저장
        spawnedClouds.Add(new Vector3(randomX, y));
    }

    // 화면 내 구름 중에서 Y좌표가 가장 큰 구름 찾기
    float GetHighestCloudY()
    {
        float highestY = float.MinValue;

        // 화면에 있는 모든 구름 찾기
        GameObject[] allClouds = GameObject.FindGameObjectsWithTag("Cloud");

        // 각 구름의 Y좌표를 확인하여 가장 큰 값 찾기
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
        // 카메라 아래로 벗어난 구름 제거
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
