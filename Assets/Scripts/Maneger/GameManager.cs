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
            Debug.Log("GameManager Sedang Dibuat.");
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Pastikan LevelManager ada sebagai komponen
        LevelManager = GetComponent<LevelManager>();
        if (LevelManager != null)
        {
            Debug.Log("LevelManager Berhasil dimasukin.");
        }
        else
        {
            Debug.LogWarning("LevelManager Tidak dapat dimasuki.");
        }
    }
}
