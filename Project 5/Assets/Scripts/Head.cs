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
            if (other.CompareTag("Mask")) {
                parentObject.headHit(other.gameObject, 50);
            }
        }


    }
}