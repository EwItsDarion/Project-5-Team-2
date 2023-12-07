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
    //private int waveNum = 0;
    public int numInfected = 0;
    //private int infectedCured = 0;
    public int numHealthy = 0;

    public List<int> waveTemplate;

    public GameObject[] spawners;

    //Prefabs
    public GameObject infected;
    public GameObject healthy;

    public Transform centrePoint;

    // keep track of enemy count and 
    public int infectedCount;

    public bool finishedSpawning;

    //public Text waveNum;
   

    // Start is called before the first frame update
    void Start()
    {
        finishedSpawning = false;
        //spawners = new GameObject[5];
        
        for(int i = 0; i < spawners.Length; i++)
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

    private void SetVariables(GameObject spawned) { 
        spawned.GetComponent<NPC>().centrePoint = centrePoint;
        spawned.GetComponent<NPC>().spawner = this;
        //spawned.GetComponent<NPC>().levelManager = levelManager;
    }

    
    public void StartWave(List<int> waveT)
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
    IEnumerator SpawnNPCswithCoroutine() {
        for (int i = 0; i < waveTemplate[0]; ++i)
        {
            Spawn(healthy);
            yield return new WaitForSeconds(0.2f);
        }

        for (int i = 0; i < waveTemplate[1]; ++i)
        {
            Spawn(infected);
            yield return new WaitForSeconds(0.2f);
        }
        finishedSpawning = true;
        //levelManager.initialized = true;
    }

}
