/*
 Sarahi Murillo 
Team Project 5

Summary:
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{

    public int numInfected = 0;  //THIS IS FOR OBSERVATION DURING TESTING, CONTROL OF UI, AND WAVE MANAGEMENT, IT IS UPDATED BY THE SCRIPTS
    public int numHealthy = 0;  //THIS IS FOR OBSERVATION DURING TESTING, CONTROL OF UI, AND WAVE MANAGEMENT, IT IS UPDATED BY THE SCRIPTS

    private Wave waveTemplate;  //I've made this private because it was confusing before. even though the design is still confusing, won't be confusing in the inspector anymore

    public GameObject[] spawners; //list of spawners

    //Prefabs
    public GameObject infected;     //prefabs 
    public GameObject healthy;
    public GameObject sumo;
    public GameObject baby;

    public Transform centrePoint;   //center of the space for NPCs to move

    // keep track of enemy count and 
    //public int infectedCount;

    public bool finishedSpawning;   //Helps to initialize waves and UI

    //public Text waveNum;


    // Start is called before the first frame update
    void Start()
    {
        finishedSpawning = false;
        //spawners = new GameObject[5];

        for (int i = 0; i < spawners.Length; i++)
        {
            spawners[i] = transform.GetChild(i).gameObject;
        }



        //StartWave();  //Changed for testing purposes
        //StartCoroutine(SpawnNPCswithCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        /*        infectedCount = GameObject.FindGameObjectsWithTag("Infected").Length;

                if(infectedCount == 0)
                {
                    StartWave();    // genuinely don't know why this would cause such an explosion in spawning but this is what I commented out and now it seems fine
                }*/

    }

    private void Spawn(GameObject NPC)
    {
        int spawnerID = Random.Range(0, spawners.Length);
        var spawned = Instantiate(NPC, spawners[spawnerID].transform.position, spawners[spawnerID].transform.rotation);
        SetVariables(spawned);
        //levelManager.numInfected++;
    }

    private void SetVariables(GameObject spawned)
    {
        spawned.GetComponent<NPC>().centrePoint = centrePoint;
        spawned.GetComponent<NPC>().spawner = this;
        //spawned.GetComponent<NPC>().levelManager = levelManager;
    }


    public void StartWave(Wave waveT)
    {
        /* //waveNum = 1;
         infectedSpawnAmount = 4;
         healthySpawnAmount = 8;
         //infectedCured = 0;

         for(int i = 0; i < infectedSpawnAmount; i++)
         {
             SpawnInfected();
         }*/
        waveTemplate = waveT;
        finishedSpawning = false;
        Debug.Log("false");
        StartCoroutine(SpawnNPCswithCoroutine());


    }

    /*    private void NextWave()   //Can probably just reuse startwave
        {
            //waveNum++;
            *//*infectedSpawnAmount += 4;
            //infectedCured = 0;

            for (int i = 0; i < infectedSpawnAmount; i++)
            {
                Spawn(infected);
            }
    *//*
        }*/


    //This could be reused, update the spawn amount integers and call the method to start a new wave
    IEnumerator SpawnNPCswithCoroutine()
    {
        for (int i = 0; i < waveTemplate.healthy; ++i)
        {
            Spawn(healthy);
            yield return new WaitForSeconds(0.2f);
        }

        for (int i = 0; i < waveTemplate.infected; ++i)
        {
            Spawn(infected);
            yield return new WaitForSeconds(0.2f);
        }

        finishedSpawning = true;
        Debug.Log("true");
        //levelManager.initialized = true;

        for (int i = 0; i < waveTemplate.sumo; ++i)
        {
            Spawn(sumo);
            yield return new WaitForSeconds(0.2f);
        }

        for (int i = 0; i < waveTemplate.baby; ++i)
        {
            Spawn(baby);
            yield return new WaitForSeconds(0.2f);
        }
    }

}