using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarInterface : MonoBehaviour
{
    public HealthSystem HealthSys;
    public Image fillImage;
    private Slider HPbar;

    void Start()
    {
        HPbar = GetComponent<Slider>();
    }
    void Update()
    {
        if(HPbar.value <= HPbar.minValue)
        {
            fillImage.enabled = false;
        }
        if(HPbar.value > HPbar.minValue && !fillImage.enabled)
        {
            fillImage.enabled = true;
        }
        float fillValue = HealthSys.currentHealth / HealthSys.maxHealth;
        HPbar.value = fillValue;

    }
}
