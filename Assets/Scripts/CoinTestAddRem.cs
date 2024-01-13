using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTestAddRem : MonoBehaviour
{
    [SerializeField] private CoinController _coins;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) 
        {
            _coins.AddCoins(100);
            Debug.Log("add Succesful");
        }
    }

    public void RemoveCoins(int amount) 
    {
        _coins.RemoveCoins(amount);
        Debug.Log("Remove Succesful");
    }
}
