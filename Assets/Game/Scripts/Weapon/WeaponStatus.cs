using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName ="WeaponStatus",fileName ="new status")]
public class WeaponStatus : ScriptableObject
{
    public int Amount; // จำนวน
    public int Damage;  // ดาเมจ
    public int Speed;  // ความเร็ว
    public float Range; // ระยะการโจมตี
    public float Lifetime; // Time between attack
    public float Duration; // lifetime
    public System.String detail;
}
