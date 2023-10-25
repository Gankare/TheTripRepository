using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;

    public void SetSlider(float health)
    {
        healthSlider.value = health;
    }

    public void SetSliderMax(float health)
    {
        healthSlider.maxValue = health;
        SetSlider(health);
    }

    public bool Death(float health)
    {
        if (healthSlider.value == 0)
        {
            return true;
        }

        return false;
    }

}
