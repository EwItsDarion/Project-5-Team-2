using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SumoInfected : Infected
{
    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        health = 250;
        speed = .50f;
        damage = 70;
        timeToCoughLow = 5;
        timeToCoughHigh = 10;
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
