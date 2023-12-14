using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildInfected : Infected
{
    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        speed = 7.0f;
        health = 25;
        damage = 50;
        timeToCoughLow = 1;
        timeToCoughHigh = 3;
    }

    protected void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }
}
