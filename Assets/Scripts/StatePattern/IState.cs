using UnityEngine;

public interface IState 
{
    public void OnEnter(StateController playerState);

    public void OnExit(StateController playerState);

    public void UpdateState(StateController playerState);

    public void PlayAnimation(Animator animator);

}
