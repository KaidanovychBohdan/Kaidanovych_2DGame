using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : ScriptableObject
{
    public int Id;
    public string Name;
    public Sprite UIDisplay;
    public GameObject prefab;
    public DropType dropType;
    [TextArea(15, 20)]
    public string description;
}

[CreateAssetMenu(fileName = "New Item", menuName = "Items/ItemCommon")]
public class CommonItem : Items
{
    private void Awake()
    {
        dropType = DropType.Common;
    }
}

[CreateAssetMenu(fileName = "New Item", menuName = "Items/ItemRare")]
public class RareItem : Items
{
    private void Awake()
    {
        dropType = DropType.Rare;
    }
}

[CreateAssetMenu(fileName = "New Item", menuName = "Items/ItemEpic")]
public class EpicItem : Items
{
    private void Awake()
    {
        dropType = DropType.Epic;
    }
}

[CreateAssetMenu(fileName = "New Item", menuName = "Items/ItemLegendary")]
public class LegendaryItem : Items
{
    private void Awake()
    {
        dropType = DropType.Legendary;
    }
}