using UnityEngine;

public class EnemyHorizontal : MonoBehaviour
{
    public float moveSpeed = 5f; // Kecepatan pergerakan
    private bool isMovingRight = true; 
    private float screenLeft;
    private float screenRight;

    void Start()
    {
        // Menghitung batas kiri dan kanan layar
        screenLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0.5f, 0)).x; // Batas kiri
        screenRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 0.5f, 0)).x; // Batas kanan
    }

    void Update()
    {
       
        if (isMovingRight)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }

        
        if (transform.position.x <= screenLeft || transform.position.x >= screenRight)
        {
            isMovingRight = !isMovingRight;
            RespawnEnemy();
        }
    }

    
    void RespawnEnemy()
    {
        
        transform.position = new Vector3(screenRight, Random.Range(-5f, 5f), 0f);
    }
}
