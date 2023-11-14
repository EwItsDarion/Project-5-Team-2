using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class NPC : LivingThing
{
    private NavMeshAgent nav;


    protected override void Awake()
    {
        base.Awake();
    }

    protected override abstract void Die();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
