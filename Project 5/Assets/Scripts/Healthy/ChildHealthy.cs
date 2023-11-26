using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ChildHealthy : Healthy
{
    /*public override void headHit(Projectile projectile)
    {
        throw new System.NotImplementedException();
    }

    protected override void Die()
    {
        throw new System.NotImplementedException(); 
    }*/

    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        health = 25;
        speed = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }
}
