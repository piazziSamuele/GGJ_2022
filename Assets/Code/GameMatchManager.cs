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
    public InputHandler player_1,player_2;
    public CharacterInputHandler character_1, character_2;

    public GameObject[] PowerUps = new GameObject[0];

    [SerializeField]
    private AudioSource soundtrack;
    [SerializeField]
    private GameObject GameConainer;

    private bool blockSwitch = false;
    private UIManager m_ui;
    private PowerUpsHandler m_currentPlayerPowerUps;
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
        player_1.controlledCharacter = character_1;
        player_2.controlledCharacter = character_2;
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
        Player_1.Switch();
        Player_2.Switch();
        ParticleSystem ps1 = Player_1.GetComponentInChildren<ParticleSystem>();
        ParticleSystem ps2 = Player_2.GetComponentInChildren<ParticleSystem>();
        if (ps1 != null) ps1.Play();
        if (ps2 != null) ps2.Play();
        SpawnPowerUp();
        m_currentPlayerPowerUps = !Player_1.IsAI ? Player_1.GetComponent<PowerUpsHandler>() : Player_2.GetComponent<PowerUpsHandler>();
        if (m_ui != null) m_ui.UpdateInvetory();
    }

    public PowerUpsHandler GetCurrentPlayerPowerUps()
    {
        if(m_currentPlayerPowerUps == null)
        {
            m_currentPlayerPowerUps = !Player_1.IsAI ? Player_1.GetComponent<PowerUpsHandler>() : Player_2.GetComponent<PowerUpsHandler>();
        }
        return m_currentPlayerPowerUps;
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
        if(Player_1.GetComponent<Health>().health > 0)
        {
            if(Player_1.m_movememnt.enabled)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            if (Player_2.m_movememnt.enabled)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        var v = player_1.controlledCharacter;
        player_1.controlledCharacter = player_2.controlledCharacter;
        player_2.controlledCharacter = v;
    }
}
