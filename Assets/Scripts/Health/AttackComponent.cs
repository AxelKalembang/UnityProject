using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class AttackComponent : MonoBehaviour
{
    [SerializeField] public int damage = 10;
    [SerializeField] private Bullet bullet;

    private void Awake()
    {
        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            collider.isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(gameObject.tag))
        {
            return;
        }

        HitboxComponent hitbox = other.GetComponent<HitboxComponent>();
        if (hitbox != null)
        {
            InvincibilityComponent invincibility = other.GetComponent<InvincibilityComponent>();
            if (invincibility != null)
            {
                invincibility.TriggerInvincibility();
            }

            hitbox.Damage(damage);
        }
    }
}
