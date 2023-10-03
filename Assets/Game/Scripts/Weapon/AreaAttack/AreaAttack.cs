using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaAttack : Weapon
{
    public GameObject AreaObj;
    public float scaleUp = 1.0f;
    public float scaleDown = 0f;
    public float rotateSpeed;
    private float lifetime;
    private float Duration;

    // Start is called before the first frame update
    void Start()
    {
        SetWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        AreaObj.transform.rotation = Quaternion.Euler(0f, 0f, AreaObj.transform.rotation.eulerAngles.z + (rotateSpeed * Time.deltaTime));
    }

    public void SetWeapon()
    {
        AreaObj.GetComponent<Damage>().damage = weaponStatus[level].Damage;
        scaleUp = weaponStatus[level].Range;
        rotateSpeed = weaponStatus[level].Speed;
        lifetime =  weaponStatus[level].Lifetime;
        Duration =  weaponStatus[level].Duration;
        StartCoroutine(Appear());
    }

    private IEnumerator Appear()
    {
        float scale = scaleDown;
        float duration = 0.4f; // Time duration for scaling (in seconds)
        AreaObj.SetActive(true);

        while (scale < scaleUp)
        {
            scale += Time.deltaTime / duration;
            AreaObj.transform.localScale = Vector3.one * scale;
            yield return null;
        }

        yield return new WaitForSeconds(weaponStatus[level].Lifetime);
        StartCoroutine(Disappear());
    }

    private IEnumerator Disappear()
    {
        float scale = scaleUp;
        float duration = 0.4f; // Time duration for scaling (in seconds)

        while (scale > scaleDown)
        {
            scale -= Time.deltaTime / duration;
            AreaObj.transform.localScale = Vector3.one * scale;
            yield return null;
        }

        AreaObj.SetActive(false);
        yield return new WaitForSeconds(weaponStatus[level].Duration);
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
