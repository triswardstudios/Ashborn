using UnityEngine;

public class PlayerAnimationManager : MonoSingleton<PlayerAnimationManager>
{
    [SerializeField] Animator animator;
    [SerializeField] string state = "State";
    [SerializeField] string StateTrigger = "StateChanged";

    public void PlayerCraftonBasicWorkbench(bool working)
    {
        animator.SetInteger(state, (working) ? 1 : 0);
        if(working) animator.SetTrigger(StateTrigger);
    }
}
