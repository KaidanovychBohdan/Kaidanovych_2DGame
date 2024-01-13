using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    public int ChestCost;

    [SerializeField] private CoinTestAddRem _coins;

    public void BuyAndOpen() 
    {
        _coins.RemoveCoins(ChestCost);
        Debug.Log("Bought and opened one");
    }

    public void BuyAndOpen10()
    {
        _coins.RemoveCoins(ChestCost * 10);
        Debug.Log("Bought and opened ten");
    }
}
