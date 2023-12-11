using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereTarget : MonoBehaviour
{
    int health;
    public ParticleSystem particles;
    // Start is called before the first frame update
    void Start()
    {
        health = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            particles.Play();
            Destroy(gameObject);
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            health--;
            Destroy(collision.gameObject);
           

        }

    }
}
