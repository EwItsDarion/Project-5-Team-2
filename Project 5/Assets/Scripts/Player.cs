using System.Collections;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

namespace Assets.Scripts
{
    public class Player : LivingThing
    {

        public LevelManager levelManager;

        protected override void Awake()
        {
            base.Awake();
            health = 400;
        }

        protected override void Die()
        {
            levelManager.gameOver = true;
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