using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerFireBallSkill : MonoBehaviour
{
    protected float _timeResetSkill;
    protected float _countDown;
    public Image _fireBallIcon; // Cover Layer
    public FireBallData _fireBallData;
    public GameObject _fireBall;
    // Start is called before the first frame update
    void Start()
    {
        _timeResetSkill = _fireBallData.timeResetSkill;
        _countDown = _fireBallData.timeResetSkill;
        _fireBallIcon.fillAmount = _countDown / _timeResetSkill;
    }

    // Update is called once per frame
    void Update()
    {
        _countDown -= Time.deltaTime / 2;
        if (_countDown <= 0 && Input.GetKeyDown(KeyCode.F1))
        {
            StartCoroutine(SpawnFireBallSkillCoroutine());
            _countDown = _timeResetSkill;
        }
        _fireBallIcon.fillAmount = _countDown / _timeResetSkill;
    }

    private IEnumerator SpawnFireBallSkillCoroutine()
    {
        for (int i = 0; i < 20; i++)
        {
            SpawnFireBallSkill();
            yield return new WaitForSeconds(1f);
        }
    }

    public void SpawnFireBallSkill()
    {
        float x = Random.Range(-8, 40);
        float y = Random.Range(20, 25);
        Vector3 spawnPosition = new Vector3(x, y, 0);

        // Create a rotation with -130 degrees around the Z-axis
        Quaternion rotation = Quaternion.Euler(0, 0, -130);

        // Instantiate the fireball with the specified position and rotation
        Instantiate(_fireBall, spawnPosition, rotation);
    }

}
