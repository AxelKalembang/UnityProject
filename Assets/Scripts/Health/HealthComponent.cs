using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int health;

    void Start()
    {
        health = maxHealth;
        Debug.Log($"{gameObject.name} initial health: {health}"); // Log initial health
    }

    public int GetHealth()
    {
        return health;
    }

    public void Subtract(int amount)
    {
        health -= amount;
        Debug.Log($"{gameObject.name} took {amount} damage, current health: {health}"); // Log damage taken and current health

        if (health <= 0)
        {
            health = 0;
            DestroyObject();
        }
    }

    private void DestroyObject()
    {
        Debug.Log($"{gameObject.name} Mati lu boy."); // Log when the object is destroyed
        Destroy(gameObject);
    }
}
