using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FighterUI : MonoBehaviour
{
    [SerializeField] private Slider _sliderHP;
    [SerializeField] private Slider _sliderTrunMeter;


    private void Awake()
    {

    }

    public void UpdateHealth(float health) 
    {
        if (_sliderHP != null)
        {
            _sliderHP.value = health;
        }
        else Debug.Log("we have a problem");
    }
    public void UpdateTurnMeter(float turnMeter)
    {
        if (_sliderTrunMeter != null)
        {
            _sliderTrunMeter.value = turnMeter;
        }
        else Debug.Log("we have a problem");
    }
}
