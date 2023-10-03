using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDagger : Damage
{
    public float lifeTime = 2f;
    private float counterlifeTime = 0;
    void Update()
    {
        counterlifeTime  = Mathf.Clamp(counterlifeTime  - Time.deltaTime, 0, lifeTime);
        if (counterlifeTime  <= 0)
        {
            counterlifeTime  = lifeTime;
            gameObject.SetActive(false);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            Attack(enemy);
            gameObject.SetActive(false);
        }
    }   
}
