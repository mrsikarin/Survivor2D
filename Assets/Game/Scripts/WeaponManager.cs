using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public List<Weapon> Weapons = new List<Weapon>();
    public static WeaponManager Instace;
    // Start is called before the first frame update
    void Start()
    {
        Instace = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
