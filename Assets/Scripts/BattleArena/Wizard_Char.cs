using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard_Char : MonoBehaviour, ICharacters
{
    // Параметри
    private int _characterID;
    private string _name;
    private bool _isDead;

    public int CharactersID 
    { 
        get => _characterID; 
        set => _characterID = value; 
    }
    public string Name 
    { 
        get => _name; 
        set => _name = value; 
    }
    public CharType CharTypes => CharType.Wizard;
    public bool IsDead
    {
        get => _isDead;
        set => _isDead = value;
    }

    // Характеристики
    private float _health;
    private float _dmgATK;
    private float _speed;
    private int _critChance;
    private int _energyRecovery;
    private float _energyForUltimates;
    private float _needEnergyToUseUltimates;

    public float Health 
    { 
        get => _health; 
        set => _health = value; 
    }
    public float DMGATK
    {
        get => _dmgATK;
        set => _dmgATK = value;
    }
    public float Speed
    {
        get => _speed;
        set => _speed = value;
    }
    public int CritChance
    {
        get => _critChance;
        set => _critChance = value;
    }
    public int EnergyRecovery 
    {
        get => _energyRecovery;
        set => _energyRecovery = value;
    }
    public float EnergyForUltimates 
    {
        get => _energyForUltimates;
        set => _energyForUltimates = value;
    }
    public float NeedEnergyToUseUltimates 
    {
        get => _needEnergyToUseUltimates;
        set => _needEnergyToUseUltimates = value;
    }

    // Методи
    public void GetDMG(int Damage)
    {
        //if (_isDead)
        //{

        //}
        //else 
        //{
        //    if (_health >= 0)
        //    {
        //        Dead();
        //    }

        //}

    }

    //public void ChooseATK()
    //{
        
    //}

    public void MoveToEnemy()
    {

    }

    public void MoveFromEnemyBack()
    {
        
    }

    public void ATK1()
    {

    }

    public void ATK2()
    {

    }

    public void Ultimate()
    {
        //if(_needEnergyToUseUltimates == _energyForUltimates) 
        //{
            
        //}
        //else 
        //{
        //    Debug.Log("Not enough energy");
        //}
    }

    public void Dead()
    {
        IsDead = true;
    }
}
