using UnityEngine;
using UnityEngine.UIElements;

public class GameUIManager : MonoBehaviour
{
    [Header("UI Elements")]
    public Label healthText;
    public Label pointsText;
    public Label waveText;
    public Label enemiesLeftText;

    [Header("Game References")]
    public CombatManager combatManager; // Referensi ke CombatManager

    public UIDocument UIDocument;

    private Player player; // Menggunakan Player dinamis
    private int points = 0; // Total poin pemain

    void OnEnable()
    {
        var root = UIDocument.rootVisualElement;
        var container = root.Q<VisualElement>("Container");
        var cont = root.Q<VisualElement>("Cont");

        healthText = cont.Q<Label>("Health");
        pointsText = cont.Q<Label>("Point");
        waveText = container.Q<Label>("Wave");
        enemiesLeftText = container.Q<Label>("Enemy");

        player = FindObjectOfType<Player>();
        if (player == null)
        {
            Debug.LogError("Player object not found in the scene!");
        }
    }

    void Update()
    {
        if (player != null)
        {
            healthText.text = "Health: " + player.health.ToString();
        }

        if (combatManager != null)
        {
            waveText.text = "Wave: " + combatManager.waveNumber.ToString();
            enemiesLeftText.text = "Enemies Left: " + combatManager.totalEnemies.ToString();
        }

        pointsText.text = "Points: " + points.ToString();
    }

    public void AddPoints(int enemyLevel)
    {
        points += enemyLevel;
    }
}
