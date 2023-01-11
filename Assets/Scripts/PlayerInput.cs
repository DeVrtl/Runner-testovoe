using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    private Camera _camera;
    private Vector3 _lastMousePosition;
    private Vector3 _mousePosition => _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));

    public float DeltaX => _mousePosition.x - _lastMousePosition.x;

    public event UnityAction MouseDowned;
    public event UnityAction MouseUped;
    public event UnityAction MousePushed;


    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseDowned?.Invoke();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            MouseUped?.Invoke();
        }
        else if (Input.GetMouseButton(0))
        {
            MousePushed?.Invoke();
            _lastMousePosition = _mousePosition;
        }
    }
}
