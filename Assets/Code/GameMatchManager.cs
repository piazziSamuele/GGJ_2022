using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMatchManager : MonoBehaviour
{
    public static GameMatchManager Manager;
    public AudioSpectrum spectrum;
    public MaterialColorSwitch switcher;
    [Range(0,.5f)]
    public float threshlod;
    public int index = 1;
    bool blockSwitch = false;
    public Player Player_1, Player_2;
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
    void Update()
    {
        Debug.Log(string.Format("{0} levels ",spectrum.Levels[index]));
        //Debug.Log(string.Format("{0} PeakLevels", spectrum.PeakLevels[2]));
        //Debug.Log(string.Format("{0} levels", spectrum.MeanLevels[index]));

        if(spectrum.MeanLevels[index] > threshlod && !blockSwitch)
        {
            if(Random.value < .1f)
            {
                SwitchCurse();
                blockSwitch = true;
                StartCoroutine(MusicSwitchBlocker());
            }
        }

    }

    public IEnumerator MusicSwitchBlocker()
    {
        //yield return new WaitForSeconds(Random.Range(0.5f, 2.5f))   
        yield return new WaitForSeconds(.1f);

        blockSwitch = false;
    }

    private void SwitchCurse()
    {
        Player_1.Switch();
        Player_2.Switch();
    }
}
