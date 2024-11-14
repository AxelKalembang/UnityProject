using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public int health = 100;

    
    public virtual void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
