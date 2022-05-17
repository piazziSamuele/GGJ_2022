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
    }
    [SerializeField] List<PowerUpSO> powerUpsData = new List<PowerUpSO>();
    [SerializeField] GenericPowerUp[] instantatedPowerUps = new GenericPowerUp[4];


    public bool TryPickUp(GenericPowerUp powerUp,Transform characterTransform, out GenericPowerUp powerUpInstance)
    {
        powerUpInstance = null;
        if (powerUpsData.Contains(powerUp.PowerUpData)) return false;
        if (powerUpsData.Count >= 4) return false;
        powerUpsData.Add(powerUp.PowerUpData);
        powerUpInstance = Instantiate(powerUp, characterTransform);
        for (int i = 0; i < instantatedPowerUps.Length; i++)
        {
            if(instantatedPowerUps[i] == null)
            {
                instantatedPowerUps[i] = powerUpInstance;
                break;
            }
        }
        onPowerUpPickUp?.Invoke(powerUp.PowerUpData);
        return true;
    }
    public void RemovePowerUp(PowerUpSO powerUp)
    {
        for (int i = 0; i < instantatedPowerUps.Length; i++)
        {
            if (instantatedPowerUps[i] != null && instantatedPowerUps[i].PowerUpData == powerUp)
            {
                instantatedPowerUps[i] = null;
            }

        }

        powerUpsData.Remove(powerUp);
        powerUpsData.RemoveAll(item => item == null);

    }
    public void ActivatePowerUp(int buttonNumber)
    {
        if (instantatedPowerUps.Length > buttonNumber && instantatedPowerUps[buttonNumber] != null)
        {
            instantatedPowerUps[buttonNumber].PerformPowerUpAction();
        }
    }
    public void ReleasePowerUp(int buttonNumber)
    {
        if (instantatedPowerUps.Length > buttonNumber && instantatedPowerUps[buttonNumber] != null)
        {
            instantatedPowerUps[buttonNumber].EndPowerUpAction();
        }
    }

    public float GetPowerUpLifePercentage(PowerUpSO powerUp)
    {
        float v = 0;
        for (int i = 0; i < instantatedPowerUps.Length; i++)
        {
            if(instantatedPowerUps[i] != null && instantatedPowerUps[i].PowerUpData == powerUp)
            {
                v = instantatedPowerUps[i].GetChargePercent();
            }
        }
        return v;
    }

    public PowerUpSO[] GetPowerUpDataArray()
    {
        return powerUpsData.ToArray();
    }
    public GenericPowerUp[] GetPowerUps()
    {
        return instantatedPowerUps;
    }

}
