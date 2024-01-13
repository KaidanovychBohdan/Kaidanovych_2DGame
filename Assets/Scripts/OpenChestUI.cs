using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OpenChestUI : MonoBehaviour
{
    [SerializeField] private OpenChest _openChest;
    [SerializeField] private TextMeshProUGUI[] CostText;
    [SerializeField] private Animator[] _animator;

    private void Start()
    {
        _openChest = GetComponent<OpenChest>(); 
        CostText[0].text = _openChest.ChestCost.ToString();
        CostText[1].text = (_openChest.ChestCost * 10).ToString();
    }
}
