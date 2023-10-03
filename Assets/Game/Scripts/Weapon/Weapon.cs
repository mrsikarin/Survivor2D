using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public List<WeaponStatus> weaponStatus;
    public int level;
    public bool isUpgrade;
    public Sprite Icon;

    public virtual void Upgrade()
    {

        if (level < weaponStatus.Count - 1)
        {
            level += 1;
            isUpgrade = true;
        }

    }
    public bool IsMaxLevel()
    {
        if(level >= weaponStatus.Count - 1)
            return true;

            
        return false;
    }
}
