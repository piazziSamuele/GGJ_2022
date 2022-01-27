using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : PowerUp
{
    [SerializeField] MeleeWeapon weaponObject;
    internal override void PerformPowerUpAction()
    {
        if(!weaponObject.gameObject.activeSelf)
        {
            weaponObject.gameObject.SetActive(true);

        }
    }
}
