using UnityEngine;

public class EnemyTargeting : MonoBehaviour
{
    public float moveSpeed = 5f; // Kecepatan musuh bergerak
    private Transform playerTransform; // Referensi ke posisi player
    private bool isDead = false; // Status musuh 

    void Start()
    {
        // Mencari objek player di scene
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogWarning("Player tidak ditemukan di scene. Pastikan Player memiliki tag 'Player'.");
        }
    }

    void Update()
    {
        if (isDead || playerTransform == null) return; 

        
        MoveTowardsPlayer();
    }

    void MoveTowardsPlayer()
    {
        
        Vector3 direction = playerTransform.position - transform.position;
        direction.Normalize(); 

        Debug.Log("Direction to Player: " + direction); 

        
        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            Die();
        }
    }

    void Die()
    {
        
        isDead = true; 
        gameObject.SetActive(false); 
    }
}
