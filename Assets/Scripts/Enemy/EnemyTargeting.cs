using UnityEngine;

public class EnemyTargeting : Enemy
{
    private Transform playerTransform; 

    void Start()
    {
       
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
            playerTransform = player.transform;
        else
            Debug.LogWarning("Player tidak ditemukan. Pastikan memiliki tag 'Player'.");
    }

    void Update()
    {
        if (playerTransform == null) return;

        
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
    }
}
