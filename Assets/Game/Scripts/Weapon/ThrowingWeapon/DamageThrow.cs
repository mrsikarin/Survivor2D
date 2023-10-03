using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageThrow : Damage
{
    private Rigidbody2D theRB; 
    public float rotateSpeed = 1f;
    public float lifetime = 2f;
    public float counterlifeTime;
    private void Start() {
        theRB = GetComponent<Rigidbody2D>();
    }
    private void Update() {
        transform.rotation = Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z + (rotateSpeed * 360f * Time.deltaTime * Mathf.Sign(theRB.velocity.x)));
        counterlifeTime -= Time.deltaTime;
        if (counterlifeTime <= 0)
        {
            counterlifeTime = lifetime;
            gameObject.SetActive(false);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            Attack(enemy);
        }
    }   
}
