using UnityEngine;

public class Enemy : MonoBehaviour
{
    public CombatManager combatmanager; 
    public EnemySpawner spawner; 
    public int level; 
    public float moveSpeed; 

    private void OnDestroy()
    {
        if (spawner != null && combatmanager != null)
        {
            spawner.OnEnemyKilled(); 
            combatmanager.OnEnemyKilled(); 

            
            GameUIManager uiManager = FindObjectOfType<GameUIManager>();
            if (uiManager != null)
            {
                uiManager.AddPoints(level);
            }
        }
    }
}
