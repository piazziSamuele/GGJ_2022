using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Character Control", menuName = "GGJ/Character Control")]
public class CharacterInputHandler : ScriptableObject
{
    public Vector3 CurrentMovementInput { get; set; }

    public event Action<int> powerUpButtonPressed;
    public event Action<int> powerUpButtonReleased;



    public void HandleAbilityButtonPressed(int abilityNumber)
    {
        powerUpButtonPressed?.Invoke(abilityNumber);
    }
    public void HandleAbilityButtonReleased(int abilityNumber)
    {
        powerUpButtonReleased?.Invoke(abilityNumber);
    }


}
