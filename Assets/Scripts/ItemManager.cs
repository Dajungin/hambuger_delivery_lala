using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameObject[] Items; // 종류 배열
    public float minX = -4f; // x좌표 최소값
    public float maxX = 4f; // x좌표 최대값
    public float minYInterval = 14f; // y좌표 최소 간격
    public float maxYInterval = 28f; // y좌표 최대 간격

    private Camera mainCamera; // 메인 카메라 참조
    private float lastSpawnY = 0f; // 마지막으로 생성된 Y좌표

    void Start()
    {
        // 메인 카메라 참조
        mainCamera = Camera.main;

        // 처음 스폰하는 루틴 실행
        StartCoroutine(SpawnItem());
    }

    public void SpawnItem(GameObject prefab, Vector3 position) // 스폰 위치 설정 함수
    {
        GameObject Heal = Instantiate(prefab);
        Heal.transform.position = position;
    }

    IEnumerator SpawnItem()
    {
        while (true)
        {
            float spawnY = lastSpawnY + Random.Range(minYInterval, maxYInterval);
            float randomX = Random.Range(minX, maxX);
            Vector3 spawnPosition = new Vector3(randomX, spawnY, 0);

          
            int randomCount = Random.Range(1, 2); // 0~1 마리 생성

            for (int i = 0; i < randomCount; i++)
            {
                int randomIndex = Random.Range(0, Items.Length);
                GameObject selectedMonster = Items[randomIndex];
                Instantiate(selectedMonster, spawnPosition, Quaternion.identity);
            }

            // 마지막 생성된 Y좌표 업데이트
            lastSpawnY = spawnY;

            // 몬스터 생성 후 1초 대기
            yield return new WaitForSeconds(2.0f);
        }
    }
    void CleanupOffScreenObjects()
    {

        // 카메라 아래로 벗어난 몬스터 제거
        GameObject[] allitem = GameObject.FindGameObjectsWithTag("Heal"); // 태그가 Monster인 오브젝트들
        foreach (GameObject Heal in allitem)
        {
            if (Heal.transform.position.y < mainCamera.transform.position.y - 5)
            {
                Destroy(Heal);
            }
        }
    }

    void Update()
    {

    }
}
