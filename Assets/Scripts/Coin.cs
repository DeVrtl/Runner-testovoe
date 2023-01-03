using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private PlayerMoney _player;
    [SerializeField] private int _reward;
    [SerializeField] private ParticleSystem _pickUpEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerMoney>(out PlayerMoney player))
        {
            player.AddMoney(_reward);
            Destroy(gameObject);
            _pickUpEffect.Play();
        }
    }
}
