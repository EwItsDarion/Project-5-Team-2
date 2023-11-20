/*
 * Julian Avila
 * Project 2
 * Allows the gun to shoot and animate objects
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskCannon : MonoBehaviour
{
    public Projectile mask;
    public GameObject projectileSpawnPosition;
    private bool canShoot;
    [SerializeField] private Animator shotAnimation;
    RaycastHit hit;
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
        if (Input.GetMouseButtonUp(0)&&canShoot==true)
        {
            shotAnimation.SetTrigger("Shoot 0");

          
            Instantiate(mask, projectileSpawnPosition.transform.position, projectileSpawnPosition.transform.rotation);

            canShoot = false;
           

        }
      
    }

    IEnumerator AllowPlayerToShoot()
    {
        while (true)
        {
            
            yield return new WaitForSeconds(.2f);
            if(canShoot==false)
            canShoot = true;
        }
    }
}
