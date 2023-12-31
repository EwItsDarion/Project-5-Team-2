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

        public AudioClip cough;
        private ParticleSystem coughParticle;
        

        private SphereCollider coughRadius;
        private bool isDead = false;


        protected override void Awake()
        {
            base.Awake();
            damage = 50;
            timeToCoughLow = 1f;
            timeToCoughHigh = 6f;
            coughRadius = gameObject.GetComponent<SphereCollider>();
            coughParticle = GetComponent<ParticleSystem>();
        }
        protected override void Die()
        {
            Debug.Log("InfectedDead");
            if (!isDead)
            {
                isDead = true;
                GameObject swap = Instantiate(healthyPrefab, gameObject.transform.position, gameObject.transform.rotation);
                //swap.GetComponent<NPC>().centrePoint = centrePoint; //Defines centerpoint of NPC movement radius programmatically on swap
                SetVariables(swap);

                int index = spawner.spawnedNPCs.IndexOf(gameObject);
                if (index != -1)
                {
                    spawner.spawnedNPCs[index] = swap;
                }

                spawner.numInfected--;


                /*levelManager.numHealthy++;*/
                //levelManager.CheckWin();
                Destroy(gameObject);
            }
        }

        protected void CoughHit(LivingThing hitObject) {
            hitObject.TakeDamage(damage);
        }

        // Use this for initialization
        protected void Start()
        {
            spawner.numInfected++;
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
                audioSource.PlayOneShot(cough);
                coughParticle.Play();
                yield return new WaitForSeconds(0.25f);
                coughRadius.enabled = false;
                yield return new WaitForSeconds(Random.Range(timeToCoughLow, timeToCoughHigh));
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Healthy") || other.CompareTag("Player")) {
                Debug.Log("HIT");
                CoughHit(other.gameObject.GetComponent<LivingThing>());
            }


        }
        

        public override void headHit(Projectile projectile)
        {
           //audioSource.PlayOneShot(hitSound, 2.0f);
            TakeDamage(projectile.damage);
        }
    }
}