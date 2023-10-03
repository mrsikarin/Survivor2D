using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DamageFloating : MonoBehaviour
{
    public TMP_Text damageText;
    public float liftTime = 1f;
    private float liftCounter = 0;
    public float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        liftCounter = Mathf.Clamp(liftCounter- Time.deltaTime,0,liftTime);
        transform.position = transform.position + Vector3.up * speed * Time.deltaTime;
        if(liftCounter <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    public void SetupText(float damage)
    {
        liftCounter = liftTime;
        damageText.text = damage.ToString();
    }
}
