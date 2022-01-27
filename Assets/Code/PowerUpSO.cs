using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Power Up", menuName ="GGJ/PowerUp")]
public class PowerUpSO : ScriptableObject
{
    public event Action powerUpButtonPressed;
    public event Action powerUpButtonReleased;

    public void HandlePowerUpButtonPressed()
    {
        powerUpButtonPressed?.Invoke();
    }
    public void HandlePowerUpButtonReleased()
    {
        powerUpButtonReleased?.Invoke();
    }
}
