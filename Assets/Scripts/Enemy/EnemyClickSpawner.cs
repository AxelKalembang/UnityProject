using UnityEngine;
using UnityEngine.Assertions;

public class EnemyClickSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyVariants;
    [SerializeField] private int selectedVariant = 0;

    private void Start()
    {
        Assert.IsTrue(enemyVariants.Length > 0, "tambahkan perfabs Enemy!");
    }

    private void Update()
    {
        for (int i = 1; i <= enemyVariants.Length; i++)
        {
            if (Input.GetKeyDown(i.ToString()))
            {
                selectedVariant = i - 1;
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        if (selectedVariant < enemyVariants.Length)
        {
            Instantiate(enemyVariants[selectedVariant], Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
        }
    }
}
