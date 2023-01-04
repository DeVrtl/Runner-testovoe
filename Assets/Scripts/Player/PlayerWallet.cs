using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerWallet : MonoBehaviour
{
    public int Value { get; private set; }

    public event UnityAction<int> MoneyChanged;

    public void Add(int value)
    {
        Value += value;
        MoneyChanged?.Invoke(Value);
    }
}
