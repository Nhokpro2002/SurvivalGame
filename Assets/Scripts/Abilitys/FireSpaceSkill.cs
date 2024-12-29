using UnityEngine;
using System.Collections;

public class FireSpaceSkill : MonoBehaviour
{
    [SerializeField] private GameObject _player;   
 
    // Update is called once per frame
    protected void Awake()
    {
        _player = GameObject.FindWithTag("Player");      
              
    }
    void Update()
    {
       transform.position = _player.transform.position;
        if (this.gameObject != null) 
        {
            StartCoroutine(DestroyGameObjectAfterTime(3f));
        }

        //DestroyGameObjectAfterTime(3f);
    }

    private IEnumerator DestroyGameObjectAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

}
