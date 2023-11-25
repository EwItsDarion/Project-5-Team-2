using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    protected float velocity;
    protected Rigidbody rb;
    public int damage;

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


    public abstract void SetVelocity(float velocityOfProjectile);


}
