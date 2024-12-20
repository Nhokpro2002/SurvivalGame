using UnityEngine;

public class TriangleMovement : MonoBehaviour
{
    public float speed;
    public PlayerData playerData;

    private void Awake()
    {
        speed = playerData.speed;
        //pool = (ObjectPool) Object.FindFirstObjectByType(typeof(Object));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}

