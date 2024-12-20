using Unity.Mathematics;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Bullet : MonoBehaviour, IMovable
{
    [Header("Field Bullet")]
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [Space(1)]

    //[SerializeField] private ParticleSystem bulletExplosion;
    [SerializeField] private BulletData bulletData; // ScripTable object to update cons for player

    private Vector2 _directon;
    [SerializeField] private GameObject objectPool;
    private ObjectPool pool;
   
    void Start()
    {
        _damage = bulletData.damage;
        _speed = bulletData.speed;
        objectPool = GameObject.Find("ObjectPool");
         pool = objectPool.GetComponent<ObjectPool>();
       // _firePoint = GameObject.FindGameObjectWithTag("FirePoint").transform;
        //rb = GetComponent<Rigidbody2D>();
          
    }

    void Update()
    {
        Move(_speed);
        DeleteBulletOutOfRange(); // return pool
    }

    public int Damage { get { return _damage; } }
    public float Speed { get { return _speed; } }

    public void Move(float speed)
    {        
        transform.Translate(_directon * _speed * Time.deltaTime);
    }

    //public void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Enemy"))
    //    {
    //        Instantiate(bulletExplosion, transform.position, transform.rotation);
    //        pool.ReturnToPool(gameObject);
    //    }
    //}

    public void DeleteBulletOutOfRange()
    {
        /* Logic code not good
         if camerea follow player, position player out bound, bullet return pool immedeatly */
        if (math.abs(transform.position.x) > 16 || math.abs(transform.position.y) > 16)
        {
            pool.ReturnToPool(gameObject);            
           // Debug.Log("destroy bullet");
        }
    }

    public void Rotate(Vector2 newDirection)
    {
        _directon = newDirection;
    }
}
