using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingWeapon : Weapon
{
    private float shootingCounter;
    public float delay = 1f; // เวลาล่าช้า (วินาที)
    public float throwPower;
    //public Rigidbody2D theRB;
    private int amount = 0;
    public GameObject weaponObj;
    public List<GameObject> PoolingObject = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
       // theRB.velocity = new Vector2(Random.Range(-throwPower, throwPower), throwPower);
    }

    // Update is called once per frame
    void Update()
    {
        shootingCounter -= Time.deltaTime;
        if (shootingCounter <= 0)
        {
            Throwing();
            shootingCounter = delay;
        }
        //transform.rotation = Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z + (rotateSpeed * 360f * Time.deltaTime * Mathf.Sign(theRB.velocity.x)));
    }
    public void SetWeapon()
    {
        int count = 10;
        if (PoolingObject.Count < count)
        {
            for (int i = PoolingObject.Count; i < count; i++)
            {
                createObject();
            }

        }

    }
    public void createObject()
    {
        GameObject obj = Instantiate(weaponObj, transform.position, Quaternion.identity);
        obj.SetActive(false);
        PoolingObject.Add(obj);
    }
    private void Throwing()
    {
        amount =  weaponStatus[level].Amount;
        throwPower = weaponStatus[level].Range;
        delay = weaponStatus[level].Duration;
        GameObject obj = null;
        for (int i = 0; i < amount; i++)
        {
            obj = GetObjectPools();
            obj.transform.position = transform.position;
            obj.SetActive(true);
            Rigidbody2D objRigidbody = obj.GetComponent<Rigidbody2D>();
            objRigidbody.velocity = new Vector2(Random.Range(-throwPower, throwPower), throwPower);
            DamageThrow damageThrow  = obj.GetComponent<DamageThrow>();
            damageThrow.damage = weaponStatus[level].Damage;
            damageThrow.lifetime = weaponStatus[level].Lifetime;
            damageThrow.rotateSpeed = weaponStatus[level].Speed;
        }


        
    }
    public GameObject GetObjectPools()
    {
        while(true)
        {
            foreach (var item in PoolingObject)
            {
                if(!item.activeSelf)
                {
                    return item;
                }
            }
            createObject();
        }
    }
    public override void Upgrade()
    {
        base.Upgrade();

        if (isUpgrade)
        {
            SetWeapon();
            isUpgrade = false;
        }
    }
}
