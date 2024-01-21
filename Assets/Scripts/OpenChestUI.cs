using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OpenChestUI : MonoBehaviour
{
    [SerializeField] private OpenChest _openChest;
    [SerializeField] private TextMeshProUGUI[] CostText;
    [SerializeField] private Animator[] _animator;

    [SerializeField] private GameObject Received;
    [SerializeField] private GameObject getItemPrefab; // Prefab for the item card
    [SerializeField] private Transform itemContainer; // Parent transform for created item cards

    public Image itemImage;
    public TextMeshProUGUI itemText;

    private void Start()
    {
        _openChest = GetComponent<OpenChest>();
        CostText[0].text = _openChest.ChestCost.ToString();
        CostText[1].text = (_openChest.ChestCost * 10).ToString();
    }

    public void IsItemReceived(Items _item)
    {
        Instantiate(getItemPrefab, itemContainer);
        
        GetPrefab(getItemPrefab);
        SetItem(_item);
        Received.SetActive(true);
    }

    public void CloseReceived()
    {
        Received.SetActive(false);
        foreach (Transform child in itemContainer)
        {
            Destroy(child.gameObject);
        }
    }

    public void GetPrefab(GameObject _itemPrefab)
    {
        itemImage = _itemPrefab.GetComponentInChildren<Image>(true);
        itemText = _itemPrefab.GetComponentInChildren<TextMeshProUGUI>(true);
    }

    public void SetItem(Items item)
    {
        if (itemImage != null && itemText != null)
        {
            itemImage.sprite = item.UIDisplay;
            itemText.text = item.Name;
        }
    }
}