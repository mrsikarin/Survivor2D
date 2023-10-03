using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootingAttack : Enemy
{
    public GameObject bullet;
    public float BulletSpeed;
    public float lifeTime;
    public override void Attack()
    {
        if(attackTimer >= status.AttackDelay)
        {
            Damage();
        }
    }
    public void Damage()
    {
        if (Vector3.Distance(transform.position, player.position) <= status.AttackRange)
        {
            GameObject bulletObj = Instantiate(bullet,transform.position,Quaternion.identity);
            bulletObj.GetComponent<EnemyBullet>().SetDamage(status.Damage,lifeTime);
            Vector3 targetDirection = player.position - bulletObj.transform.position;
            float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
            bulletObj.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            Rigidbody2D bulletRigidbody = bulletObj.GetComponent<Rigidbody2D>();
            bulletRigidbody.velocity = targetDirection.normalized * BulletSpeed;
            attackTimer = 0f;
        }
    }
}
