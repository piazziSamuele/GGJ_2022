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
    public Player Player_1, Player_2;
    public float TimerBlockValue = .13f;

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
        if(Manager == null)
        {
            Manager = this;
        }else
        {
            DestroyImmediate(this);
        }
        GameConainer.SetActive(false); //TEMP
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
                GameConainer.SetActive(false);
                if (m_ui != null) m_ui.ShowEndGame(true); //TEMP
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
}
