//using System.Collections;
using UnityEngine;

public class SpawnEnemySystem : MonoBehaviour
{

    //public GameObject slimeEnemyPrefab;
    public GameObject player;
   // public SlimePool slimePool;
    public float safeRadius = 8f;  // Bán kính vùng cấm
    public float spawnRadius = 13f;
    private GameObject _slimePool;
    private SlimePool _pool;
    private void Start()
    {
        _slimePool = GameObject.FindWithTag("SlimePool");
        _pool = _slimePool.GetComponent<SlimePool>();
        InvokeRepeating("Spawn", 0.5f, 1f);
    }

    private void Update()
    {
        
    }

    public void Spawn()
    {
        // Sinh góc ngẫu nhiên trong phạm vi 0 - 360 độ
        float angle = Random.Range(0f, 360f);
        // Chuyển đổi góc sang radian
        float radian = angle * Mathf.Deg2Rad;

        // Tính khoảng cách spawn ngẫu nhiên nằm ngoài safeRadius và trong spawnRadius
        float distance = Random.Range(safeRadius + 1, spawnRadius);

        // Tính tọa độ spawn dựa trên công thức tọa độ cực
        Vector2 spawnPosition = new Vector2(
            player.transform.position.x + Mathf.Cos(radian) * distance,
            player.transform.position.y + Mathf.Sin(radian) * distance
            );
        // Nếu là 2D game


        // Sinh kẻ địch tại vị trí spawn
        //Instantiate(slimeEnemyPrefab, spawnPosition, Quaternion.identity);
        GameObject slimeEnemyPrefab = _pool.GetFromPool();
        slimeEnemyPrefab.transform.position = spawnPosition;
    }
}
