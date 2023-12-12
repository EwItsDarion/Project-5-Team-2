using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineWeapon : Weapon
{
    public Projectile mine, tempMine;
    public GameObject projectileSpawnPosition;
    [SerializeField] private MeshRenderer meshRender1, meshRender2;
    private float velocity;

    private void Awake()
    {
        unlocked = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;
        
        StartCoroutine(AllowPlayerToShoot());
      
     
    }

    // Update is called once per frame
    void Update()
    {
        if (canShoot == true)
            meshRender1.enabled = meshRender2.enabled = true;

        if (Input.GetMouseButtonUp(0) && canShoot == true)
        {
           
           Instantiate(mine, projectileSpawnPosition.transform.position, projectileSpawnPosition.transform.rotation);
            
            canShoot = false;
            meshRender1.enabled = meshRender2.enabled = false;
        }
        
       

    }

  
}

