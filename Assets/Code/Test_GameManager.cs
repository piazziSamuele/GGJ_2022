using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_GameManager : MonoBehaviour
{
    [SerializeField] List<CurrentPowerUps> currentPowerUps = new List<CurrentPowerUps>();

    private void OnEnable()
    {
        foreach(CurrentPowerUps p in currentPowerUps)
        p.ClearList();
    }
}
