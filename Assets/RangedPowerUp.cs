using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedPowerUp : PowerUp<RangedWeaponPowerUpSO>
{
    [SerializeField] Transform[] firePoints;
    [SerializeField] Projectile projectilePrefab;
    Coroutine fireRoutine;
    bool coroutineIsRunning = false;

    public override void PerformPowerUpAction()
    {
        base.PerformPowerUpAction();
        if (!coroutineIsRunning)
        {
            fireRoutine = StartCoroutine(FireRoutine());
        }
    }
    public override void EndPowerUpAction()
    {
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
            foreach (Transform firePoint in firePoints)
            {
                Projectile projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.transform.rotation);
                projectile.speed = powerUpData.projectileSpeed;
                projectile.damage = powerUpData.damagePerBullet;
            }
            currentCharge -= (percentChargePerUse * totalPowerUpDuration) / 100;
            yield return new WaitForSeconds(powerUpData.fireRate);
        }
    }
}
