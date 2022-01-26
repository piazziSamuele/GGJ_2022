using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_GameManager : MonoBehaviour
{
    [SerializeField] CurrentPowerUps currentPowerUps;

    private void OnEnable()
    {
        currentPowerUps.ClearList();
    }
}
