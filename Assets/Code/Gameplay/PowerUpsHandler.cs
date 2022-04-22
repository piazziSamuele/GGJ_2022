using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PowerUpsHandler : MonoBehaviour
{
    public ControllableCharacter character;
    public UIManager uiManager;
    
    private void OnEnable()
    {
        character.powerUpButtonPressed += ActivatePowerUp;
        character.powerUpButtonReleased += ReleasePowerUp;
    }
    private void OnDisable()
    {
        character.powerUpButtonPressed -= ActivatePowerUp;
        character.powerUpButtonReleased -= ReleasePowerUp;
        character.currentPowerUps.ClearList();
    }

    private void ActivatePowerUp(int powerUpNumber)
    {
        character.currentPowerUps.ActivatePowerUp(powerUpNumber);
    }

    private void ReleasePowerUp(int powerUpNumber)
    {
        character.currentPowerUps.ReleasePowerUp(powerUpNumber);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PowerUpPickUp pickUp))
        {
            GenericPowerUp p = pickUp.powerUpPrefab;
            if (character.currentPowerUps.TryPickUp(p, transform, out GenericPowerUp equipablePowerUp))
            {
                //uiManager.UpdateInvetory();
                equipablePowerUp.assignedCharacter = this.character;
                equipablePowerUp.SubscribeToEvents();
                equipablePowerUp.onPowerUpLifetimeEnd += OnPowerUPLifetimeEnd;
            };
        }
    }
    private void OnPowerUPLifetimeEnd(GenericPowerUp powerUp)
    {
        powerUp.EndPowerUpAction();
        character.currentPowerUps.RemovePowerUp(powerUp.PowerUpData);
        powerUp.onPowerUpLifetimeEnd -= OnPowerUPLifetimeEnd;
    }
}
