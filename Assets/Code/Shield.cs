using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : PowerUp
{
    public GameObject shield;
    internal override void PerformPowerUpAction()
    {
        shield.gameObject.SetActive(true);
    }
    internal override void EndPowerUpAction()
    {
        shield.gameObject.SetActive(false);
    }
}
