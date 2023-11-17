﻿using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Infected : NPC
    {

        public int damage;
        public GameObject healthyPrefab;

        public float timeToCoughLow;
        public float timeToCoughHigh;

        private SphereCollider coughRadius;


        protected override void Awake()
        {
            base.Awake();
            damage = 50;
            timeToCoughLow = 1f;
            timeToCoughHigh = 6f;
            coughRadius = gameObject.GetComponent<SphereCollider>();
        }
        protected override void Die()
        {
            Debug.Log("InfectedDead");
            GameObject swap = Instantiate(healthyPrefab, gameObject.transform.position, gameObject.transform.rotation);
            swap.GetComponent<NPC>().centrePoint = centrePoint; //Defines centerpoint of NPC movement radius programmatically on swap
            Destroy(gameObject);
        }

        protected void CoughHit(LivingThing hitObject) {
            hitObject.TakeDamage(damage);
        }

        // Use this for initialization
        void Start()
        {
            StartCoroutine(CoughWithCoroutine());
        }

        // Update is called once per frame
        protected void Update()
        {
            base.Update();
        }

        IEnumerator CoughWithCoroutine() {
            yield return new WaitForSeconds(1f);

            while(health > 0) {
                coughRadius.enabled = true;
                yield return new WaitForSeconds(0.25f);
                coughRadius.enabled = false;
                yield return new WaitForSeconds(Random.Range(timeToCoughLow, timeToCoughHigh));
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Healthy")) {
                Debug.Log("HIT");
                CoughHit(other.gameObject.GetComponent<LivingThing>());
            }


        }
        
        //These parameters should be updated when we have a projectile class for polymorphism
        public override void headHit(GameObject projectile, int damage)
        {
            TakeDamage(damage);
        }
    }
}