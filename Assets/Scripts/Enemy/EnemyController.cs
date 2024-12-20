using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float _speed;
    private int _health;
    public EnemyData enemyData;
    public GameObject player; 
    public Animator animator;
    public SlimePool pool;
    private GameObject _slimePool;
    
    // Start is called before the first frame update
    void Start()
    {
        _slimePool = GameObject.FindWithTag("SlimePool");
        pool = _slimePool.GetComponent<SlimePool>();    
        player = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
        _speed = enemyData.speed;
        _health = enemyData.health; 
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        if (Vector2.Distance(player.transform.position, transform.position) > 0.5)
        {
            Vector2.MoveTowards(transform.position, player.transform.position, _speed * Time.deltaTime);
            Vector2 newPosition = Vector2.MoveTowards(transform.position,
                                                      player.transform.position,
                                                      _speed * Time.deltaTime);                                                  

            // Assign the new position to the enemy's transform
            transform.position = newPosition;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            //_health--;          
            if (_health-- == 0)
            {               
                animator.Play("SlimeDealth");                
                StartCoroutine(ReturnToPoolAfterDelay(0.2f));                
            }
        }     
    }

    private IEnumerator ReturnToPoolAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);        
        pool.ReturnToPool(gameObject);
    }

    private void OnEnable()
    {
        _speed = enemyData.speed;
        _health = enemyData.health;
    }

}
