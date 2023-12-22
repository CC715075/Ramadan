using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static IDamageable;

public class LivingEntity : MonoBehaviour, IDamgeable
{

    public float maxHp;
    protected float hp;
    protected bool dead;

    protected virtual void Start()
    {
        hp = maxHp;
    }
    public void TakeHit(float damage, RaycastHit hit)
    {
        hp -= damage;

        if (hp <= 0 & !dead)
        {
            Die();
        }
    }

    protected void Die()
    {
        dead = true;
        GameObject.Destroy(gameObject);
    }
}
