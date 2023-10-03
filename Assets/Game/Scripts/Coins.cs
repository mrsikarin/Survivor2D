using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public int Amount = 0;
    public float Speed=5f;

    public Transform target;
    void Update()
    {
        if(target!=null)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position,Speed*Time.deltaTime);
            }
    }
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
       if(other.CompareTag("Player"))
       {
            GameManager.Instance.getCoins(Amount);
            gameObject.SetActive(false);
       }
    }
}
