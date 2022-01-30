using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 100;
    public float flatDamageReduction = 0f;
    
    public void TakeDamage(float damage)
    {
        if(damage >= health)
        {
            health = 0;
            GameMatchManager.Manager.EndGame();
        }
        else
        {
            health -= CalculateDamage(damage);
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
