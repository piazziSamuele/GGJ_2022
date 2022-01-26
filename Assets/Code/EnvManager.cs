using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvManager : MonoBehaviour
{
    private AudioSpectrum spectrum;
    private Material arenaMat;
    // Start is called before the first frame update
    void Start()
    {
        spectrum = GameMatchManager.Manager.spectrum;
        arenaMat = GetComponent<MeshRenderer>().sharedMaterial;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameMatchManager.Manager.soundtrack != null && GameMatchManager.Manager.soundtrack.isPlaying)
        {
            Color newArenaTint = new Color(Mathf.Clamp01( spectrum.MeanLevels[0] * 15f), Mathf.Clamp01(spectrum.MeanLevels[1] * 15f), Mathf.Clamp01(spectrum.MeanLevels[2] * 15f), Mathf.Clamp01(spectrum.MeanLevels[3] * 15f));
            arenaMat.SetColor("_Tint", newArenaTint);

        }
    }
}
