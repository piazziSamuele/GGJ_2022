using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class ControllableCharacter : MonoBehaviour
{
    [SerializeField] ParticleSystem switchParticleSystem;
    public event Action<ControlDevice> onControlDeviceChange;

    public CurrentPowerUps currentPowerUps;
    
    public Health health;
    public Vector3 CurrentMovementInput { get; set; }

    public event Action<int> powerUpButtonPressed;
    public event Action<int> powerUpButtonReleased;
    public event Action onSwitch;
    
    public void OnControlDeviceChange(ControlDevice device)
    {
        onControlDeviceChange.Invoke(device);
    }

    public void OnSwitch()
    {
        foreach (GenericPowerUp powerUp in currentPowerUps.GetPowerUps())
        {
            if (powerUp != null)
            {
                powerUp.EndPowerUpAction();
            }
        }

        CurrentMovementInput = Vector3.zero;
        onSwitch?.Invoke();
        if (switchParticleSystem != null)
        switchParticleSystem.Play();
    }

    public void OnPowerUpRemoved()
    {

    }

    public void HandleAbilityButtonPressed(int abilityNumber)
    {
        powerUpButtonPressed?.Invoke(abilityNumber);
    }
    public void HandleAbilityButtonReleased(int abilityNumber)
    {
        powerUpButtonReleased?.Invoke(abilityNumber);
    }
}
