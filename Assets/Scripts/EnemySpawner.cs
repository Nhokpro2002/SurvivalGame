using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject triangle;
    public GameObject player; // Circle
    //public double radius;
    public float safeRadius = 5f;  // Bán kính vùng cấm
    public float spawnRadius = 10f;
    //public GameObject player; // Circle
    // Start is called before the first frame update
    public SlimePool slimePool;
    //private GameObject
    void Start()
    {
        
        InvokeRepeating("Spawn", 1f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        // Sinh góc ngẫu nhiên trong phạm vi 0 - 360 độ
        float angle = Random.Range(0f, 360f);
        // Chuyển đổi góc sang radian
        float radian = angle * Mathf.Deg2Rad;

        // Tính khoảng cách spawn ngẫu nhiên nằm ngoài safeRadius và trong spawnRadius
        float distance = Random.Range(safeRadius, spawnRadius);

        // Tính tọa độ spawn dựa trên công thức tọa độ cực
        Vector2 spawnPosition = new Vector2(
            player.transform.position.x + Mathf.Cos(radian) * distance,
            player.transform.position.y + Mathf.Sin(radian) * distance
            );
             // Nếu là 2D game
        

        // Sinh kẻ địch tại vị trí spawn
        Instantiate(triangle, spawnPosition, Quaternion.identity);
        
    }

    
}
