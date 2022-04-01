using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float yOffset;
    public int numberOfEnemies;
    public float spawnAreaRadius;

    public List<GameObject> enemyList = new List<GameObject>();

    void Start()
    {
    }

    void Update()
    {
        if (InputController.Instance.SpawnEnemyButton())
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        Vector2 randomPos = Random.insideUnitCircle;
        Vector3 enemyPos = transform.position + (new Vector3(randomPos.x, 0f, randomPos.y) * spawnAreaRadius);
        
        GameObject enemy = Instantiate(enemyPrefab, enemyPos, Quaternion.identity, transform);
        enemy.transform.position += new Vector3(0f, yOffset, 0f);

        enemyList.Add(enemy);
    }
}