using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PowerUpsHandler : MonoBehaviour
{
    public CurrentPowerUps currentPowerUps;
    public CharacterInputHandler characterControl;
    private void OnEnable()
    {
        characterControl.powerUpButtonPressed += ActivatePowerUp;
        characterControl.powerUpButtonReleased += ReleasePowerUp;
    }
    private void OnDisable()
    {
        characterControl.powerUpButtonPressed -= ActivatePowerUp;
        characterControl.powerUpButtonReleased -= ReleasePowerUp;
    }

    private void ActivatePowerUp(int powerUpNumber)
    {
        currentPowerUps.ActivatePowerUp(powerUpNumber);
    }

    private void ReleasePowerUp(int powerUpNumber)
    {
        currentPowerUps.ReleasePowerUp(powerUpNumber);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PowerUpPickUp pickUp))
        {
            GenericPowerUp p = pickUp.powerUpPrefab;
            if (currentPowerUps.TryPickUp(p, transform, out GenericPowerUp equipablePowerUp))
            {
                equipablePowerUp.assignedCharacter = this.transform;
            };
        }
    }
}
