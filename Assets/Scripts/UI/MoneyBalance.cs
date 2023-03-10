using UnityEngine;
using TMPro;

public class MoneyBalance : MonoBehaviour
{
    [SerializeField] private TMP_Text _money;
    [SerializeField] private PlayerWallet _player;

    private void OnEnable()
    {
        _player.MoneyChanged += OnMoneyChanged;
    }

    private void OnDisable()
    {
        _player.MoneyChanged -= OnMoneyChanged;
    }

    private void OnMoneyChanged(int money)
    {
        _money.text = money.ToString();
    }
}
