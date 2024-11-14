using UnityEngine;

public class DownWardBullet : MonoBehaviour
{
    [Header("Bullet Stats")]
    public float bulletSpeed = 20f; 
    public int damage = 10; 

    private Rigidbody2D rb; 
    private Vector2 shootDirection = Vector2.down; 

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogWarning("Rigidbody2D is not found on DownWardBullet.");
        }
    }

   
    public void Fire()
    {
        if (rb != null)
        {
            rb.velocity = shootDirection * bulletSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
    
        if (other.CompareTag("Player") || other.CompareTag("Obstacle"))
        {
            
            HitboxComponent hitbox = other.GetComponent<HitboxComponent>();
            if (hitbox != null)
            {
                hitbox.Damage(damage);
            }

            
            Destroy(gameObject);
        }
    }

    
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
