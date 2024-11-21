using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Prefabs")]
    public Enemy spawnedEnemy;

    [SerializeField] private int minimumKillsToIncreaseSpawnCount = 3;
    public int totalKill = 0; 
    private int totalKillWave = 0;

    [SerializeField] private float spawnInterval = 3f;

    [Header("Spawned Enemies Counter")]
    public int spawnCount = 0;
    public int defaultSpawnCount = 1;
    public int spawnCountMultiplier = 1;
    public int multiplierIncreaseCount = 1;

    public CombatManager combatManager;

    public bool isSpawning = false;

    private void Start()
    {
        spawnCount = defaultSpawnCount;
    }

    public void StartSpawning()
    {
        if (!isSpawning && spawnedEnemy.level <= combatManager.waveNumber)
        {
            isSpawning = true;
            StartCoroutine(SpawnEnemies());
        }
    }

    public void StopSpawning()
    {
        isSpawning = false;
        StopAllCoroutines();
    }

private IEnumerator SpawnEnemies()
{
    int spawnedEnemies = 0; 

    while (spawnedEnemies < spawnCount)
    {
        
        if (spawnedEnemy != null)
        {
            SpawnEnemy(); 
            spawnedEnemies++;
        }
        else
        {
            Debug.LogWarning("SpawnedEnemy prefab is not assigned. Cannot spawn enemy.");
            break; 
        }

        
        yield return new WaitForSeconds(Random.Range(spawnInterval * 0.8f, spawnInterval * 1.2f)); 
    }

    
    if (spawnedEnemies >= spawnCount)
    {
        StopSpawning();
        Debug.Log($"All {spawnCount} enemies have been spawned.");
    }
}


    private void SpawnEnemy()
    {
        if (spawnedEnemy != null)
        {
            Enemy enemyInstance = Instantiate(spawnedEnemy);
            enemyInstance.GetComponent<Enemy>().combatmanager = combatManager;
            enemyInstance.GetComponent<Enemy>().spawner = this;
            combatManager.totalEnemies++;
        }
    }

public void OnEnemyKilled()
{
    totalKill++; 
    totalKillWave++; 

   
    if (totalKillWave == minimumKillsToIncreaseSpawnCount)
    {
        totalKillWave = 0; 
        spawnCount += spawnCountMultiplier; 
        
       
        if (spawnCountMultiplier < minimumKillsToIncreaseSpawnCount)
        {
            spawnCountMultiplier += multiplierIncreaseCount;
        }
    }

   
    Debug.Log($"Enemy defeated! Total: {totalKill}, Current SpawnCount: {spawnCount}, Multiplier: {spawnCountMultiplier}");
}

}
