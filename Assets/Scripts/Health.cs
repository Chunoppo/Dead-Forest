using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHP;
    public float currentHP;

    private void Start()
    {
        currentHP = maxHP;
    }
    public virtual void TakeDamage(float damage)
    {
        currentHP -= damage;
        currentHP = Math.Max(0, currentHP);
    }

}
