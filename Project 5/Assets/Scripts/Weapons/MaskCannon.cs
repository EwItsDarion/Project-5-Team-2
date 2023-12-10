/*
 * Julian Avila
 * Project 2
 * Allows the gun to shoot and animate objects
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskCannon : Weapon
{
    public Projectile mask,tempMask;
    public GameObject projectileSpawnPosition1,projectileSpawnPosition2,projectileSpawnPosition3;
    [SerializeField] private Animator shotAnimation;
    RaycastHit hit;

    private void Awake()
    {
        unlocked = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;
        StartCoroutine(AllowPlayerToShoot());
       shotAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButton(0)&&canShoot==true)
        {
            shotAnimation.SetTrigger("Shoot 0");

      
            tempMask = Instantiate(mask, projectileSpawnPosition1.transform.position, projectileSpawnPosition1.transform.rotation);
            tempMask.GetComponent<Mask>().SetVelocity(50f);
            tempMask = Instantiate(mask, projectileSpawnPosition2.transform.position, projectileSpawnPosition2.transform.rotation);
            tempMask.GetComponent<Mask>().SetVelocity(50f);
            tempMask = Instantiate(mask, projectileSpawnPosition3.transform.position, projectileSpawnPosition3.transform.rotation);
            tempMask.GetComponent<Mask>().SetVelocity(50f);

            canShoot = false;
           

        }
      
    }

  
}
