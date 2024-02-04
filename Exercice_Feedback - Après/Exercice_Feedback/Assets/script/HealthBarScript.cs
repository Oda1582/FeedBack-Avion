using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public Slider sliderHealth;
    public Slider sliderShield;
    public Slider sliderEnergy;
    public Gradient HealthGradient;
    public Image HealthFill;

    public void SetMaxHealth(int health)
    {
        sliderHealth.maxValue = health;
        sliderHealth.value = health;

        HealthFill.color = HealthGradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        sliderHealth.value = health;

        HealthFill.color = HealthGradient.Evaluate(sliderHealth.normalizedValue);
    }

    public void SetMaxShield(int shield)
    {
        sliderShield.maxValue = shield;
        sliderShield.value = shield;
    }

    public void SetShield(int shield)
    {
        sliderShield.value = shield;
    }
    
    public void SetMaxEnergy(float energy)
    {
        sliderEnergy.maxValue = energy;
        sliderEnergy.value = energy;
    }

    public void SetEnergy(float energy)
    {
        sliderEnergy.value = energy;
    }
}
