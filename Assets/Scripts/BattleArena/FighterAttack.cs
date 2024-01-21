using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterAttack : MonoBehaviour
{
    [SerializeField] private int _damage;

    private Fighter _target;

    public void SetTarget(Fighter fighter) 
    {
        _target = fighter;
        Attack();
    }

    public void Attack() 
    {
        _target.GetDMG(_damage);
    }
}
