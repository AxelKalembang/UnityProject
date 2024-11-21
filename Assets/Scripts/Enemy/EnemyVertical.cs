using UnityEngine;

public class EnemyVertical : Enemy
{
    private bool isMovingDown = true; 
    private float screenTop; 
    private float screenBottom; 

    void Start()
    {
        
        screenTop = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 1, 0)).y;
        screenBottom = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0, 0)).y;

        
        transform.position = new Vector3(
            Random.Range(-7f, 7f), 
            Random.value < 0.5f ? screenTop : screenBottom,
            0f
        );

        
        isMovingDown = transform.position.y > 0;
    }

    void Update()
    {
        
        if (isMovingDown)
            transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
        else
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);

        
        if (transform.position.y <= screenBottom || transform.position.y >= screenTop)
            isMovingDown = !isMovingDown;
    }
}
