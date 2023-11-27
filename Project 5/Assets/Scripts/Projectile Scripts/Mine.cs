using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : Projectile
{
    public GameObject explosionParicle;
    [SerializeField] private MeshRenderer meshRender1, meshRender2;
    private SphereCollider explosionCollider;
    private bool exploded;
    // Start is called before the first frame update
    void Start()
    {
        damage = 100;
        velocity = 10.0f;
        rb = gameObject.GetComponent<Rigidbody>();
        SetVelocity(velocity);
        StartCoroutine(DestroyObject());
        exploded = false;
        explosionCollider = gameObject.GetComponent<SphereCollider>();
        explosionCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(10f);
        Explode();
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Infected"))
        {
            Explode();
        }
    }

    void Explode()
    {
        if (exploded == false)
        {
            explosionCollider.enabled = true;
            explosionParicle.GetComponent<ParticleSystem>().Play();
            meshRender1.enabled = meshRender2.enabled = false;
            //GetComponent<Collider>().enabled = false;
            exploded = true;
        }
    }
}
