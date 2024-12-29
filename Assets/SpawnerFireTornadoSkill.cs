using UnityEngine.UI;
using UnityEngine;

public class SpawnerFireTornadoSkill : MonoBehaviour
{

    protected float _timeResetSkill;
    protected float _countDown;
    public Image _fireTornadoIcon; // Cover Layer
    public FireBallData _fireBallData;
    public GameObject _fireTornado;
    public Transform firePoint;
    //public GameObject _player;
    // Start is called before the first frame update
    void Start()
    {
       // _player = GameObject.FindWithTag("Player");
        _timeResetSkill = _fireBallData.timeResetSkill;
        _countDown = _fireBallData.timeResetSkill;
        _fireTornadoIcon.fillAmount = _countDown / _timeResetSkill;
    }

    // Update is called once per frame
    void Update()
    {
        _countDown -= Time.deltaTime;
        if (_countDown <= 0 && Input.GetKeyDown(KeyCode.F2))
        {
            SpawnFireTornadoSkill();
            _countDown = _timeResetSkill;
        }
        _fireTornadoIcon.fillAmount = _countDown / _timeResetSkill;
    }

    public void SpawnFireTornadoSkill()
    {
        Vector3 firePosition = new Vector3(firePoint.position.x, firePoint.position.y, firePoint.position.z);
        GameObject fireTornadoClone = Instantiate(_fireTornado, firePosition, Quaternion.identity);
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 shootDirection = new Vector2(mousePosition.x - firePoint.position.x,
                                             mousePosition.y - firePoint.position.y);
        shootDirection.Normalize();
        fireTornadoClone.GetComponent<FireStormAnility>().Rotate(shootDirection);

    }
}
