using UnityEngine;

public class UIInputButtons : MonoBehaviour
{
    [SerializeField] InputButtonsSprites inputButtonSprites;
    [SerializeField] WorldUIButton buttonSouth;
    [SerializeField] WorldUIButton buttonEast;
    [SerializeField] WorldUIButton buttonNorth;
    [SerializeField] WorldUIButton buttonWest;
    [SerializeField] ControllableCharacter character;

    private Sprite[] updatedSprites = new Sprite[4];
    private void OnEnable()
    {
        character.onControlDeviceChange += AssignButtonSprite;
    }

    public void AssignButtonSprite(ControlDevice device)
    {
        print("assigning buttons");
        updatedSprites = inputButtonSprites.GetSprites(device);
        if (updatedSprites != null)
        {
            buttonSouth.SetButtonSprite(updatedSprites[0]);
            buttonEast.SetButtonSprite(updatedSprites[1]);
            buttonNorth.SetButtonSprite(updatedSprites[2]);
            buttonWest.SetButtonSprite(updatedSprites[3]);
        }
    }
}
