using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIInputHandler : InputHandler
{
    private void Update()
    {
        this.PowerUpButtonPressed(0);
        controlledCharacter.CurrentMovementInput = -Vector3.forward * 0.2f;
    }
}
