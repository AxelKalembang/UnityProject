using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Di sini bisa ditambahkan atribut dasar seperti health, damage, dan lain-lain
    public int health = 100;

    // Fungsi dasar yang bisa di-extend oleh EnemyHorizontal
    public virtual void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
