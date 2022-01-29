using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : PowerUp<MeleeWeaponPowerUpSO>
{
    [SerializeField] GameObject weaponObject;
    [SerializeField] Animator animator;

    public override void PerformPowerUpAction()
    {
        if (CanAttack())
        {
            weaponObject.gameObject.SetActive(true);
            Attack(powerUpData.damage);

        }
    }
    private bool CanAttack()
    {
        if (weaponObject.activeSelf) return false;
        return true;
    }

    public void Attack(int damage)
    {
        animator.SetTrigger("Attack");
    }
    public void AnimationEnded()
    {
        weaponObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Health health))
        {
            health.TakeDamage(powerUpData.damage);
        }

    }
}