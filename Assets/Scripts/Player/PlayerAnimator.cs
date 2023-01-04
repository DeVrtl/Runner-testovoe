using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Play(PlayerAnimations state)
    {
        _animator.Play(state.ToString());
    }
}

public enum PlayerAnimations
{
    Idle, Run
}