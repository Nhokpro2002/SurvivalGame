using UnityEngine;

public class TriangleMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private void Start()
    {
       rb = GetComponent<Rigidbody2D>(); 
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            rb.velocity = new Vector2(10, 0);
            //rb.AddForce(rb.velocity);
        }

    }
}

