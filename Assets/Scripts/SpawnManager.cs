using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] monsterPrefabs; // 몬스터 종류 배열
    public float minX = -5f; // x좌표 최소값
    public float maxX = 5f; // x좌표 최대값
    public float minYInterval = 7f; // y좌표 최소 간격
    public float maxYInterval = 10f; // y좌표 최대 간격

    private Camera mainCamera; // 메인 카메라 참조
    private float lastSpawnY = 0f; // 마지막으로 몬스터가 생성된 Y좌표

    void Start()
    {
        // 메인 카메라 참조
        mainCamera = Camera.main;

        // 처음 몬스터를 스폰하는 루틴 실행
        StartCoroutine(SpawnMonster());
    }

    public void SpawnEnemy(GameObject prefab, Vector3 position) // 적의 스폰 위치 설정 함수
    {
        GameObject enemy = Instantiate(prefab);
        enemy.transform.position = position;
    }

    IEnumerator SpawnMonster()
    {
        while (true)
        {
            float spawnY = lastSpawnY + Random.Range(minYInterval, maxYInterval);
            float randomX = Random.Range(minX, maxX);
            Vector3 spawnPosition = new Vector3(randomX, spawnY, 0);

            // 0 또는 1마리의 몬스터를 랜덤하게 생성
            int randomCount = Random.Range(1, 2); // 0~1 마리 생성

            for (int i = 0; i < randomCount; i++)
            {
                int randomIndex = Random.Range(0, monsterPrefabs.Length);
                GameObject selectedMonster = monsterPrefabs[randomIndex];
                Instantiate(selectedMonster, spawnPosition, Quaternion.identity);
            }

            // 마지막 생성된 Y좌표 업데이트
            lastSpawnY = spawnY;

            // 몬스터 생성 후 1초 대기
            yield return new WaitForSeconds(1.0f);
        }
    }
    void CleanupOffScreenObjects()
    {

        // 카메라 아래로 벗어난 몬스터 제거
        GameObject[] allMonsters = GameObject.FindGameObjectsWithTag("Monster"); // 태그가 Monster인 오브젝트들
        foreach (GameObject monster in allMonsters)
        {
            if (monster.transform.position.y < mainCamera.transform.position.y - 5)
            {
                Destroy(monster);
            }
        }
    }

    void Update()
    {

    }
}
