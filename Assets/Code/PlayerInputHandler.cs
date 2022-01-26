using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    PlayerInput playerInput;
    Vector3 currentMovementInput = new Vector3();
    public Vector3 CurrentMovementInput { get { return currentMovementInput; } }
    public event Action<int> powerUpButtonPressed;

    private void Awake()
    {
        playerInput = new PlayerInput();

        //Power Ups
        playerInput.CharacterControls.Button1.performed += ctx => PowerUpButtonPressed(0);
        playerInput.CharacterControls.Button2.performed += ctx => PowerUpButtonPressed(1);
        playerInput.CharacterControls.Button3.performed += ctx => PowerUpButtonPressed(2);
        playerInput.CharacterControls.Button4.performed += ctx => PowerUpButtonPressed(3);

        //Movement
        playerInput.CharacterControls.Movement.performed += ctx => RegisterMovementInput(ctx.ReadValue<Vector2>());
        //adding this just to be sure it cancel movement when leaving input
        playerInput.CharacterControls.Movement.canceled += ctx => RegisterMovementInput(ctx.ReadValue<Vector2>());
    }
    
    private void PowerUpButtonPressed(int buttonPressed)
    {
        powerUpButtonPressed?.Invoke(buttonPressed);
    }
    private void RegisterMovementInput(Vector2 input)
    {
        currentMovementInput.x = input.x;
        currentMovementInput.z = input.y;
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }
    private void OnDisable()
    {
        playerInput.Disable();
    }
}
