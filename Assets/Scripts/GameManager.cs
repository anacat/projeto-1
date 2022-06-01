using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int numberOfEnemiesKilled;
    public GameUIController uiController;

    [Header("Round Info")] public int currentRound = 0;
    public int maxNumberOfEnemies = 10;
    public int numberOfEnemiesPerSpawn = 1;
    public int enemyTypes = 1;
    public float enemySpawnTime = 1f;
    public float timeBetweenRounds;

    [Space(10)] public int numberOfEnemyIncrementPerRound;
    public float enemySpawnTimeIncrementPerRound;
    public int maxNumberOfEnemyIncrementPerRound;

    public List<EnemySpawnData> enemyList = new List<EnemySpawnData>();
    public List<Transform> spawnPositions = new List<Transform>();

    private float _spawnTimer;
    private float _betweenRoundTimer;
    private int _enemiesSpawned;

    private bool _isInRound = true;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else if (Instance == null)
        {
            Instance = this;
        }
    }

    private void UpdateUIText()
    {
        uiController.UpdateRoundInfo(string.Format("round: {0}\nspawn timer: " +
            "{1:0.0}\nbetween round timer: {2:0.0}", currentRound, _spawnTimer,
            _betweenRoundTimer));
    }

    private void Update()
    {
        if (_isInRound && _enemiesSpawned < maxNumberOfEnemies)
        {
            _spawnTimer += Time.deltaTime;

            if (_spawnTimer > enemySpawnTime)
            {
                int enemyToSpawn = Random.Range(0, enemyTypes);
                int spawnPoint = Random.Range(0, spawnPositions.Count);
                _enemiesSpawned++;

                Instantiate(enemyList[enemyToSpawn].enemyType, spawnPositions[spawnPoint].position,
                    Quaternion.identity);

                _spawnTimer = 0f;
            }
        }

        UpdateUIText();
    }

    public void EnemyKilled()
    {
        numberOfEnemiesKilled++;

        uiController.UpdateKills(numberOfEnemiesKilled, maxNumberOfEnemies);

        if (numberOfEnemiesKilled >= maxNumberOfEnemies)
        {
            //aumentamos a ronda
            ChangeRound();
        }
    }

    private void ChangeRound()
    {
        currentRound++;

        numberOfEnemiesKilled = 0;
        _enemiesSpawned = 0;
        maxNumberOfEnemies += maxNumberOfEnemyIncrementPerRound * currentRound;

        if (currentRound % 2 == 0) //para aumentar de 2 em 2 rondas
        {
            numberOfEnemiesPerSpawn += numberOfEnemyIncrementPerRound * currentRound;
        }

        if (currentRound >= 3 && enemyTypes < enemyList.Count)
        {
            enemyTypes += 1;
        }

        _spawnTimer = 0f;

        StartCoroutine(WaitBetweenRounds());
    }

    private IEnumerator WaitBetweenRounds()
    {
        _isInRound = false;
        
        _betweenRoundTimer = 0f;

        while (_betweenRoundTimer < timeBetweenRounds)
        {
            _betweenRoundTimer += Time.deltaTime;

            yield return null;
        }

        _betweenRoundTimer = 0f;

        _isInRound = true;
        
        uiController.UpdateKills(0, maxNumberOfEnemies);
    }
}

[Serializable]
public class EnemySpawnData
{
    public GameObject enemyType;
    public float spawnProbability;
}