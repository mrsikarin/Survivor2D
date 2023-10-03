using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int damage;
    public bool IsKnockback;
    public List<Enemy> enemys = new List<Enemy>();



    protected void Attack(Enemy enemy)
    {
        enemy.TakeDamage(damage, IsKnockback);
        DamageFloatingControl.instace.SetDamageFloating(damage, enemy.gameObject.transform.position);
    }
}
