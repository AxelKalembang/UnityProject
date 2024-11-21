using UnityEngine;

public class EnemyHorizontal : Enemy
{
    private bool isMovingRight = true; 
    private float screenLeft; 
    private float screenRight; 

    void Start()
    {
        
        screenLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0.5f, 0)).x + 1f;
        screenRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 0.5f, 0)).x - 1f;

        
        transform.position = new Vector3(
            Random.value < 0.5f ? screenLeft : screenRight,
            Random.Range(-4f, 4f), 
            0f
        );

        
        isMovingRight = transform.position.x < 0;
    }

    void Update()
    {
        
        if (isMovingRight)
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        else
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        
        if (transform.position.x <= screenLeft || transform.position.x >= screenRight)
            isMovingRight = !isMovingRight;
    }
}
