using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Player : LivingThing
    {

        protected override void Awake()
        {
            base.Awake();
            health = 100;
        }

        protected override void Die()
        {
            throw new System.NotImplementedException();
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