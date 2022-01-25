using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMatchManager : MonoBehaviour
{
    public static GameMatchManager Manager;
    public AudioSpectrum spectrum;
    [Range(0,.5f)]
    public float threshlod;
    public int index = 1;
    bool blockSwitch = false;
    public Player Player_1, Player_2;
    public Text switchHighlight, timeText;
    public float TimerBlockValue = .2f;
    public AudioSource soundtrack;
    public GameObject GameConainer, WinObj, LoseObj, menuObj;

    // Start is called before the first frame update
    void Awake()
    {
        if(Manager == null)
        {
            Manager = this;
        }else
        {
            DestroyImmediate(this);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(string.Format("{0} levels ",spectrum.Levels[index]));
        //Debug.Log(string.Format("{0} PeakLevels", spectrum.PeakLevels[2]));
        //Debug.Log(string.Format("{0} levels", spectrum.MeanLevels[index]));

        if(spectrum.MeanLevels[index] > threshlod && !blockSwitch)
        {
            if(Random.value < .1f)
            {
                SwitchCurse();
                blockSwitch = true;
                StartCoroutine(MusicSwitchBlocker());
                switchHighlight.text = "Real Switch";
                switchHighlight.color = Color.green;
            }
            else
            {
                switchHighlight.text = "Fake Switch";
                switchHighlight.color = Color.red;
            }
        }

        if (soundtrack != null && soundtrack.isPlaying)
        {
            int timeLeft = (int)(soundtrack.clip.length - soundtrack.time);
              timeText.text =  string.Format("Time Left: {0}", timeLeft);
            if(timeLeft <= 0)
            {
                GameConainer.SetActive(false);
                WinObj.SetActive(true); // TEMP
                LoseObj.SetActive(false);
                menuObj.SetActive(true);
            }
        }
    }

    public IEnumerator MusicSwitchBlocker()
    {
        //yield return new WaitForSeconds(Random.Range(0.5f, 2.5f))   
        yield return new WaitForSeconds(TimerBlockValue);

        blockSwitch = false;
    }

    private void SwitchCurse()
    {
        Player_1.Switch();
        Player_2.Switch();
    }
}
