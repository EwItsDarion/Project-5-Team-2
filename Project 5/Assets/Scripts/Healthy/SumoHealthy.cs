using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SumoHealthy : Healthy
{
    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        health = 250;
        speed = 2.0f;

    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }
}
