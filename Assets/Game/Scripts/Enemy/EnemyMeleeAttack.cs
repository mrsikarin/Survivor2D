using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : Enemy
{
    public override void Attack()
    {
        //attackTimer = Mathf.Clamp(attackTimer + Time.deltaTime,0,status.AttackDelay);
        if(attackTimer >= status.AttackDelay)
        {
            Damage();
        }

    }
    public void Damage()
    {
        if (Vector3.Distance(transform.position, player.position) <= status.AttackRange)
        {
            player.gameObject.GetComponent<PlayerStatus>().TakeDamage(status.Damage);
            attackTimer = 0f;
        }
    }
    
}
