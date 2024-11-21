using UnityEngine;

public class EnemyBoss : Enemy
{
    public Weapon weapon; 
    private bool isMovingRight = true; 
    private float screenLeft; 
    private float screenRight; 

    void Start()
    {
        // Hitung batas layar
        screenLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0.5f, 0)).x;
        screenRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 0.5f, 0)).x;

        // Mulai menembak jika senjata ada
        if (weapon != null)
            weapon.StartShooting();
        else
            Debug.LogWarning("Senjata tidak diatur di EnemyBoss.");
    }

    void Update()
    {
        // Gerak horizontal
        if (isMovingRight)
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        else
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        // Balik arah jika melewati batas layar
        if (transform.position.x <= screenLeft || transform.position.x >= screenRight)
            isMovingRight = !isMovingRight;
    }
}
