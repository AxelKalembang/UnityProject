using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    PlayerMovement playerMovement;
    Animator animator;

    public int health = 100; // Health awal
    public int maxHealth = 100; // Health maksimal

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        animator = GameObject.Find("EngineEffect").GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        playerMovement.Move();
    }

    void LateUpdate()
    {
        animator.SetBool("IsMoving", playerMovement.IsMoving());
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            health = 0;
            Die();
        }
        Debug.Log($"Player took {damage} damage. Current health: {health}");
    }

    public void Heal(int amount)
    {
        health += amount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        Debug.Log($"Player healed by {amount}. Current health: {health}");
    }

    private void Die()
    {
        Debug.Log("Player has died!");
        
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            TakeDamage(10); 
            
        }
    }
}
