using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Prefabs")]
    public GameObject meleeEnemyPrefab;
    public GameObject rangedEnemyPrefab;

    [Header("Spawn Area")]
    public BoxCollider2D spawnArea;

    [Header("Spawn Settings")]
    public int maxEnemies = 4;
    public float spawnInterval = 2f; // saniye

    private List<GameObject> currentEnemies = new List<GameObject>();
    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0f;
            CleanupDeadEnemies();

            if (currentEnemies.Count < maxEnemies)
            {
                SpawnEnemy();
            }
        }
    }

    void SpawnEnemy()
    {
        Vector2 spawnPos = GetRandomPositionInArea();
        GameObject enemyToSpawn = Random.value > 0.5f ? meleeEnemyPrefab : rangedEnemyPrefab;

        GameObject newEnemy = Instantiate(enemyToSpawn, spawnPos, Quaternion.identity);
        currentEnemies.Add(newEnemy);
    }

    Vector2 GetRandomPositionInArea()
    {
        Bounds bounds = spawnArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        return new Vector2(x, y);
    }

    void CleanupDeadEnemies()
    {
        currentEnemies.RemoveAll(e => e == null);
    }
}
