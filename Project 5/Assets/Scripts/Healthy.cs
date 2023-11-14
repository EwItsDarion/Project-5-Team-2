using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Healthy : NPC
    {

        public GameObject infectedPrefab;

        protected override void Awake()
        {
            base.Awake();

        }
        protected override void Die()
        {
            Instantiate(infectedPrefab, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}