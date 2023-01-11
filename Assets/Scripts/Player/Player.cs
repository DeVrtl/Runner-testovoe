using UnityEngine;

[RequireComponent(typeof(PlayerWallet), typeof(PlayerCollisionHandler), typeof(PlayerMover))]
[RequireComponent(typeof(PlayerAnimator))]
public class Player : MonoBehaviour
{
    [SerializeField] private PlayerInput _input;

    private PlayerWallet _wallet;
    private PlayerCollisionHandler _collisionHandler;
    private PlayerAnimator _animator;
    private PlayerMover _mover;

    private void Awake()
    {
        _wallet = GetComponent<PlayerWallet>();
        _collisionHandler = GetComponent<PlayerCollisionHandler>();
        _input = GetComponent<PlayerInput>();
        _animator = GetComponent<PlayerAnimator>();
        _mover = GetComponent<PlayerMover>();
    }

    private void OnEnable()
    {
        _collisionHandler.CoinCollected += OnCoinCollected;
        _input.MouseDowned += OnMouseDowned;
        _input.MouseUped += OnMouseUped;
        _input.MousePushed += OnMousePushed;
    }

    private void OnDisable()
    {
        _collisionHandler.CoinCollected -= OnCoinCollected;
        _input.MouseDowned -= OnMouseDowned;
        _input.MouseUped -= OnMouseUped;
        _input.MousePushed -= OnMousePushed;
    }

    private void OnCoinCollected(Coin coin) 
    {
        _wallet.Add(coin.Collect());
    }

    private void OnMouseDowned()
    {
        _animator.Play(PlayerAnimations.Run);
    }

    private void OnMouseUped()
    {
        _animator.Play(PlayerAnimations.Idle);
    }

    private void OnMousePushed()
    {
        _mover.Move(_input.DeltaX);
    }
}