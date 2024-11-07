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

        // Mendapatkan komponen pada LevelManager
        LevelManager = GetComponent<LevelManager>();
        if (LevelManager == null)
        {
            Debug.LogWarning("LevelManager component menghilang pada GameManager.");
        }
    }
}
