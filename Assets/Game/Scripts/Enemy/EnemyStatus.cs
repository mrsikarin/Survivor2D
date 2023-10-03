using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName ="EnemyStatus",fileName ="new Enemy")]
public class EnemyStatus : ScriptableObject
{
    public float MaxHealth = 10f;
    public int GiveCoin = 1;
    public int GiveExp = 1;
    public float MoveSpeed = 3f;
    public float Damage = 1f;
    public float AttackDelay = 1.5f;
    public float AttackRange = 1.5f;
    public float knockbackForce = 5f;
    public float knockbackDuration = 0.2f;

}
