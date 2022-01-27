using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PowerUpsHandler : MonoBehaviour
{
    public PlayerInputHandler inputHandler;
    public CurrentPowerUps currentPowerUps;
    public event Action<Vector3> movementAction;
    public event Action buttonAction;
    //need reference to movement script to pass it to abilities like dash that need to know the movement direction
    public Movement movement;

    private void OnEnable()
    {
        inputHandler.powerUpButtonPressed += ActivatePowerUp;
        inputHandler.powerUpButtonReleased += ReleasePowerUp;
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
        if(other.TryGetComponent(out PowerUpPickUp powerUp))
        {
            if (currentPowerUps.AddPowerUp(powerUp.powerUpSO))
            {
                PowerUp equippedPowerUp = powerUp.EquipPowerUP(this.transform);
                equippedPowerUp.parentTransform = this.transform;
                if(equippedPowerUp as MovementPowerUp)
                {
                    ((MovementPowerUp)equippedPowerUp).movement = movement;
                }
            };
        }
    }
}
