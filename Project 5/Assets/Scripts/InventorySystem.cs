using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class InventorySystem : MonoBehaviour
{
    public Weapon[] weapons;
    public Weapon currWeapon;
    private int weaponNum;
    private int unlockedWeapons;
    // Start is called before the first frame update
    void Start()
    {
        for(int i =0;i<weapons.Length;i++)
        {
            weapons[i].gameObject.SetActive(false);
        }
        weaponNum = 0;
        EquipItem(weaponNum);

        if (SceneManager.GetActiveScene().name == "Tutorial")
            unlockedWeapons = 3;
        else
        unlockedWeapons = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            weapons[1].unlocked = true;
            weapons[2].unlocked = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weapons[weapons.Length - 1].gameObject.SetActive(false);
            weaponNum = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weaponNum = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            weaponNum = 2;
        }

        if (Input.GetAxisRaw("Mouse ScrollWheel")>0)
        {
            if (weaponNum >= unlockedWeapons - 1)
            {
                weaponNum = 0;
                weapons[weapons.Length - 1].gameObject.SetActive(false);
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
                weaponNum = unlockedWeapons-1;
                weapons[0].gameObject.SetActive(false);
            }
            else
            {
                weaponNum--;
            }
            
        }

        if (weapons[weaponNum].IsUnlocked())
            EquipItem(weaponNum);
        else
        {
            weaponNum = weapons.Length - 1;
        }

        if (weaponNum == unlockedWeapons - 1 && unlockedWeapons > 1)
            weapons[0].gameObject.SetActive(false);
        //if (weapons[weaponNum].unlocked)
        //{
        //    Debug.Log(weapons[weaponNum].IsUnlocked());
        //    EquipItem(weaponNum);
        //}

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

    private void OnEnable()
    {
        Start();
    }

}
