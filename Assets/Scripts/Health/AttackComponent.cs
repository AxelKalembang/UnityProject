using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class AttackComponent : MonoBehaviour
{
    [SerializeField] public int damage = 10;
    [SerializeField] private Bullet bullet;

    private Collider2D collider;

    private void Awake()
    {
        collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            collider.isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Skip if colliding with itself
        if (other.CompareTag(gameObject.tag))
        {
            return;
        }

        
        HitboxComponent hitbox = other.GetComponent<HitboxComponent>();
        if (hitbox == null)
        {
            Debug.LogWarning("HitboxComponent tidak ditemukan");
            return;
        }

        
        InvincibilityComponent invincibility = other.GetComponent<InvincibilityComponent>();
        if (invincibility != null && invincibility.isInvincible)
        {
            Debug.Log("Target is invincible, skipping damage.");
            return; 
        }

        
        hitbox.Damage(damage);

        
        if (invincibility != null)
        {
            invincibility.TriggerInvincibility();
        }

        
        PlayAttackFeedback();
    }

    private void PlayAttackFeedback()
    {
        
        Debug.Log("Terkena serangan: " + damage);
        
    }
}
