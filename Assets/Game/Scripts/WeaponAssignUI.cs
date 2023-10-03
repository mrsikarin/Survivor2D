using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponAssignUI : MonoBehaviour
{
    public Image Icon;
    public TMPro.TMP_Text Name_Text;
    public TMPro.TMP_Text detail;
    public Weapon _weapon;
    // Start is called before the first frame update
    public void AssingWeapon(Weapon weapon)
    {
        _weapon = weapon;
        Name_Text.text = _weapon.gameObject.name;
        Icon.sprite = weapon.Icon;
        detail.text = weapon.weaponStatus[weapon.level].detail;
    }
    public void UpgradesWeapon()
    {
        if(_weapon.gameObject.activeSelf)
        {
             _weapon.Upgrade();
        }else
        {
           _weapon.gameObject.SetActive(true);
        }
       
        GameManager.Instance.CloseUpgradeUI();
    }
}
