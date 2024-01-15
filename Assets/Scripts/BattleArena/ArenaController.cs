using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaController : MonoBehaviour
{

    [SerializeField] private GameObject[] _arenaScreens;
    [SerializeField] private Transform[] _PlayerPosition;
    [SerializeField] private Transform[] _enemiesPosition;

    public ItemDataBaseObj _items; // поки так потім замінити щоб передавати героїв по іншому

    public void BattleStart(int arenaID)
    {
        _arenaScreens[arenaID].SetActive(true);

    }
    private void BattleEnd(int arenaID)
    {
        _arenaScreens[arenaID].SetActive(false);

    }
}
