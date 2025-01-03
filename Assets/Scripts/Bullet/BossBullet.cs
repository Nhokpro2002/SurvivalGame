using UnityEngine;

public class BossBullet : MonoBehaviour
{
    private float _bulletSpeed = 10f;
    private Vector2 _direction;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_direction * _bulletSpeed * Time.deltaTime);
    }

    public void Rotate(Vector2 newDirection)
    {
        _direction = newDirection;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
