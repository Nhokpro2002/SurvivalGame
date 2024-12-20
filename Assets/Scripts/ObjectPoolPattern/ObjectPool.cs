using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefab; // The object to pool
    public int initialSize = 10;
    private Transform _firePoint;

    private Queue<GameObject> pool = new Queue<GameObject>();

    void Start()
    {
        // Find the fire point in the scene
        _firePoint = GameObject.Find("FirePoint").transform;

        // Initialize the pool with inactive objects
        for (int i = 0; i < initialSize; i++)
        {
            GameObject obj = Instantiate(prefab);
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
            obj = Instantiate(prefab);
        }

        // Reset position and activate the object
        obj.transform.position = _firePoint.position;
        obj.transform.rotation = _firePoint.rotation; // Optional: Reset rotation
        obj.SetActive(true);

        return obj;
    }

    public void ReturnToPool(GameObject obj)
    {
        // Reset position to the fire point before deactivating
        obj.transform.position = _firePoint.position;
        obj.SetActive(false);

        // Return the object to the pool
        pool.Enqueue(obj);
    }
}
