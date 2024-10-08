using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject Enemy1Prefab;
    public GameObject Enemy2Prefab; 
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy(Enemy1Prefab, new Vector3(2, 2, 0));
        SpawnEnemy(Enemy2Prefab, new Vector3(-1, 2, 0));

    }

    public void SpawnEnemy(GameObject prepab, Vector3 _position) //적의 스폰 위치 설정 틀
    {
        GameObject enemy = Instantiate(prepab);
        enemy.transform.position = _position;
        //enemy.GetComponent<Enemy>().Move;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
