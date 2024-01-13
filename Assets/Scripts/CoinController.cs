using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour, Icoin
{
    [SerializeField] private string _coinName = "";
    [SerializeField] private int _coinAmount = 0;

    public string name
    {
        get => _coinName;
        set => _coinName = value;
    }

    public int amount 
    { 
        get => _coinAmount; 
        set => _coinAmount = value;
    }

    private void Start()
    {
        name = "Gold";
    }

    public void AddCoins(int count)
    {
        if (count < 0)
            return;

        amount += count;
    }

    public void RemoveCoins(int count)
    {
        if (count < 0)
            return;

        if (_coinAmount >= count)
            amount -= count;
    }
}

