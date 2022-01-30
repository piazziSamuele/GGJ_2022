using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject  WinObj, LoseObj, MenuObj;
    public Text SwitchHighlight, TimeText;
    public PlayerUIStatsView PlayerOneStats, PlayerTwoStats;
    public InvetoryItemUIView[] Inventory = new InvetoryItemUIView[4];
    public void Start()
    {
        if(GameMatchManager.Manager != null)
        {
            GameMatchManager.Manager.RegisterUIManager(this);
            PlayerOneStats.AssignPlayer(GameMatchManager.Manager.Player_1.GetComponent<Health>());
            PlayerTwoStats.AssignPlayer(GameMatchManager.Manager.Player_2.GetComponent<Health>());
        }
    }

    public void UpdateDebugText(bool isFake)
    {
        if(isFake)
        {
            SwitchHighlight.text = "Fake Switch";
            SwitchHighlight.color = Color.red;
        }
        else
        {
            SwitchHighlight.text = "Real Switch";
            SwitchHighlight.color = Color.green;
        }
    }

    public void UpdateTimeText(int timeValue)
    {
        TimeText.text = string.Format("Time Left: {0}", timeValue);
    }

    public void ShowEndGame(bool won)
    {
        WinObj.SetActive(won);
        LoseObj.SetActive(!won);
        MenuObj.SetActive(true);
    }

    public void SetActiveGameContainer(bool value)
    {
        GameMatchManager.Manager.SetActiveGameContainer(value);
    }

    public void PlayAudioSource()
    {
        GameMatchManager.Manager.PlayAudioTrack();
    }

    public void UpdateInvetory()
    {
        PowerUpSO[] powerups = GameMatchManager.Manager.GetCurrentPlayerPowerUps().currentPowerUps.GetArray();
        for (int i = 0; i < Inventory.Length; i++)
        {
            Inventory[i].EmptySlot();
        }

        for (int i = 0; i < powerups.Length; i++)
        {
            Inventory[i].AssignItemIcon(powerups[i].icon);
        }

    }
}
