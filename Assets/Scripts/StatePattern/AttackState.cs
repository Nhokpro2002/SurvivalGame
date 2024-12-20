using UnityEngine;

public class AttackState : IState
{
    public void OnEnter(StateController playerState)
    {
        playerState.currentState = this;
    }

    public void OnExit(StateController playerState)
    {

    }

    public void UpdateState(StateController playerState)
    {

    }

    public void PlayAnimation(Animator animator)
    {
        animator.SetTrigger("Attack");
    }
}

