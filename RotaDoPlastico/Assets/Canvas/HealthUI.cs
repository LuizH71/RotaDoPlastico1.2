using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider;

    public floatVariable CurrentHealth;


    private void Start()
    {
        UpdateLife();
    }
    public void UpdateLife()
    {
        _healthSlider.value = CurrentHealth.Value;
    }

}
