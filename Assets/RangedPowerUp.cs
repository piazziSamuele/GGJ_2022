using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedPowerUp : PowerUp<RangedWeaponPowerUpSO>
{
    [SerializeField] Transform firePoint;
    [SerializeField] Projectile projectilePrefab;
    [SerializeField] GameObject rifle;
    public float fireRate = .1f;
    public float projectileSpeed = 10f;
    public float damagePerBullet = 2f;
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
            projectile.speed = projectileSpeed;
            projectile.damage = damagePerBullet;
            yield return new WaitForSeconds(fireRate);
        }
    }




}
