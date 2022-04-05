using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIInputButtons : MonoBehaviour
{
    [SerializeField] InputButtonsSprites inputButtonSprites;
    [SerializeField] Image buttonSouth;
    [SerializeField] Image buttonEast;
    [SerializeField] Image buttonNorth;
    [SerializeField] Image buttonWest;

    private Sprite[] updatedSprites = new Sprite[4];
    public PlayerInput playerInput;
    private string currentControlScheme = "a";
    public void OnControlsChanged()
    {
        
        if (playerInput.currentControlScheme != currentControlScheme)
        {
            currentControlScheme = playerInput.currentControlScheme;
            updatedSprites = inputButtonSprites.GetSprites(currentControlScheme);
            if(updatedSprites != null)
            {
                buttonSouth.sprite = updatedSprites[0];
                buttonEast.sprite = updatedSprites[1];
                buttonNorth.sprite = updatedSprites[2];
                buttonWest.sprite = updatedSprites[3];
            }
        }
        
    }
}
