using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : PowerUp<MeleeWeaponPowerUpSO>
{
    public int weaponDamage;
    [SerializeField] MeleeWeapon weaponObject;
    public override void PerformPowerUpAction()
    {
        if(!weaponObject.gameObject.activeSelf)
        {
            weaponObject.gameObject.SetActive(true);
            weaponObject.Attack(weaponDamage);

        }
    }
}
