using System.Collections;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Player : LivingThing
    {
        public Slider healthBar;
        public LevelManager levelManager;

        protected override void Awake()
        {
            base.Awake();
            health = 150;
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
            healthBar.value = health;
        }
    }
}