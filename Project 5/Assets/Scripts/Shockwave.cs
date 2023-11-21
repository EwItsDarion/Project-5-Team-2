using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Shockwave : MonoBehaviour
{
    public float radius = 5f;
    public float force = 1000f;
    private LayerMask affectedLayers;

    public void setAffectedLayers(LayerMask layers)
    {
        affectedLayers = layers;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer ) & affectedLayers) != 0)
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if(rb != null)
            {
                Vector3 direction = other.transform.position - transform.position;
                direction.Normalize();
                rb.AddForce(direction * force, ForceMode.Impulse);
            }
        }
    }
}
