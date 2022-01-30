using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Power Up", menuName = "GGJ/Ranged Weapon Power Up")]

public class RangedWeaponPowerUpSO : WeaponPowerUpSO
{
    public float projectileSpeed = 30f;
    public float fireRate = .1f;
    public float damagePerBullet = 2f;

}
