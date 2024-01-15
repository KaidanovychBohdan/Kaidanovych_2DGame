using UnityEngine;
using UnityEngine.UI;

public interface Iitems
{
    int ItemID { get; }
    string ItemName { get; }
    Sprite ItemImage { get; }
    DropType ItemDropType { get; }
}