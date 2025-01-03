using System.Collections;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    public int _bossHealth = 5;
    private Animator _bossAnimator;
    private float _bossSpeed;
    public GameObject Player;
    public GameObject bossBullet;
    private float _time;

    // Start is called before the first frame update
    void Start()
    {
        _bossSpeed = 3;
        _bossAnimator = GetComponent<Animator>();
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        _time += Time.deltaTime;
        if (_time > 2f)
        {
            Attack();
            _time = 0;
        }
        //Attack();
    }

    public void Move()
    {
        if (Vector2.Distance(Player.transform.position, transform.position) > 7)
        {
            Vector2.MoveTowards(transform.position, Player.transform.position, _bossSpeed * Time.deltaTime);
            Vector2 newPosition = Vector2.MoveTowards(transform.position,
                                                      Player.transform.position,
                                                      _bossSpeed * Time.deltaTime);

            // Assign the new position to the enemy's transform
            transform.position = newPosition;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("HealthPot")
            || collision.gameObject.CompareTag("Enemy"))
        {
            return;
        }
        else 
        {
            _bossHealth--;
            if (_bossHealth == 0)
            {
                this._bossSpeed = 0;
                _bossAnimator.Play("BossDealthAnim");
                StartCoroutine(DestroyAfterDelay(0.25f));
            }            
        }
    }

    private IEnumerator DestroyAfterDelay(float delay) // destroy this game object if health = 0
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }

    public void Attack()
    {
        Vector2 shootDirection = new Vector2(Player.transform.position.x - this.transform.position.x,
                                             Player.transform.position.y - this.transform.position.y).normalized;
        if (Vector2.Distance(transform.position, Player.transform.position) < 7)
        {
            GameObject bullet = Instantiate(bossBullet, transform.position, Quaternion.identity);
            BossBullet bulletScript = bullet.GetComponent<BossBullet>();
            bulletScript.Rotate(shootDirection);
        }
    }
}
