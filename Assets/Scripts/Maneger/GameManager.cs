using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public LevelManager LevelManager { get; private set; }

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

        // Mendapatkan komponen LevelManager
        LevelManager = FindObjectOfType<LevelManager>();  // Menggunakan FindObjectOfType jika LevelManager ada di tempat terpisah
        if (LevelManager == null)
        {
            Debug.LogWarning("LevelManager component tidak ditemukan pada GameManager.");
        }
    }
}
