using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : Weapon
{
    public float RotateSpeed;
    public Transform holder;
    public GameObject fireballPrefab;
    private List<GameObject> fireballObjects = new List<GameObject>();
    public float scaleup = 1.0f;
    public float scaledown = 0f;

    // Start is called before the first frame update
    void Start()
    {
        SetWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        holder.rotation = Quaternion.Euler(0f, 0f, holder.rotation.eulerAngles.z + (RotateSpeed * Time.deltaTime));
    }

    public void SetWeapon()
    {
        StopAllCoroutines();
        foreach (var fireball in fireballObjects)
        {
            Destroy(fireball);
        }
        fireballObjects.Clear();

        int amount = weaponStatus[level].Amount;
        float angle = Mathf.PI * 2f / amount;
        int Damage = weaponStatus[level].Damage;
        //scaleup =  weaponStatus[level].Range;
        for (int i = 0; i < amount; i++)
        {
            float rot = angle * i;
            Vector3 position = transform.position + new Vector3(Mathf.Cos(rot), Mathf.Sin(rot), 0) * weaponStatus[level].Range;

            GameObject fireball = Instantiate(fireballPrefab, position, Quaternion.identity);
            fireball.transform.SetParent(holder);
            fireball.GetComponent<Damage>().damage = Damage;
            fireballObjects.Add(fireball);
        }
    StartCoroutine(Appear());
    
    }

    private IEnumerator Appear()
    {
        float scale = scaledown;
        float duration = 0.4f; // ระยะเวลาในการขยายขนาด (วินาที)
        foreach (var fireball in fireballObjects)
        {
            fireball.SetActive(true);
        }
        while (scale < scaleup)
        {
            scale += Time.deltaTime / duration;

            foreach (var fireball in fireballObjects)
            {
                fireball.transform.localScale = Vector3.one * scale;
            }

            yield return null;
        }

        yield return new WaitForSeconds(weaponStatus[level].Lifetime);
       // appearCoroutine = null;
        StartCoroutine(Disappear());
    }

    private IEnumerator Disappear()
    {
        float scale = scaleup;
        float duration = 0.4f; // ระยะเวลาในการลดขนาด (วินาที)

        while (scale > scaledown)
        {
            scale -= Time.deltaTime / duration;

            foreach (var fireball in fireballObjects)
            {
                fireball.transform.localScale = Vector3.one * scale;
            }

            yield return null;
        }
        foreach (var fireball in fireballObjects)
        {
            fireball.SetActive(false);
        }
        yield return new WaitForSeconds(weaponStatus[level].Duration);
        //disappearCoroutine = null;
        StartCoroutine(Appear());
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
