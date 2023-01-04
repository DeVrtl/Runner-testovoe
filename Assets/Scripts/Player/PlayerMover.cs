using UnityEngine;

[RequireComponent(typeof(PlayerAnimator))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _offsetSpeed;

    private Vector3 _lastMousePosition;
    private Vector3 _target;

    private void OnValidate()
    {
        _offsetSpeed = Mathf.Clamp(_offsetSpeed, 0, float.MaxValue);
        _speed = Mathf.Clamp(_speed, 0, float.MaxValue);
    }

    public void Move(Vector3 mousePosition)
    {
        float xDifference = 0;

        if (Input.GetMouseButton(0))
        {
            xDifference = mousePosition.x - _lastMousePosition.x;
            _lastMousePosition = mousePosition;
            transform.position = _target + transform.forward * _speed * Time.deltaTime;
        }

        _target = transform.position;
        _target.x += xDifference * Time.deltaTime * _offsetSpeed;
    }
}
