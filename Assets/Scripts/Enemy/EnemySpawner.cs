using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyBossPrefab; // Prefab Enemy Boss
    public float spawnInterval = 5f; // Interval spawn Enemy Boss
    private float nextSpawnTime = 0f;

    void Update()
    {
        // Spawn musuh setelah interval
        if (Time.time > nextSpawnTime)
        {
            SpawnEnemyBoss();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnEnemyBoss()
    {
        // Spawn musuh di posisi acak
        float spawnX = Random.Range(-10f, 10f);
        float spawnY = Random.Range(-5f, 5f);
        Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0f);

        Instantiate(enemyBossPrefab, spawnPosition, Quaternion.identity); // Spawn Enemy Boss
    }
}
