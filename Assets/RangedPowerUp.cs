using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedPowerUp : PowerUp<RangedWeaponPowerUpSO>
{
    [SerializeField] Transform firePoint;
    [SerializeField] Projectile projectilePrefab;
    [SerializeField] GameObject rifle;
    Coroutine fireRoutine;
    bool coroutineIsRunning = false;

    public override void PerformPowerUpAction()
    {
        base.PerformPowerUpAction();
        if (!coroutineIsRunning)
        {
            rifle.SetActive(true);
            fireRoutine = StartCoroutine(FireRoutine());
        }
    }
    public override void EndPowerUpAction()
    {
        rifle.SetActive(false);
        if (fireRoutine != null)
        {
            StopCoroutine(fireRoutine);
        }
        coroutineIsRunning = false;
    }

    IEnumerator FireRoutine()
    {
        coroutineIsRunning = true;
        while (true)
        {
            Projectile projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.transform.rotation);
            projectile.speed = powerUpData.projectileSpeed;
            projectile.damage = powerUpData.damagePerBullet;
            currentCharge -= (percentChargePerUse * totalPowerUpDuration) / 100;
            yield return new WaitForSeconds(powerUpData.fireRate);
        }
    }
}
