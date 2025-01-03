using System.Collections.Generic;
using UnityEngine;

public class HealthPotPool : MonoBehaviour
{
    public static HealthPotPool Instance;
    public GameObject HealthPot; // Prefabs
    public int initialSize = 5;
    //private Transform initialTransform;

    private Queue<GameObject> pool = new Queue<GameObject>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    void Start()
    {
        
        for (int i = 0; i < initialSize; i++)
        {
            GameObject obj = Instantiate(HealthPot);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }

    public GameObject GetFromPool()
    {
        GameObject obj;

        // Check if pool has an available object
        if (pool.Count > 0)
        {
            obj = pool.Dequeue();
        }
        else
        {
            // If the pool is empty, create a new object
            obj = Instantiate(HealthPot);
        }
        
        obj.SetActive(true);
        return obj;
    }

    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);

        // Return the object to the pool
        pool.Enqueue(obj);
    }
}
