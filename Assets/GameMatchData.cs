using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "matchData", menuName = "GGJ/Match hData")]

public class GameMatchData : ScriptableObject
{
    [SerializeField] CharacterDataContainer player, ai;

    //public void SetControlledCharacter

}

[System.Serializable]
public class CharacterDataContainer
{
    public InputHandler controller;
    public ControllableCharacter character;
}
