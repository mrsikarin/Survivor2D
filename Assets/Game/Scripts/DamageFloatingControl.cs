using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFloatingControl : MonoBehaviour
{
    public GameObject floatingObject;
    public static DamageFloatingControl instace;
    public List<DamageFloating> pools = new List<DamageFloating>();
    void Awake()
    {
        if(instace == null)
        {
            instace = this;
        }
    }
    public void CreateDamageFloating()
    {
        DamageFloating floating = Instantiate(floatingObject,transform).GetComponent<DamageFloating>();
        floating.gameObject.SetActive(false);
        pools.Add(floating);
        //return floating;
    }
    public void SetDamageFloating(float Damage,Vector3 diraction)
    {
        DamageFloating floating = GetPools();
        floating.transform.position = diraction;
        floating.SetupText(Damage);
        floating.gameObject.SetActive(true);
    }
    public DamageFloating GetPools()
    {
        
        DamageFloating floating = null;
        while(true)
        {
            int amount = pools.Count;
            for (int i = 0; i < amount; i++)
            {
                if(!pools[i].gameObject.activeInHierarchy)
                {
                    floating = pools[i];
                    return floating;
                }
            }
            if(floating == null)
                CreateDamageFloating();
        }



        
    }
}
