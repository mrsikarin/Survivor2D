using UnityEngine;

public class DamageFireball : Damage
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            Attack(enemy);
        }
    }    
}
