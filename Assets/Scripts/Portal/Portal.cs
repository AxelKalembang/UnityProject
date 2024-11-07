using UnityEngine;

public class Asteroid : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger detected"); // Debug tambahan

        if (other.CompareTag("Player"))
        {
            Debug.Log("Asteroid triggered by the player! Loading next scene...");

            // Memanggil LevelManager melalui GameManager untuk memuat scene "Main"
            if (GameManager.Instance != null && GameManager.Instance.LevelManager != null)
            {
                Debug.Log("GameManager and LevelManager found, loading scene...");
                GameManager.Instance.LevelManager.LoadScene("Main");
            }
            else
            {
                Debug.LogWarning("GameManager or LevelManager instance is missing!");
            }
        }
    }
}
