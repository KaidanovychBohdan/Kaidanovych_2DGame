using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterTurnMeter : MonoBehaviour
{
    [SerializeField] private float _stepValue;
    [SerializeField] private float _maxValue;

    private float _value;

    public bool CanOffensive => _value >= _maxValue;

    public void Increase() 
    {
        _value = Mathf.Clamp(_value + _stepValue, 0, _maxValue);
    }

    public void Reset()
    {
        _value = 0;
    }
}
