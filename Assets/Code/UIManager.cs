using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject  WinObj, LoseObj, menuObj;
    public Text switchHighlight, timeText;

    public void Start()
    {
        if(GameMatchManager.Manager != null)
        {
            GameMatchManager.Manager.RegisterUIManager(this);
        }
    }

    public void UpdateDebugText(bool isFake)
    {
        if(isFake)
        {
            switchHighlight.text = "Fake Switch";
            switchHighlight.color = Color.red;
        }
        else
        {
            switchHighlight.text = "Real Switch";
            switchHighlight.color = Color.green;
        }
    }

    public void UpdateTimeText(int timeValue)
    {
        timeText.text = string.Format("Time Left: {0}", timeValue);
    }

    public void ShowEndGame(bool won)
    {
        WinObj.SetActive(won);
        LoseObj.SetActive(!won);
        menuObj.SetActive(true);
    }

    public void TurnOffGameContainer(bool value)
    {
        GameMatchManager.Manager.SetActiveGameContainer(value);
    }

    public void PlayAudioSource()
    {
        GameMatchManager.Manager.PlayAudioTrack();
    }

}
