using UnityEngine;

public class HeathPot : MonoBehaviour
{
    private GameObject _player;  

    private void Awake()
    {      
        _player = GameObject.FindWithTag("Player");   
        //if ( _player == null )
        //{
        //    Destroy(gameObject);
        //}
    }
   
    private void Update()
    {
        if (Vector2.Distance(_player.transform.position, transform.position) < 3)
        {
            //Vector2.MoveTowards(transform.position, _player.transform.position, 1.5f * Time.deltaTime);
            Vector2 newPosition = Vector2.MoveTowards(transform.position,
                                                      _player.transform.position,
                                                      10 * Time.deltaTime);

            // Assign the new position to the enemy's transform
            transform.position = newPosition;
        }

        transform.RotateAround(transform.position, Vector3.up, 3);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            HealthPotPool.Instance.ReturnToPool(gameObject);
        }
    }  
}
