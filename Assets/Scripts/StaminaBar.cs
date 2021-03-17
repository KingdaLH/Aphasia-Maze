using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider Slider;
    public Gradient Gradient;
    public Image fill;

    public void SetMaxStamina(int maxStamina)
    {
        Slider.maxValue = maxStamina;
        Slider.value = maxStamina;

        Gradient.Evaluate(maxStamina);
    }
    
    public void SetStamina(int Stamina)
    {
        Slider.value = Stamina;

        fill.color = Gradient.Evaluate(Stamina);
    }
}
