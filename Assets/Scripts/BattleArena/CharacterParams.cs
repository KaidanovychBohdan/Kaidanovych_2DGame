using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New params", menuName = "Characters/Characteristics")]
public class PlayerParams : ScriptableObject
{
    public CharType CharTypes;
    public float Health;
    public float Speed;
    public float DMGATK;
    public int CritChance;
    public int EnergyRecovery;
    public float EnergyForUltimates;
    public float NeedEnergyToUseUltimates;
}
