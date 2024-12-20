using UnityEngine;

public class IdleState : IState
{

    //StateController playerState;    

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
        animator.SetFloat("Moving", -1);
    }
   
}
