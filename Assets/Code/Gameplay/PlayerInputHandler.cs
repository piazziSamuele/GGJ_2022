using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : InputHandler
{
    PlayerInputActions playerInputActions;
    
    Vector3 currentMovementInput = new Vector3();
    public void OnControlsChanged()
    {
        print("OnControlsChanged");

    }


    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        //Power Ups
        
        playerInputActions.CharacterControls.Button1.started += ctx => PowerUpButtonPressed(0);
        playerInputActions.CharacterControls.Button2.started += ctx => PowerUpButtonPressed(1);
        playerInputActions.CharacterControls.Button3.started += ctx => PowerUpButtonPressed(2);
        playerInputActions.CharacterControls.Button4.started += ctx => PowerUpButtonPressed(3);

        playerInputActions.CharacterControls.Button1.canceled += ctx => PowerUpButtonReleased(0);
        playerInputActions.CharacterControls.Button2.canceled += ctx => PowerUpButtonReleased(1);
        playerInputActions.CharacterControls.Button3.canceled += ctx => PowerUpButtonReleased(2);
        playerInputActions.CharacterControls.Button4.canceled += ctx => PowerUpButtonReleased(3);


        //Movement
        playerInputActions.CharacterControls.Movement.performed += ctx => RegisterMovementInput(ctx.ReadValue<Vector2>());
        //adding this just to be sure it cancel movement when leaving input
        playerInputActions.CharacterControls.Movement.canceled += ctx => RegisterMovementInput(ctx.ReadValue<Vector2>());
    }
    


    private void RegisterMovementInput(Vector2 input)
    {
        currentMovementInput.x = input.x;
        currentMovementInput.z = input.y;
        if(controlledCharacter != null)
        controlledCharacter.CurrentMovementInput = CameraRelatedMovementInput(input);
    }

    public Vector3 CameraRelatedMovementInput(Vector3 input)
    {
        Vector3 v;
        Vector3 cameraPosition = Camera.main.transform.position;
        cameraPosition.y = 0;
        v = Camera.main.transform.TransformDirection(input);
        v.y = 0;
        return v.normalized;

    }

    private void OnEnable()
    {
        playerInputActions.Enable();
    }
    private void OnDisable()
    {
        playerInputActions.Disable();
    }
}


public class InputHandler : MonoBehaviour
{
    internal ControllableCharacter controlledCharacter;
    public virtual void SetControlledCharacter(ControllableCharacter character)
    {
        controlledCharacter = character;
    }

    internal void PowerUpButtonPressed(int buttonPressed)
    {
        if(controlledCharacter != null)
        controlledCharacter.HandleAbilityButtonPressed(buttonPressed);
    }
    internal void PowerUpButtonReleased(int buttonPressed)
    {
        if(controlledCharacter != null)
        controlledCharacter.HandleAbilityButtonReleased(buttonPressed);
    }

}
