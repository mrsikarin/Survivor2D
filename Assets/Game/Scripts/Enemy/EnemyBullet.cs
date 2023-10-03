using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private float Damage;
    private float lifeTime;
    public float counter = 0;
    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerStatus player = other.GetComponent<PlayerStatus>();
        if (player != null)
        {
            player.TakeDamage(Damage);
            Destroy(gameObject);
        }
    }

    public void SetDamage(float damage, float lifeTime)
    {
        Damage = damage;
        this.lifeTime = lifeTime;
    }
}
