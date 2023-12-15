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
    public GameObject maskVisual;

    private void Awake()
    {
        unlocked = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;
        StartCoroutine(AllowPlayerToShoot(1f));
        stringSize = stringforSling.transform.localScale;
       
    }

    // Update is called once per frame
    void Update()
    {

      if(canShoot)
            maskVisual.gameObject.SetActive(true);

        if (Input.GetMouseButton(0) && canShoot == true)
        {
            if(stringforSling.transform.localScale.z<stringSize.z+20)
            stringforSling.transform.localScale += new Vector3(0,0,10);

            velocity += 40;
            canShoot = false;
           

        }
        if (Input.GetMouseButtonUp(0) && canShoot == false)
        {
            stringforSling.transform.localScale = stringSize;
            tempMask = Instantiate(mask, projectileSpawnPosition1.transform.position, projectileSpawnPosition1.transform.rotation);
            tempMask.GetComponent<Mask>().SetVelocity(velocity);
            maskVisual.gameObject.SetActive(false);
            velocity = 0;
        }

    }


    protected void OnEnable()
    {
        StartCoroutine(AllowPlayerToShoot(1f));
    }
}


