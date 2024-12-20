using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public Image healthBar;
    //private Animator _animator;
    private bool _isFacingRight;
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private int _currentHealth;
    [SerializeField] private int _maxHealth;
    //[SerializeField] private Transform _healthBarTransform;
    //[SerializeField] private Camera _camera;
    public static Player Instance { get; private set; }// Singleton pattern
    public GameObject objectPool;
    private ObjectPool pool;
    [SerializeField] private PlayerData playerData;

    private void Awake()
    {
       // _camera = Camera.main;  
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
        _currentHealth = _maxHealth;
        healthBar.fillAmount = (float) _currentHealth / _maxHealth;
    }

    void Start()
    {
        _isFacingRight = true;
        //_animator = GetComponent<Animator>();
        //_speed = 5;
    }

    void Update()
    {
        Move();
        Flip();
        Attack();
        //_healthBarTransform.rotation = _camera.transform.rotation;
    }
    public void Move()
    {
        float hozirontalSpeed = Input.GetAxis("Horizontal") * Time.deltaTime * _speed;
        float verticalSpeed = Input.GetAxis("Vertical") * Time.deltaTime * _speed; // Update speed for player         
            //_animator.SetFloat("Moving", Mathf.Abs(moveInput)); // Use input to control animation
        transform.Translate(Vector3.right * hozirontalSpeed);
        transform.Translate(Vector3.up * verticalSpeed);

        if (math.abs(transform.position.x) > 20 || math.abs(transform.position.y) > 20)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
        // Call Prevent function to limit range movement for player
        Prevent();
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

    public void Prevent()
    {
        // prevent player move out of range
        Vector3 newPosition = transform.position;
        newPosition.x = Mathf.Clamp(transform.position.x, -20f, 20f);
        newPosition.y = Mathf.Clamp(transform.position.y, -20f, 20f);
        transform.position = newPosition;   
    }

    public void GetDamage(int number)
    {
        _currentHealth -= number;
        if (_currentHealth < 0)
        {
            _currentHealth = 0;
            Debug.Log("Game Over");
        }
        healthBar.fillAmount = (float) _currentHealth / _maxHealth;
    }

    public void AddHealth(int number)
    {
        _currentHealth += number;
        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
        healthBar.fillAmount = (float) _currentHealth / _maxHealth;
    }

    //public void OnTriggerEnter(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("SlimeEnemy"))
    //    {
    //        Debug.Log("have collsion");
    //        GetDamage(1);
    //    }
    //}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SlimeEnemy"))
        {
            //Debug.Log("have collsion");
            GetDamage(1);
        }
    }
}





