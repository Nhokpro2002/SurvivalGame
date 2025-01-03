using UnityEngine;

public class SpawnEnemySystem : MonoBehaviour
{
    public float safeRadius = 8f;  // Bán kính vùng cấm
    public float spawnRadius = 13f;

    private void Start()
    {
        InvokeRepeating("SpawnSlimeEnemy", 1f, 1f); // call spawn function per 1s
        InvokeRepeating("SpawnBatEnemy", 1f, 2f); // same
    }

    public void SpawnSlimeEnemy()
    {
        float angle = Random.Range(0f, 360f);
        float radian = angle * Mathf.Deg2Rad;

        // Tính khoảng cách spawn ngẫu nhiên nằm ngoài safeRadius và trong spawnRadius
        float distance = Random.Range(safeRadius + 1, spawnRadius);

        // Tính tọa độ spawn dựa trên công thức tọa độ cực
        Vector2 spawnPosition = new Vector2(
            Player.Instance.transform.position.x + Mathf.Cos(radian) * distance,
            Player.Instance.transform.position.y + Mathf.Sin(radian) * distance
        );

        // Lấy kẻ địch từ Object Pool
        GameObject slimeEnemyPrefab = SlimePool.Instance.GetFromPool();
        slimeEnemyPrefab.transform.position = spawnPosition;
    }

    public void SpawnBatEnemy()
    {
        float angle = Random.Range(0f, 360f);
        float radian = angle * Mathf.Deg2Rad;

        // Tính khoảng cách spawn ngẫu nhiên nằm ngoài safeRadius và trong spawnRadius
        float distance = Random.Range(safeRadius + 1, spawnRadius);

        // Tính tọa độ spawn dựa trên công thức tọa độ cực
        Vector2 spawnPosition = new Vector2(
            Player.Instance.transform.position.x + Mathf.Cos(radian) * distance,
            Player.Instance.transform.position.y + Mathf.Sin(radian) * distance
        );

        // Lấy kẻ địch từ Object Pool
        GameObject batEnemyPrefab = BatPool.Instance.GetFromPool();
        batEnemyPrefab.transform.position = spawnPosition;
    }
}
