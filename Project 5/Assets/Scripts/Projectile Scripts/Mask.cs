using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mask : Projectile
{
    // Start is called before the first frame update
    void Awake()
    {
        velocity = 50.0f;
        damage = 50;
        rb = gameObject.GetComponent<Rigidbody>();
     
        StartCoroutine(DestroyObject());
    }

    // Update is called once per frame
    void Update()
    {
      
    }


    protected IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    
}
