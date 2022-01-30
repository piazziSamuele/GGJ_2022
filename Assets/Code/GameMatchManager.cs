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

    private void SwitchCurse()
    {
        var v = player_1.controlledCharacter;
        player_1.controlledCharacter = player_2.controlledCharacter;
        player_2.controlledCharacter = v;
    }
}
