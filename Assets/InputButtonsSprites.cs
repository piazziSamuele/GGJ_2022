using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Input Button Sprites", menuName = "GGJ/Input Button Sprites")]
public class InputButtonsSprites : ScriptableObject
{
    public List<Sprites> controlSchemes = new List<Sprites>(); 
    public Sprite[] GetSprites(string controlDevice)
    {
        Sprite[] sprites = null;
        foreach (Sprites sprite in controlSchemes)
        {
            if(sprite.device.ToString() == controlDevice)
            {
                sprites = sprite.sprites;
            }
        }
        return sprites;
    }
}

[System.Serializable]
public class Sprites
{
    public ControlDevices device;
    public Sprite[] sprites = new Sprite[4];
}

public enum ControlDevices
{
    MouseAndKeyboard,
    XboxController,
    PlaystationController

}
