using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform[] spawnPoints;

    [SerializeField] private float spawnInterval = 5f;
    [SerializeField] private float minSpawnInterval = 0.5f;

    private float timer;

    public float SpawnInterval => spawnInterval;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        if (spawnPoints.Length == 0)
            return;

        int randomIndex =
            Random.Range(0, spawnPoints.Length);

        Transform spawnPoint =
            spawnPoints[randomIndex];

        Instantiate(
            enemyPrefab,
            spawnPoint.position,
            Quaternion.identity);
    }

    public void ReduceSpawnTime(float amount)
    {
        spawnInterval -= amount;

        spawnInterval =
            Mathf.Max(
                minSpawnInterval,
                spawnInterval);

        Debug.Log($"Spawn Interval = {spawnInterval}");
    }
}