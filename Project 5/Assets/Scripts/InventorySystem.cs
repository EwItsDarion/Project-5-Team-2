using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public Weapon[] weapons;
    private Weapon currWeapon;
    private int weaponNum;
    // Start is called before the first frame update
    void Start()
    {

        weaponNum = 0;
        currWeapon = weapons[weaponNum];
        currWeapon.gameObject.SetActive(true);

        for(int i = 1; i<weapons.Length;i++)
        {
            weapons[i].gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel")>0)
        {
            if(weaponNum<weapons.Length-1)
            weaponNum++;
        }
        if(Input.GetAxis("Mouse ScrollWheel")<0)
        {
            //if (weaponNum > 0 )
                weaponNum--;
        }
        currWeapon = weapons[weaponNum];
        currWeapon.gameObject.SetActive(true);
    }
}
