using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : PowerUp
{
    public GameObject shield;
    Health playerHealth;
    public float meleeDamageReduction = 5f;
    private void Start()
    {
        parentTransform.TryGetComponent(out playerHealth);
    }
    public override void PerformPowerUpAction()
    {
        if( playerHealth != null)
        {
            playerHealth.AddFlatDamageReduction(meleeDamageReduction);
        }
        shield.gameObject.SetActive(true);

    }
    public override void EndPowerUpAction()
    {
        if (playerHealth != null)
        {
            playerHealth.RemoveFlatDamageReduction(meleeDamageReduction);
        }
        shield.gameObject.SetActive(false);
    }
}
