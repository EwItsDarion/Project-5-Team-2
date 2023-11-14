using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LivingThing : MonoBehaviour
{

    public int health;



    protected virtual void Awake()
    {
        health = 50;
    }


    //In this case refers to becoming sick/healthy, it's more of a conversion
    protected abstract void Die();

    public void TakeDamage(int damage) {
        health -= damage;
        if (health <= 0) {
            Die();
        }
    }

}
