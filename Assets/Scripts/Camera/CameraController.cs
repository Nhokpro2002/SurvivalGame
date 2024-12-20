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
    }
}
