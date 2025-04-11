using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider;

    public floatVariable CurrentHealth;

    [SerializeField] private UnityEvent Death;
    private void Start()
    {
        UpdateLife();
    }
    public void UpdateLife()
    {
        if(CurrentHealth.Value > 0)
        {
            _healthSlider.value = CurrentHealth.Value;
        }
        else
        {
            _healthSlider.value = 0;
            //Time.timeScale = 0;
            Death.Invoke();
        }
    }

}
