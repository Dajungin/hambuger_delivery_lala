using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] monsterPrefabs; // ���� ���� �迭
    public float minX = -5f; // x��ǥ �ּҰ�
    public float maxX = 5f; // x��ǥ �ִ밪
    public float minYInterval = 7f; // y��ǥ �ּ� ����
    public float maxYInterval = 10f; // y��ǥ �ִ� ����

    private Camera mainCamera; // ���� ī�޶� ����
    private float lastSpawnY = 0f; // ���������� ���Ͱ� ������ Y��ǥ

    void Start()
    {
        // ���� ī�޶� ����
        mainCamera = Camera.main;

        // ó�� ���͸� �����ϴ� ��ƾ ����
        StartCoroutine(SpawnMonster());
    }

    public void SpawnEnemy(GameObject prefab, Vector3 position) // ���� ���� ��ġ ���� �Լ�
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

            // 0 �Ǵ� 1������ ���͸� �����ϰ� ����
            int randomCount = Random.Range(1, 2); // 0~1 ���� ����

            for (int i = 0; i < randomCount; i++)
            {
                int randomIndex = Random.Range(0, monsterPrefabs.Length);
                GameObject selectedMonster = monsterPrefabs[randomIndex];
                Instantiate(selectedMonster, spawnPosition, Quaternion.identity);
            }

            // ������ ������ Y��ǥ ������Ʈ
            lastSpawnY = spawnY;

            // ���� ���� �� 1�� ���
            yield return new WaitForSeconds(1.0f);
        }
    }
    void CleanupOffScreenObjects()
    {

        // ī�޶� �Ʒ��� ��� ���� ����
        GameObject[] allMonsters = GameObject.FindGameObjectsWithTag("Monster"); // �±װ� Monster�� ������Ʈ��
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
