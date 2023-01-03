using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private const string Run = nameof(Run);
    private const string Idle = nameof(Idle);

    public void PlayRunAnimation(Animator animator)
    {
        PlayAnimation(animator, Run);
    }

    public void PlayIdleAnimation(Animator animator)
    {
        PlayAnimation(animator, Idle);
    }

    private void PlayAnimation(Animator animator, string state)
    {
        animator.Play(state);
    }
}
