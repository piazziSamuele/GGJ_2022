using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIInputButtons : MonoBehaviour
{
    [SerializeField] InputButtonsSprites inputButtonSprites;
    [SerializeField] WorldUIButton buttonSouth;
    [SerializeField] WorldUIButton buttonEast;
    [SerializeField] WorldUIButton buttonNorth;
    [SerializeField] WorldUIButton buttonWest;

    private Sprite[] updatedSprites = new Sprite[4];
    private string currentControlScheme = "a";
    private void OnEnable()
    {
        
    }
    private void OnDisable()
    {
        
    }

    public void AssignButtonSprite(ControlDevice device)
    {
        updatedSprites = inputButtonSprites.GetSprites(currentControlScheme);
        if (updatedSprites != null)
        {
            buttonSouth.SetButtonSprite(updatedSprites[0]);
            buttonEast.SetButtonSprite(updatedSprites[1]);
            buttonNorth.SetButtonSprite(updatedSprites[2]);
            buttonWest.SetButtonSprite(updatedSprites[3]);
        }
    }
}
