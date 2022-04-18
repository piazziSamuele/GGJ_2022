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
    [SerializeField] GenericPowerUp[] powerUps = new GenericPowerUp[4];


    public bool TryPickUp(GenericPowerUp powerUp,Transform characterTransform, out GenericPowerUp powerUpInstance)
    {
        powerUpInstance = null;
        if (powerUpsData.Contains(powerUp.PowerUpData)) return false;
        if (powerUpsData.Count >= 4) return false;
        powerUpsData.Add(powerUp.PowerUpData);
        powerUpInstance = Instantiate(powerUp, characterTransform);
        for (int i = 0; i < powerUps.Length; i++)
        {
            if(powerUps[i] == null)
            {
                powerUps[i] = powerUpInstance;
                break;
            }
        }
        onPowerUpPickUp?.Invoke(powerUp.PowerUpData);
        return true;
    }
    public void RemovePowerUp(PowerUpSO powerUp)
    {
        for (int i = 0; i < powerUps.Length; i++)
        {
            if (powerUps[i] != null && powerUps[i].PowerUpData == powerUp)
            {
                powerUps[i] = null;
            }

        }

        powerUpsData.Remove(powerUp);
        powerUpsData.RemoveAll(item => item == null);

    }
    public void ActivatePowerUp(int buttonNumber)
    {
        if (powerUps.Length > buttonNumber && powerUps[buttonNumber] != null)
        {
            powerUps[buttonNumber].PerformPowerUpAction();
        }
    }
    public void ReleasePowerUp(int buttonNumber)
    {
        if (powerUps.Length > buttonNumber && powerUps[buttonNumber] != null)
        {
            powerUps[buttonNumber].EndPowerUpAction();
        }
    }

    public float GetPowerUpLifePercentage(PowerUpSO powerUp)
    {
        if (powerUp == null) return 0f;
        int t = 0;
        for (int i = 0; i < powerUps.Length; i++)
        {
            if(powerUps[i] != null && powerUps[i].PowerUpData == powerUp)
            {
                t = i;
            }
        }
        float v = 0f;
        if (t >= 0 && t <= powerUps.Length)
        {
            if(powerUps[t] != null)
            v = powerUps[t].GetChargePercent();
        }
        return v;
        
    }

    public PowerUpSO[] GetPowerUpDataArray()
    {
        return powerUpsData.ToArray();
    }
    public GenericPowerUp[] GetPowerUps()
    {
        return powerUps;
    }

}
