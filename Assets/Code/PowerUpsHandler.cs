using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PowerUpsHandler : MonoBehaviour
{
    public PlayerInputHandler inputHandler;
    public CurrentPowerUps currentPowerUps;
    public Player player;
    public event Action<Vector3> movementAction;
    public event Action buttonAction;

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
            GenericPowerUp p = powerUp.powerUp;
            if (currentPowerUps.AddPowerUp(p.PowerUpData))
            {
                GenericPowerUp equipablePowerUp = Instantiate(p, transform);
                equipablePowerUp.player = this.player;
            };
        }
    }
}
