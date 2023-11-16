using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mask : Projectile
{
    // Start is called before the first frame update
    void Start()
    {
        velocity = 50.0f;
        rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * velocity;
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
