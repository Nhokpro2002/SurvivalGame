using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallAbility : MonoBehaviour
{
    private float _speed;
    private int _damage;
   
    public FireBallData fireBallData;   
   
    void Start()
    {       
        _speed = fireBallData.fireBallSpeed;
        _damage = fireBallData.firBallDamage;              
    }

    // Update is called once per frame
    void Update()
    {       
        Move();
        if (transform.position.y < -20)
        {
            Destroy(gameObject);
        }      
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {           
            // Phá hủy đối tượng Enemy
            Destroy(collision.gameObject);           
        }
    }

    private IEnumerator DestroyAfterDelay(GameObject target, float delay)
    {
        yield return new WaitForSeconds(delay);

        // Kiểm tra xem đối tượng vẫn tồn tại trước khi hủy
        if (target != null)
        {
            Destroy(target);
        }
        //Destroy(gameObject.);
    }


    public void Move()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime);
    }

    private void OnEnable()
    {
        _speed = fireBallData.fireBallSpeed;
        _damage = fireBallData.firBallDamage;
    }
}
