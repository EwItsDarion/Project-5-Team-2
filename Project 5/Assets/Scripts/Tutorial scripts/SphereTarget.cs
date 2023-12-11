using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereTarget : MonoBehaviour
{
    int health;
    // Start is called before the first frame update
    void Start()
    {
        health = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            health--;
            GetComponent<Transform>().localScale -= new Vector3(.5f, .5f, .5f);
            Destroy(collision.gameObject);

        }

    }
}
