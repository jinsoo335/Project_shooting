using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject EnemyPrefab;
    private void Start()
    {
        SpawnEnemy(EnemyPrefab, new Vector2(-1, 0));
    }
    void SpawnEnemy(GameObject prefab, Vector2 position)
    {
        GameObject enemy = Instantiate(prefab);
        enemy.transform.position = position;

    }
}
