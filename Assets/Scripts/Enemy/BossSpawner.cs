using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject BossEnemy;
    public Vector2[] spawnPosition = new Vector2[4];
    private float _time;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 10f, 5f);
    }
   
    public void Spawn()
    {
        int index = Random.Range(0, spawnPosition.Length);
        Instantiate(BossEnemy, spawnPosition[index], Quaternion.identity);
    }
}
