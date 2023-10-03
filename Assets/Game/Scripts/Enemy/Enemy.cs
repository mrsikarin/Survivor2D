using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float currentHealth;
    public Transform player;
    private Rigidbody2D rb;
    protected float attackTimer;
    private float knockbackTimer;
    public bool isKnockback;
    public EnemyStatus status;
    private bool facingRight = true; // ตัวแปรเก็บสถานะการหันขวา โดย default เป็นหันขวา

    public event Action OnEnemyDeath;
    // Start is called before the first frame update
    private void Awake()
    {
        currentHealth = status.MaxHealth;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        attackTimer = Mathf.Clamp(attackTimer + Time.deltaTime,0,status.AttackDelay);
        if (GameManager.Instance.Pause)
        {
            rb.velocity = Vector3.zero;
            return;
        }
        if (isKnockback)
        {
            Knockback();  
        }else if(Vector3.Distance(transform.position, player.position) > status.AttackRange)
        {
            MoveTowardsPlayer(); 
        }else{
            rb.velocity = Vector3.zero;
            Attack();
        }
        
        TurnEnemy();

    }
    public void TurnEnemy()
    {
        if (player.position.x < transform.position.x && facingRight)
        {
            Flip();
        }
        else if (player.position.x > transform.position.x && !facingRight)
        {
            Flip();
        }
    }
    public virtual void Attack(){}

    private void MoveTowardsPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        direction.Normalize();
        rb.velocity = direction * status.MoveSpeed;

    }

    public void TakeDamage(float damage, bool IsKnockback)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            //print("Enemy attacks!");
            CoinsPooling.Instance.Pooling(transform.position, status.GiveCoin);
            ExperiencePooling.Instance.Pooling(transform.position, status.GiveExp);
            OnEnemyDeath?.Invoke();
            gameObject.SetActive(false);
        }
        if (IsKnockback)
        {
            ApplyKnockback();
        }


    }

    private void Knockback()
    {
        if (knockbackTimer > 0f)
        {
            knockbackTimer -= Time.deltaTime;
            if (knockbackTimer <= 0f)
            {
                rb.velocity = Vector3.zero;
                isKnockback = false;
            }
        }
    }

    private void ApplyKnockback()
    {
        Vector2 direction = transform.position - player.position;
        direction.Normalize();
        rb.AddForce(direction * status.knockbackForce, ForceMode2D.Impulse);
        knockbackTimer = status.knockbackDuration;
        isKnockback = true;
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
