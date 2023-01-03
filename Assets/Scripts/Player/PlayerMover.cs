using UnityEngine;

[RequireComponent(typeof(Animator), typeof(PlayerAnimator))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _speed;
    [SerializeField] private float _offsetSpeed;

    private Vector3 _lastMousePosition;
    private Vector3 _mousePosition;
    private Vector3 _target;
    private Animator _animator;
    private PlayerAnimator _playerAnimator;

    private void OnValidate()
    {
        _offsetSpeed = Mathf.Clamp(_offsetSpeed, 0, float.MaxValue);
        _speed = Mathf.Clamp(_speed, 0, float.MaxValue);
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerAnimator = GetComponent<PlayerAnimator>();
    }

    private void Update()
    {
        float xDifference = 0;

        if (Input.GetMouseButton(0))
        {
            _mousePosition = _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
            xDifference = _mousePosition.x - _lastMousePosition.x;
            _lastMousePosition = _mousePosition;
            transform.position = _target + transform.forward * _speed * Time.deltaTime;

            _playerAnimator.PlayRunAnimation(_animator);
        }
        else
        {
            _playerAnimator.PlayIdleAnimation(_animator);
        }

        _target = transform.position;
        _target.x += xDifference * Time.deltaTime * _offsetSpeed;
    }
}
