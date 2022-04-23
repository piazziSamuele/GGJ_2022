using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float value = 100;
    public float startHealth = 100;
    public float flatDamageReduction = 0f;
    public float healthPercet;

    private void Awake()
    {
        value = startHealth;
    }
    public void TakeDamage(float damage)
    {
        if(damage >= value)
        {
            value = 0;
            //GameMatchManager.Manager.EndGame();
        }
        else
        {
            value -= CalculateDamage(damage);
        }
    }
    private void Update()
    {
        healthPercet = GetHealthPercent();
    }
    public float GetHealthPercent()
    {
        return value * 100 / startHealth;
    }
    private float CalculateDamage(float damage)
    {
        return damage - flatDamageReduction;
    }

    public void AddFlatDamageReduction(float value)
    {
        flatDamageReduction += value;
    }
    public void RemoveFlatDamageReduction(float value)
    {
        flatDamageReduction = Mathf.Max(0f, flatDamageReduction - value);
    }
 
}
