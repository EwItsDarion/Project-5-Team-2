using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Infected : NPC
    {

        public int damage;
        protected override void Die()
        {
            throw new System.NotImplementedException();
        }

        protected void Cough(LivingThing hitObject) {
            hitObject.TakeDamage(damage);
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            
        }
    }
}