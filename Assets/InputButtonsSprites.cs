using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Input Button Sprites", menuName = "GGJ/Input Button Sprites")]
public class InputButtonsSprites : ScriptableObject
{
    public List<Sprites> controlSchemes = new List<Sprites>(); 
    public Sprite[] GetSprites(ControlDevice device)
    {
        Sprite[] sprites = null;
        foreach (Sprites sprite in controlSchemes)
        {
            if(sprite.device == device)
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
    public ControlDevice device;
    public Sprite[] sprites = new Sprite[4];
}

public enum ControlDevice
{
    MouseAndKeyboard,
    XboxController,
    PlaystationController

}
