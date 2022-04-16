using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Power Up", menuName = "GGJ/CurrentPowerUp")]

public class CurrentPowerUps : ScriptableObject
{
    public event Action<PowerUpSO> onPowerUpPickUp;
    public void ClearList()
    {
        powerUpsData.Clear();
        powerUpsInstance.Clear();
    }
    [SerializeField] List<PowerUpSO> powerUpsData = new List<PowerUpSO>();
    [SerializeField] List<GenericPowerUp> powerUpsInstance = new List<GenericPowerUp>();


    public bool TryPickUp(GenericPowerUp powerUp,Transform characterTransform, out GenericPowerUp powerUpInstance)
    {
        powerUpInstance = null;
        if (powerUpsData.Contains(powerUp.PowerUpData)) return false;
        if (powerUpsData.Count >= 4) return false;
        powerUpsData.Add(powerUp.PowerUpData);
        powerUpInstance = Instantiate(powerUp, characterTransform);
        powerUpsInstance.Add(powerUpInstance);
        onPowerUpPickUp?.Invoke(powerUp.PowerUpData);
        return true;
    }
    public void ActivatePowerUp(int buttonNumber)
    {
        if (powerUpsInstance.Count > buttonNumber && powerUpsInstance[buttonNumber] != null)
        {
            powerUpsInstance[buttonNumber].PerformPowerUpAction();
        }
    }
    public void ReleasePowerUp(int buttonNumber)
    {
        if (powerUpsInstance.Count > buttonNumber && powerUpsInstance[buttonNumber] != null)
        {
            powerUpsInstance[buttonNumber].EndPowerUpAction();
        }

    }

    public PowerUpSO[] GetPowerUpDataArray()
    {
        return powerUpsData.ToArray();
    }
    public GenericPowerUp[] GetPowerUps()
    {
        return powerUpsInstance.ToArray();
    }

}
