using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    private int damage;
    [SerializeField] Animator animator;

    public void Attack(int damage)
    {
        this.damage = damage;
        animator.SetTrigger("Attack");

    }
    public void AnimationEnded()
    {
        this.gameObject.SetActive(false);
    }
}