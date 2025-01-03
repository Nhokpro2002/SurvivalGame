using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Camera follow player
    //Camera cam;
    public GameObject player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x,
                                         player.transform.position.y,
                                         -10);
        if (transform.position.x < -12 || transform.position.x > 12
            || transform.position.y < -12 || transform.position.y > 12)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        }
    }
}
