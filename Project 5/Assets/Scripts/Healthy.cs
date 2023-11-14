using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Healthy : NPC
    {

        protected override void Awake()
        {
            base.Awake();

        }
        protected override void Die()
        {
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