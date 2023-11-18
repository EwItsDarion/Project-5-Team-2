using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Healthy : NPC
    {

        public GameObject infectedPrefab;
        public bool masked;

        protected override void Awake()
        {
            base.Awake();
            masked = false;
        }
        protected override void Die()
        {
            Debug.Log("HealthyDead");
            GameObject swap = Instantiate(infectedPrefab, gameObject.transform.position, gameObject.transform.rotation);
            swap.GetComponent<NPC>().centrePoint = centrePoint;
            Destroy(gameObject);
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        protected void Update()
        {
            base.Update();
        }

        public override void headHit(Projectile projectile)
        {
            if (!masked) {
                masked = true;
                health += projectile.damage; //maybe needs alteration or balance, this behavior is to increase defense against coughs, in other words,
                                            // pre-shooting a mask onto a healthy individual gives them 2 coughs instead of one before being infected
            }
            
        }


        public void TakeDamage(int damage)
        {
            masked = false;
            base.TakeDamage(damage);
        }
    }
}