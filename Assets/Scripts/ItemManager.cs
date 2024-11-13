using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameObject[] Items; // ���� �迭
    public float minX = -4f; // x��ǥ �ּҰ�
    public float maxX = 4f; // x��ǥ �ִ밪
    public float minYInterval = 14f; // y��ǥ �ּ� ����
    public float maxYInterval = 28f; // y��ǥ �ִ� ����

    private Camera mainCamera; // ���� ī�޶� ����
    private float lastSpawnY = 0f; // ���������� ������ Y��ǥ

    void Start()
    {
        // ���� ī�޶� ����
        mainCamera = Camera.main;

        // ó�� �����ϴ� ��ƾ ����
        StartCoroutine(SpawnItem());
    }

    public void SpawnItem(GameObject prefab, Vector3 position) // ���� ��ġ ���� �Լ�
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

          
            int randomCount = Random.Range(1, 2); // 0~1 ���� ����

            for (int i = 0; i < randomCount; i++)
            {
                int randomIndex = Random.Range(0, Items.Length);
                GameObject selectedMonster = Items[randomIndex];
                Instantiate(selectedMonster, spawnPosition, Quaternion.identity);
            }

            // ������ ������ Y��ǥ ������Ʈ
            lastSpawnY = spawnY;

            // ���� ���� �� 1�� ���
            yield return new WaitForSeconds(2.0f);
        }
    }
    void CleanupOffScreenObjects()
    {

        // ī�޶� �Ʒ��� ��� ���� ����
        GameObject[] allitem = GameObject.FindGameObjectsWithTag("Heal"); // �±װ� Monster�� ������Ʈ��
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
