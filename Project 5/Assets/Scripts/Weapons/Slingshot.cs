using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : Weapon
{
    public Projectile mask,tempMask;
    public GameObject projectileSpawnPosition1;
    [SerializeField] private GameObject stringforSling;
    private Vector3 stringSize;
    private float velocity;
    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;
        StartCoroutine(AllowPlayerToShoot());
        stringSize = stringforSling.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && canShoot == true)
        {
            if(stringforSling.transform.localScale.z<stringSize.z+10)
            stringforSling.transform.localScale += new Vector3(0,0, 1);

            velocity += 10;
            canShoot = false;


        }
        if (Input.GetMouseButtonUp(0) && canShoot == false)
        {
            stringforSling.transform.localScale = stringSize;
            tempMask = Instantiate(mask, projectileSpawnPosition1.transform.position, projectileSpawnPosition1.transform.rotation);
            tempMask.GetComponent<Mask>().SetVelocity(velocity);
            velocity = 0;
        }
    }
    IEnumerator AllowPlayerToShoot()
    {
        //change while to till game over maybe?
        while (true)
        {
            yield return new WaitForSeconds(.2f);
            if (canShoot == false)
                canShoot = true;
        }
    }

    void OnEnable()
    {
        StartCoroutine(AllowPlayerToShoot());
    }
}


