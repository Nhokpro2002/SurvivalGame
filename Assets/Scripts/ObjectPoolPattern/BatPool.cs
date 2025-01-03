using System.Collections.Generic;
using UnityEngine;

public class BatPool : MonoBehaviour
{
    public static BatPool Instance; 
    public GameObject batEnemy; // Prefabs
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
            DontDestroyOnLoad(this);
        }
    }
    void Start()
    {
        // Find the fire point in the scene
        //initialTransform = GameObject.Find("SlimePool").transform;

        // Initialize the pool with inactive objects
        for (int i = 0; i < initialSize; i++)
        {
            GameObject obj = Instantiate(batEnemy);
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
            obj = Instantiate(batEnemy);
        }

        // Reset position and activate the object
        //obj.transform.position = initialTransform.position;
        //obj.transform.rotation = initialTransform.rotation; // Optional: Reset rotation
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
