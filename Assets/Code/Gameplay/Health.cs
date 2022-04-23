using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float value = 100;
    public float flatDamageReduction = 0f;
    [SerializeField] Lifebar lifebar;
    
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
