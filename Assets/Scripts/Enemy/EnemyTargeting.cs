using UnityEngine;

public class EnemyTargeting : MonoBehaviour
{
    public float moveSpeed = 5f; // Kecepatan musuh bergerak
    private Transform playerTransform; // Referensi ke posisi player
    private bool isDead = false; // Status musuh apakah sudah mati atau belum

    void Start()
    {
        // Mencari objek player di scene
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (isDead) return; // Jika musuh mati, tidak bergerak

        // Menggerakkan musuh menuju posisi player
        MoveTowardsPlayer();
    }

    void MoveTowardsPlayer()
    {
        // Menghitung arah menuju player
        Vector3 direction = playerTransform.position - transform.position;
        direction.Normalize(); // Menormalisasi agar kecepatan konstan

        // Menggerakkan musuh ke arah player
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    // Ketika musuh bertabrakan dengan player
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Menghancurkan musuh ketika bertabrakan dengan player
            Die();
        }
    }

    void Die()
    {
        // Menghancurkan musuh
        isDead = true; // Menandai musuh mati
        gameObject.SetActive(false); // Menonaktifkan objek musuh
        Destroy(gameObject, 1f); // Hancurkan objek setelah 1 detik untuk memberikan efek
    }
}
