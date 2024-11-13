using UnityEngine;

public class EnemyHorizontal : MonoBehaviour
{
    public float moveSpeed = 5f; // Kecepatan pergerakan
    private bool isMovingRight = true; // Arah pergerakan horizontal
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
        // Pergerakan dari kiri ke kanan atau sebaliknya
        if (isMovingRight)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }

        // Jika sudah melewati batas layar, balikkan arah pergerakan
        if (transform.position.x <= screenLeft || transform.position.x >= screenRight)
        {
            isMovingRight = !isMovingRight;
            RespawnEnemy();
        }
    }

    // Fungsi untuk memposisikan ulang Enemy setelah keluar dari layar
    void RespawnEnemy()
    {
        // Mengatur posisi spawn secara acak, atau dapat disesuaikan dengan kebutuhan
        transform.position = new Vector3(screenRight, Random.Range(-5f, 5f), 0f);
    }
}
