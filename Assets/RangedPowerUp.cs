using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedPowerUp : PowerUp<RangedWeaponPowerUpSO>
{
    [SerializeField] Transform firePoint;
    [SerializeField] Projectile projectilePrefab;
    [SerializeField] GameObject rifle;
    Coroutine fireRoutine;

    public override void PerformPowerUpAction()
    {
        rifle.SetActive(true);
        fireRoutine = StartCoroutine(FireRoutine());
    }
    public override void EndPowerUpAction()
    {
        rifle.SetActive(false);
        StopCoroutine(fireRoutine);
    }

    IEnumerator FireRoutine()
    {
        while (true)
        {
            Projectile projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.transform.rotation);
            projectile.speed = powerUpData.projectileSpeed;
            projectile.damage = powerUpData.damagePerBullet;
            yield return new WaitForSeconds(powerUpData.fireRate);
        }
    }




}
