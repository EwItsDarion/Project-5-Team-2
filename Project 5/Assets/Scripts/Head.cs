using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Head : MonoBehaviour
    {

        private SphereCollider hitBox;
        private NPC parentObject;

        // Use this for initialization
        void Start()
        {
            hitBox = gameObject.GetComponent<SphereCollider>();
            parentObject = GetComponentInParent<NPC>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Projectile")) {
                parentObject.headHit(other.gameObject.GetComponent<Projectile>()); //grabs the projectile script for whatever projectile may have hit the head.
                Destroy(other.gameObject); //Destroys projectile before it can get stuck in the crowd and duplicate people?
            }
        }


    }
}