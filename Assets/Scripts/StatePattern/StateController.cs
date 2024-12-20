using UnityEngine;
// Attached this script to Player
public class StateController : MonoBehaviour
{

    public IState currentState;
    private Animator _animator;
    public IdleState idleState = new IdleState();
    public MoveState moveState = new MoveState();
    public AttackState attackState = new AttackState();

    // Start is called before the first frame update
    void Start()
    {
        //_player = GetComponent<Player>();
        _animator = GetComponent<Animator>();
        currentState = idleState;
        currentState.OnEnter(this);
        //currentState.PlayAnimation(animator);
    }

    // Update is called once per frame
    void Update()
    {
        ChangeState();
        currentState.PlayAnimation(_animator);
    }

    public void ChangeState()
    {
        if ((Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0))
        {
            currentState = moveState;
            //Debug.Log("trang thai duoc thay doi");
        }
        //else if (Input.GetMouseButtonDown(0))
        //{
        //    currentState = attackState;
        //}
        else
        {
            currentState = idleState;
        }
    }

}




