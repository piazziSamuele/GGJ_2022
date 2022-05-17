using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerUp : PowerUp<ShieldPowerUpSO>
{
    Health playerHealth;
    public GameObject shield;
    private void Start()
    {
        TryGetComponent(out playerHealth);
    }
    public override void PerformPowerUpAction()
    {
        base.PerformPowerUpAction();
        if ( playerHealth != null)
        {
            playerHealth.AddFlatDamageReduction(powerUpData.meleeDamageReductionValue);
        }
        shield.SetActive(true);

    }
    public override void Update()
    {
        base.Update();
        if (shield.activeSelf)
        {
            currentCharge -= this.percentChargePerUse * Time.deltaTime;
        }

    }
    public override void EndPowerUpAction()
    {
        if (playerHealth != null)
        {
            playerHealth.RemoveFlatDamageReduction(powerUpData.meleeDamageReductionValue);
        }
        shield.SetActive(false);
    }
}
