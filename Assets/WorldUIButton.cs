using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldUIButton : MonoBehaviour
{
    [SerializeField] Image buttonSprite;
    [SerializeField] Image powerUpSprite;
    public PowerUpUI powerUpUI;
    private void Update()
    {
    }

    public void SetPowerUPImage(Sprite sprite)
    {
        powerUpSprite.sprite = sprite;
    }
    public void SetButtonSprite(Sprite sprite)
    {
        buttonSprite.sprite = sprite;
    }
}
