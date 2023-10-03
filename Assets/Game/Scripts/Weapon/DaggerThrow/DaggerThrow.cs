using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerThrow : Weapon
{
    private float timelifeCounter;
    private float shootingCounter;
    private float delay = 1f; // เวลาล่าช้า (วินาที)
    public GameObject bulletPrefab;
    private float bulletSpeed = 10f;
    private float rangeAttack = 5f;
    int Amount = 0;
    private GameObject[] enemies;
    public Transform PoolingPosition;
    public List<GameObject> PoolingObject = new List<GameObject>();

    private void Start()
    {
        SetWeapon();
    }

    private void Update()
    {
        shootingCounter -= Time.deltaTime;
        if (shootingCounter <= 0)
        {
            Shooting();
            shootingCounter = delay;
        }

    }

    public void SetWeapon()
    {
        Amount = weaponStatus[level].Amount;
        int count = Amount * 2;
        if (PoolingObject.Count < count)
        {
            for (int i = PoolingObject.Count; i < count; i++)
            {
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                bullet.GetComponent<DamageDagger>().damage = weaponStatus[level].Damage;

                rangeAttack = weaponStatus[level].Range;
                bulletSpeed = weaponStatus[level].Speed;
                bullet.GetComponent<DamageDagger>().lifeTime = weaponStatus[level].Lifetime;
                delay = weaponStatus[level].Duration;
                bullet.SetActive(false);
                PoolingObject.Add(bullet);
            }

        }

    }

    private void Shooting()
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, rangeAttack);
        List<Enemy> enemyControllers = new List<Enemy>();
        for (int i = 0; i < cols.Length; i++)
        {
            Enemy enemy = cols[i].GetComponent<Enemy>();
            if (enemy)
            {
                enemyControllers.Add(enemy);
            }
        }
        enemyControllers.Sort((a, b) =>
            {
                float distanceToA = Vector2.Distance(transform.position, a.transform.position);
                float distanceToB = Vector2.Distance(transform.position, b.transform.position);
                return distanceToA.CompareTo(distanceToB);
            });
        int count = (enemyControllers.Count < Amount) ? enemyControllers.Count : Amount;
        for (int i = 0; i < count; i++)
        {
            ShootBullet(enemyControllers[i].transform.position);
        }

    }

    private void ShootBullet(Vector3 targetPosition)
    {

        GameObject bullet = GetObjectPools();
        if (bullet == null)
            return;
        bullet.transform.position = transform.position;
        Vector3 targetDirection = targetPosition - bullet.transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        bullet.SetActive(true);
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = targetDirection.normalized * bulletSpeed;
    }

    public GameObject GetObjectPools()
    {
        foreach (var obj in PoolingObject)
        {
            if (!obj.activeSelf)
            {
                return obj;
            }
        }
        return null;
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
