using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    //public static Player Instance;
    public Image healthBar;
    private bool _isFacingRight;
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private int _currentHealth;
    private int _maxHealth;
    public static Player Instance { get; private set; }// Singleton pattern
    public GameObject objectPool;
    private ObjectPool pool;
    [SerializeField] private PlayerData playerData;

    public int CurrentHealth { get; set; }   

    protected void Awake()
    {  
        _speed = playerData.speed;
        pool = objectPool.GetComponent<ObjectPool>();
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
         _maxHealth = playerData.maxHealth;
        _currentHealth = _maxHealth;
        healthBar.fillAmount = (float) _currentHealth / _maxHealth;
        _isFacingRight = true;
    }
  
    void Update()
    {
        Move();
        Flip();
        Attack();    
    }
    public void Move()
    {
        float hozirontalSpeed = Input.GetAxis("Horizontal") * Time.deltaTime * _speed;
        float verticalSpeed = Input.GetAxis("Vertical") * Time.deltaTime * _speed; // Update speed for player                   
        transform.Translate(Vector3.right * hozirontalSpeed);
        transform.Translate(Vector3.up * verticalSpeed);

        PreventInArea();
    }

    private void Flip()
    {
        float moveInput = Input.GetAxis("Horizontal");
        if (_isFacingRight && moveInput < 0 || !_isFacingRight && moveInput > 0)
        {
            _isFacingRight = !_isFacingRight;
            Vector3 direction = transform.localScale;
            direction.x *= -1; // Correctly flip the direction
            transform.localScale = direction;
        }
    }

    public float Speed
    {
        get { return _speed; }
        set { }  
    }

    public void Attack()
    {      
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 shootDirection = new Vector2(mousePosition.x - _firePoint.position.x, 
                                             mousePosition.y - _firePoint.position.y);
        shootDirection.Normalize();
                                   
        
        if (Input.GetMouseButtonDown(0))
        {
            // Create Bullet at _firePoint position
            GameObject bullet = pool.GetFromPool();
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            bulletScript.Rotate(shootDirection);
            
        }
    }

    public void PreventInArea()
    {
        // prevent player move out of range
        Vector3 newPosition = transform.position;
        newPosition.x = Mathf.Clamp(transform.position.x, -14f, 14f);
        newPosition.y = Mathf.Clamp(transform.position.y, -14f, 14f);
        transform.position = newPosition;   
    }

    public void GetDamage(int number)
    {
        _currentHealth -= number;
        if (_currentHealth == 0)
        {
            //_currentHealth = 0;
            Debug.Log("Game Over");
            SceneManager.LoadScene(0);
            Resources.UnloadUnusedAssets();
        }
        healthBar.fillAmount = (float) _currentHealth / _maxHealth;
    }

    public void AddHealth(int number)
    {
        //Debug.Log("player be add health");
        _currentHealth += number;
        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
        healthBar.fillAmount = (float) _currentHealth / _maxHealth;
    }
  
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))            
        {
            GetDamage(1);
        }     
        else if (collision.gameObject.CompareTag("HealthPot"))
        {
            AddHealth(1);
        }
    }
}





