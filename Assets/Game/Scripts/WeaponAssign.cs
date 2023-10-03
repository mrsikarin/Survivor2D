using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAssign : MonoBehaviour
{
    public static WeaponAssign Instace;
    public WeaponAssignUI[] weaponAssignUI;
    private List<GameObject> availableObjects;
    void Awake()
    {
        Instace = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //availableObjects = new List<GameObject>(objectOptions);

        // สุ่มและสร้างอ็อบเจกต์จากลิสต์ที่ไม่ซ้ำกัน
        // List<GameObject> randomizedObjects = RandomizeObjects();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnEnable()
    {
        
        List<Weapon> _weapons = new List<Weapon>(WeaponManager.Instace.Weapons);
        int count = _weapons.Count;
        for (int i = 0; i < count; i++)
        {
                if(_weapons[i].IsMaxLevel() && _weapons[i].gameObject.activeSelf)
                {
                    _weapons.RemoveAt(i);
                    count = _weapons.Count;
                    i--;
                }            
        }
        while (count > 3)
        {
                int index = Random.Range(0, _weapons.Count);
                _weapons.RemoveAt(index);
                count = _weapons.Count;
        }
        for (int i = 0; i < 3; i++)
        {
            if(i<count){
                weaponAssignUI[i].AssingWeapon(_weapons[i]);
                weaponAssignUI[i].gameObject.SetActive(true);
            }else
            {
                weaponAssignUI[i].gameObject.SetActive(false);
            }

        }

    }

}
