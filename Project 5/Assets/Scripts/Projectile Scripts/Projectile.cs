using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    protected float velocity;
    protected Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        velocity = 5.0f;
        //StartCoroutine(DestroyObject());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //protected abstract IEnumerator DestroyObject();
       

   
}
