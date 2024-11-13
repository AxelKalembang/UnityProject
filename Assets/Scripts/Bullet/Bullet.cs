using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Stats")]
    public float bulletSpeed = 20f; // Kecepatan peluru
    public int damage = 10; // Damage yang diberikan oleh peluru
    private Rigidbody2D rb; // Referensi ke Rigidbody2D untuk mengatur physics
    private IObjectPool<Bullet> pool; // Pool yang digunakan untuk mengelola objek bullet

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogWarning("Rigidbody2D tidak ditemukan pada Bullet.");
        }
    }

    // Metode untuk mengatur pool ke bullet
    public void SetPool(IObjectPool<Bullet> pool)
    {
        this.pool = pool;
    }

    // Metode untuk menembakkan peluru
    public void Fire()
    {
        // Menetapkan kecepatan peluru ke atas saat ditembakkan
        if (rb != null)
        {
            rb.velocity = Vector2.up * bulletSpeed;
        }
    }

    // Ketika peluru bertabrakan dengan objek lain, kembalikan ke pool
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Obstacle"))
        {
            if (pool != null)
            {
                pool.Release(this); // Kembalikan ke pool
            }
        }
    }

    // Ketika peluru keluar dari layar, kembalikan ke pool
    private void OnBecameInvisible()
    {
        if (pool != null)
        {
            pool.Release(this); // Kembalikan ke pool jika keluar dari layar
        }
    }

    void Update()
    {
        Vector2 position = transform.position;
        position = new Vector2(position.x, position.y + bulletSpeed * Time.deltaTime);
        transform.position = position;

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        if (transform.position.y > max.y)
        {
            if (pool != null)
            {
                pool.Release(this);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
