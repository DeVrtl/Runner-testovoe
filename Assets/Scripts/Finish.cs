using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Finish : MonoBehaviour
{
    public event UnityAction Reached;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            Reached?.Invoke();
        }
    }
}
