using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private float moveSpeed = -2f;
    [SerializeField] private Vector2 areaBounds = new Vector2(5f, 5f); // Batas antara area gerak pada asteroid
    private Rigidbody2D rb;
    private Vector2 currentDirection;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        SetRandomDirection();
    }

    void Update()
    {
        MoveAsteroid();
        CheckBounds();
    }

    public void StartRandomMovement()
    {
        SetRandomDirection();
    }

    private void SetRandomDirection()
    {
        currentDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        rb.velocity = currentDirection * moveSpeed;
    }

    private void MoveAsteroid()
    {
        rb.velocity = currentDirection * moveSpeed;
    }

    private void CheckBounds()
    {
        Vector2 position = transform.position;

        // Jika asteroid keluar dari batas area di sumbu X
        if (position.x > areaBounds.x || position.x < -areaBounds.x)
        {
            currentDirection.x = -currentDirection.x; // Balik lagi kearah pada sumbu X
            position.x = Mathf.Clamp(position.x, -areaBounds.x, areaBounds.x); // memastikan tetap di dalam batas scalenya
        }

        // Jika asteroid keluar dari batas area di sumbu Y
        if (position.y > areaBounds.y || position.y < -areaBounds.y)
        {
            currentDirection.y = -currentDirection.y; // Balik lagi kearah pada sumbu Y
            position.y = Mathf.Clamp(position.y, -areaBounds.y, areaBounds.y); // Pastikan tetap di dalam batas scalenya
        }

        // posisi kembali
        transform.position = position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Next to the next Level");

            if (GameManager.Instance != null && GameManager.Instance.LevelManager != null)
            {
                GameManager.Instance.LevelManager.LoadScene("Main");
            }
            else
            {
                Debug.LogWarning("GameManager atau LevelManager belum dimasukin!");
            }
        }
    }
}
