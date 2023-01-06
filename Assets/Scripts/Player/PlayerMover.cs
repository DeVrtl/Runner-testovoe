using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Vector2 _speed;

    private Rigidbody _rigidbody;
    private Vector3 _lastMousePosition;
    private Vector3 _target;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 mousePosition)
    {
        float deltaX = mousePosition.x - _lastMousePosition.x;
        _lastMousePosition = mousePosition;
        _rigidbody.position = _target + transform.forward * _speed.x * Time.deltaTime;

        _target = transform.position;
        _target.x += deltaX * Time.deltaTime * _speed.y;
    }
}
