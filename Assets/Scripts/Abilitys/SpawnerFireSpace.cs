using UnityEngine.UI;
using UnityEngine;

public class SpawnerFireSpace : MonoBehaviour
{
    protected float _timeResetSkill = 2f;
    protected float _countDown;
    public Image _fireSpaceIcon; // Cover Layer
    //public FireBallData _fireBallData;
    public GameObject _fireSpace;
    // Start is called before the first frame update
    void Start()
    {
        //_timeResetSkill = _fireBallData.timeResetSkill;
        _countDown = _timeResetSkill;
        _fireSpaceIcon.fillAmount = _countDown / _timeResetSkill;
    }

    // Update is called once per frame
    void Update()
    {
        _countDown -= Time.deltaTime / 2;
        if (_countDown <= 0 && Input.GetKeyDown(KeyCode.F3))
        {
            GameObject fireSpace = Instantiate(_fireSpace);
            _countDown = _timeResetSkill;
        }
        _fireSpaceIcon.fillAmount = _countDown / _timeResetSkill;
    }
}
