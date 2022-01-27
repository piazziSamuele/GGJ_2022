using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedPowerUp : PowerUp
{
    [SerializeField] Transform firePoint;
    [SerializeField] Projectile projectilePrefab;
    [SerializeField] GameObject rifle;
    public float fireRate = .1f;
    public float projectileSpeed = 10f;
    Coroutine fireRoutine;

    internal override void PerformPowerUpAction()
    {
        rifle.SetActive(true);
        fireRoutine = StartCoroutine(FireRoutine());
    }
    internal override void EndPowerUpAction()
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
            yield return new WaitForSeconds(fireRate);
        }
    }




}
