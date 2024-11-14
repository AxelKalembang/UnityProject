using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
    public float moveSpeed = 5f; 
    public Weapon weapon; 
    private bool isMovingRight = true; 
    private float screenLeft;
    private float screenRight;

    void Start()
    {
        
        screenLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0.5f, 0)).x; 
        screenRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 0.5f, 0)).x; 

        if (weapon != null)
        {
            weapon.StartShooting(); 
        }
        else
        {
            Debug.LogWarning("Weapon component is not assigned to EnemyBoss.");
        }
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
