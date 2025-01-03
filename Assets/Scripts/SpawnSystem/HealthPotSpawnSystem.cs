using UnityEngine;

public class HealthPotSpawnSystem : MonoBehaviour
{
    public GameObject Player;
    [SerializeField] private GameObject _healthPotPool;
    private HealthPotPool _pool;
    private float _time;
    // Start is called before the first frame update
    void Start()
    {      
        _pool = _healthPotPool.GetComponent<HealthPotPool>();      
        Player = GameObject.FindWithTag("Player");      
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        if (_time > 4)
        {
            Spawn();
            _time = 0;
        }
    }

    void Spawn()
    {
        float distance = Random.Range(-7, 7);

        // Tính tọa độ spawn dựa trên công thức tọa độ cực
        Vector2 spawnPosition = new Vector2(
            Player.transform.position.x +  distance,
            Player.transform.position.y +  distance
            );        
        GameObject healthPotPrefab = _pool.GetFromPool();
        healthPotPrefab.transform.position = spawnPosition;
    }
}
