using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public floatVariable CurrentHealth;
    public floatVariable MaxHealth;

    private void OnDisable()
    {
        CurrentHealth.Value = MaxHealth.Value;
    }
    public void TakeDamage(float damage)
    {
        CurrentHealth.Value -= damage;
    }
}
