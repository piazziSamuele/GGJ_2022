using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMatchManager : MonoBehaviour
{
    public static GameMatchManager Manager;
    public AudioSpectrum spectrum;
    [Range(0,.5f)]
    public float threshlod;
    public int index = 0;
    public float TimerBlockValue = .13f;
    public InputHandler player,ai;
    public GameMatchData matchData;
    public ControllableCharacter character_1, character_2;

    public GameObject[] PowerUps = new GameObject[0];

    [SerializeField]
    private AudioSource soundtrack;
    [SerializeField]
    private GameObject GameConainer;

    private bool blockSwitch = false;
    private UIManager m_ui;

    void Awake()
    {
        SetUpCharacterControllers();
        if(Manager == null)
        {
            Manager = this;
        }else
        {
            DestroyImmediate(this);
        }
        GameConainer.SetActive(false); //TEMP
    }

    private void SetUpCharacterControllers()
    {
        player.controlledCharacter = character_1;
        ai.controlledCharacter = character_2;
    }

    public void RegisterUIManager(UIManager manager)
    {
        m_ui = manager;
    }

    public void SetActiveGameContainer(bool isActive)
    {
        GameConainer.SetActive(isActive);
    }

    public void PlayAudioTrack()
    {
        soundtrack.Play();
        SpawnAllPowerUps();
    }

    public bool GetAudioSourcePlayingValue()
    {
        if(soundtrack != null && soundtrack.isPlaying)
        {
            return true;
        }else
        {
            return false;
        }
    }

    void FixedUpdate()
    {

        if(spectrum.MeanLevels[index] > threshlod && !blockSwitch)
        {
            if(Random.value < .1f)
            {
                SwitchCurse();
                blockSwitch = true;
                StartCoroutine(MusicSwitchBlocker());
                if(m_ui != null) m_ui.UpdateDebugText(false);
            }
            else
            {
                if (m_ui != null) m_ui.UpdateDebugText(true);
            }
        }

        if (soundtrack != null && soundtrack.isPlaying)
        {
            int timeLeft = (int)(soundtrack.clip.length - soundtrack.time);
            if (m_ui != null) m_ui.UpdateTimeText(timeLeft);
            
            if(timeLeft <= 0)
            {
                EndGame();

            }
        }
    }


    public IEnumerator MusicSwitchBlocker()
    {


        yield return new WaitForSeconds(TimerBlockValue);

        blockSwitch = false;
    }

    private void SpawnPowerUp()
    {
        Vector3 propPosition = Random.insideUnitSphere * 10f;
        propPosition.y = 1;
        GameObject newPowerUp = Instantiate(PowerUps[Random.Range(0, PowerUps.Length-1)], propPosition, Quaternion.identity, GameConainer.transform);
    }

    public CurrentPowerUps GetCurrentPlayerPowerUps()
    {
        return player.controlledCharacter.currentPowerUps;
    }

    private void SpawnAllPowerUps()
    {
        foreach(GameObject prop in PowerUps)
        {
            Vector3 propPosition = Random.insideUnitSphere * 10f;
            propPosition.y = 1;
            GameObject newPowerUp = Instantiate(prop, propPosition, Quaternion.identity, GameConainer.transform);
        }
    }

    private void SwitchCurse()
    {
        character_1.OnSwitch();
        character_2.OnSwitch();
        var v = player.controlledCharacter;
        player.controlledCharacter = ai.controlledCharacter;
        ai.controlledCharacter = v;
        m_ui.UpdateInvetory();

    }

    public UIManager GetUIManager()
    {
        if (m_ui)
        {
            return m_ui;
        }
        else
        {
            return null;
        }
    }

    public void UpdateInvetory()
    {
        if (m_ui != null) m_ui.UpdateInvetory();
    }

    public void EndGame()
    {
        GameConainer.SetActive(false);
        soundtrack.Stop();
        if (m_ui != null) m_ui.ShowEndGame(GetWinner());
    }

    private bool GetWinner()
    {
        if (player.controlledCharacter.health.value > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
