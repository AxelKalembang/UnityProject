using UnityEngine;

public class EnemyVertical : MonoBehaviour
{
    public float moveSpeed = 5f; // Kecepatan pergerakan
    private bool isMovingDown = true; // Arah pergerakan vertikal
    private float screenTop;
    private float screenBottom;

    void Start()
    {
        // Menghitung batas atas dan bawah layar
        screenTop = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 1, 0)).y; // Batas atas
        screenBottom = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0, 0)).y; // Batas bawah
    }

    void Update()
    {
        // Pergerakan dari atas ke bawah atau sebaliknya
        if (isMovingDown)
        {
            transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
        }

        // Jika sudah melewati batas layar, balikkan arah pergerakan
        if (transform.position.y <= screenBottom || transform.position.y >= screenTop)
        {
            isMovingDown = !isMovingDown;
            RespawnEnemy();
        }
    }

    // Fungsi untuk memposisikan ulang Enemy setelah keluar dari layar
    void RespawnEnemy()
    {
        // Mengatur posisi spawn secara acak, atau dapat disesuaikan dengan kebutuhan
        transform.position = new Vector3(Random.Range(-10f, 10f), screenTop, 0f);
    }
}
