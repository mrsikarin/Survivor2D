using UnityEngine;

public class DamageArea : Damage
{
    private float overtimeCounter = 0f;
    public float damagePer = 1f;
    // Update is called once per frame
    void Update()
    {
        overtimeCounter = Mathf.Clamp(overtimeCounter - Time.deltaTime, 0, 1f);
        if (overtimeCounter <= 0)
        {
            overtimeCounter = damagePer;
            int count = enemys.Count;
            for (int i = 0; i < count ; i++)
            {
                if(enemys[i].gameObject.activeSelf)
                    Attack(enemys[i]);
            }

        }
    }
     void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemys.Add(enemy);
        }
    }    
    void OnTriggerExit2D(Collider2D other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemys.Contains(enemy))
            enemys.Remove(enemy);
    }   
}
