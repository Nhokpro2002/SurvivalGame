using Unity.Mathematics;
using UnityEngine;
//using static UnityEngine.ParticleSystem;

public class Bullet : MonoBehaviour, IMovable
{
    [Header("Field Bullet")]
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [Space(1)]
   
    [SerializeField] private BulletData bulletData; // ScripTable object to update cons for player

    private Vector2 _directon;   
   
    void Start()
    {
        _damage = bulletData.damage;
        _speed = bulletData.speed;              
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

    public void DeleteBulletOutOfRange()
    {
        /* Logic code not good
         if camerea follow player, position player out bound, bullet return pool immedeatly */
        if (math.abs(transform.position.x) > 16 || math.abs(transform.position.y) > 16)
        {
            ObjectPool.instance.ReturnToPool(gameObject);            
           // Debug.Log("destroy bullet");
        }
    }

    public void Rotate(Vector2 newDirection)
    {
        _directon = newDirection;
    }
}
