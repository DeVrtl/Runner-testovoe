using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _reward;
    [SerializeField] private ParticleSystem _pickUpEffect;

    public int Collect()
    {
        Instantiate(_pickUpEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        return _reward;
    }
}
