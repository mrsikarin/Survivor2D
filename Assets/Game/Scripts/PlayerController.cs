using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    Rigidbody2D _rb;
    public float speed = 5f;
    public float interactiveRange = 2;
    public Transform spritePlayer;
    public Animator anim;
    public bool facingRight;
    private int walkHash = Animator.StringToHash("speed");
    public PlayerStatus playerStatus;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        
        playerStatus = GetComponent<PlayerStatus>();
        _rb = GetComponent<Rigidbody2D>();
    }



    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector2 dir = new Vector2(h,v);
        _rb.velocity = dir * speed;
        anim.SetFloat(walkHash,Mathf.Clamp(Mathf.Abs(h)+Mathf.Abs(v),0,1));
        if (h > 0 && !facingRight)
        {
            Flip();
        }
        else if (h < 0 && facingRight)
        {
            Flip();
        }
        Interactive();
    }
    public void Interactive()
    {
        Collider2D[] col = Physics2D.OverlapCircleAll(transform.position,interactiveRange);
        foreach (var item in col)
        {
            Coins coins = item.GetComponent<Coins>();
            Experience exp = item.GetComponent<Experience>();
            if(coins && coins.target==null)
            {
                coins.target = transform;
            }
            if(exp && exp.target==null)
            {
                exp.target = transform;
            }
        }
        
    }
    public void Flip(){
        facingRight = !facingRight;
        Vector3 scalePlayer = spritePlayer.transform.localScale;
        scalePlayer.x *= -1;
        spritePlayer.transform.localScale = scalePlayer;

    }
}
