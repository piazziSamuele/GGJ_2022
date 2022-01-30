using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Power Up", menuName = "GGJ/CurrentPowerUp")]

public class CurrentPowerUps : ScriptableObject
{
    public void ClearList()
    {
        powerUps.Clear();
    }
    [SerializeField] List<PowerUpSO> powerUps = new List<PowerUpSO>();

    public bool AddPowerUp(PowerUpSO powerUp)
    {
        if (powerUps.Contains(powerUp)) return false;
        if (powerUps.Count >= 4) return false;
        powerUps.Add(powerUp);
        return true;
    }
    public PowerUpSO GetPowerUP(int powerUpNumber)
    {
        return powerUps[powerUpNumber];
    }
    public void ActivatePowerUp(int buttonNumber)
    {
        if (powerUps.Count > buttonNumber && powerUps[buttonNumber] != null)
        {
            powerUps[buttonNumber].HandlePowerUpButtonPressed();
        }
    }
    public void ReleasePowerUp(int buttonNumber)
    {
        if (powerUps.Count > buttonNumber && powerUps[buttonNumber] != null)
        {
            powerUps[buttonNumber].HandlePowerUpButtonReleased();
        }

    }

    public PowerUpSO[] GetArray()
    {
        return powerUps.ToArray();
    }
}
