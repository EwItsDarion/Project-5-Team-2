using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineWeapon : Weapon
{
    public Projectile mine, tempMine;
    public GameObject projectileSpawnPosition;
    [SerializeField] private MeshRenderer meshRender1, meshRender2;
    private float velocity;
    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;
        StartCoroutine(AllowPlayerToShoot());
     
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && canShoot == true)
        {
           
           Instantiate(mine, projectileSpawnPosition.transform.position, projectileSpawnPosition.transform.rotation);
            
            canShoot = false;
            meshRender1.enabled = meshRender2.enabled = false;
        }
    }

    IEnumerator AllowPlayerToShoot()
    {
        while (true)
        {

            yield return new WaitForSeconds(1f);
            if (canShoot == false)
            {
                canShoot = true;
                meshRender1.enabled = meshRender2.enabled = true;
            }
           
        }
    }
}

