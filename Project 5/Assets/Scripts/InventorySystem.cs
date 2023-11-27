using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public Weapon[] weapons;
    public Weapon currWeapon;
    private int weaponNum;
    
    // Start is called before the first frame update
    void Start()
    {
        for(int i =0;i<weapons.Length;i++)
        {
            weapons[i].gameObject.SetActive(false);
        }
        weaponNum = 0;
        EquipItem(weaponNum);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Mouse ScrollWheel")>0)
        {
            if (weaponNum >= weapons.Length - 1)
            {
                weapons[weapons.Length-1].gameObject.SetActive(false);
                weaponNum = 0;
            }
            else
            {
                weaponNum++;
            }
        }
        if(Input.GetAxisRaw("Mouse ScrollWheel")<0)
        {
            if (weaponNum <= 0)
            {
                weaponNum = weapons.Length - 1;
                weapons[0].gameObject.SetActive(false);
            }
            else
            {
                weaponNum--;
            }
            
        }
        EquipItem(weaponNum);
    }


    void EquipItem(int index)
    {
        if (index > 0)
        {
            weapons[index - 1].gameObject.SetActive(false);
        }
        if(index<weapons.Length-1)
        weapons[index + 1].gameObject.SetActive(false);

        
        weapons[weaponNum].gameObject.SetActive(true);
        
    }
}