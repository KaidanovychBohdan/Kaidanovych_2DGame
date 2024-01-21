using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Zenject;

public enum DropType
{
    Common,       //50%
    Rare,        //25%
    Epic,       //20%
    Legendary  //5%
}

public class OpenChest : MonoBehaviour
{
    public int ChestCost;

    [Inject] private Icoin _coins;

    [SerializeField] private DropFromBox _dropFromBox;

    private RandomDropByType _randomDropGenerator;

    private OpenChestUI _openChestUI;

    //public event Action<bool> ChestOpen;

    private void Start()
    {
        _randomDropGenerator = new RandomDropByType();
        _dropFromBox = GetComponent<DropFromBox>();
        _openChestUI = GetComponent<OpenChestUI>();
        CoinController.CoinsChanged += OnCoinsChanged;
    }

    private void OnDestroy()
    {
        CoinController.CoinsChanged -= OnCoinsChanged;
    }

    private void OnCoinsChanged(int newAmount)
    {
        Debug.Log("Coins changed. New balance: " + newAmount);
    }

    public void BuyAndOpen() 
    {
        if (_coins.amount >= ChestCost)
        {
            _coins.RemoveCoins(ChestCost);
            GenerateRandomDrop();
        }
        else
        {
            Debug.Log("Not enough coins to buy the chest");
        }
    }

    public void BuyAndOpen10()
    {
        int totalCost = ChestCost * 10;

        if (_coins.amount >= totalCost)
        {
            _coins.RemoveCoins(totalCost);

            for (int i = 0; i < 10; i++)
            {
                GenerateRandomDrop();
            }
        }
        else
        {
            Debug.Log("Not enough coins to buy 10 chests");
        }
    }
    private void GenerateRandomDrop()
    {
        var randomDrop = _randomDropGenerator.GetRandomDrop();
        var items = _dropFromBox.ChooseRandomItemByType(randomDrop); // Додати інвентарь в який записувати випадені предемети
        _openChestUI.IsItemReceived(items);
        Debug.Log("Received a random drop: " + randomDrop + "\nRecieved Item:" + items.Name);
    }
}

public class RandomDropByType
{
    private static System.Random random = new System.Random();

    public DropType GetRandomDrop()
    {
        int randomNumber = random.Next(1, 101);

        if (randomNumber <= 50)
        {
            return DropType.Common; 
        }
        else if (randomNumber <= 75)
        {
            return DropType.Rare; 
        }
        else if (randomNumber <= 95)
        {
            return DropType.Epic; 
        }
        else
        {
            return DropType.Legendary;
        }
    }
}
