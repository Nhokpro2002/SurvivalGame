using Unity.Mathematics;
using UnityEngine;

public class AmericanEnemyBullet : MonoBehaviour, IMovable
{

    private int _damage;
    private float _speed;
    public ParticleSystem bulletExplosion; // call when bullet collide with Player
    public GameObject player;
    private Vector2 target;
    public ParticleSystem enemyBulletExplosion; // call when bullet not collide with anything
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        _damage = 1;
        _speed = 5f;       
        target = new Vector2(player.transform.position.x,
                             player.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        Move(_speed);
              
    }

    public int Damage { get { return _damage; } }
    public float Speed { get { return _speed; } }

    public void Move(float _speed)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, _speed * Time.deltaTime);
        if (transform.position.x == target.x
            && transform.position.y == target.y)
        {
            Destroy(gameObject);
            Instantiate(enemyBulletExplosion, transform.position, transform.rotation);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(bulletExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

}
