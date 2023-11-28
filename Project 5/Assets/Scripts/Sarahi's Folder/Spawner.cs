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
    public int infectedSpawnAmount = 4;
    //private int infectedCured = 0;
    public int healthySpawnAmount = 8;

    public GameObject[] spawners;
    public GameObject infected;
    public GameObject healthy;
    public Transform centerPoint;
    public LevelManager levelManager;

    // keep track of enemy count and 
    public int infectedCount;

    public Text waveNum;
   

    // Start is called before the first frame update
    void Start()
    {
        //spawners = new GameObject[5];
        
        for(int i = 0; i < spawners.Length; i++)
        {
            spawners[i] = transform.GetChild(i).gameObject;
        }

        //StartWave();  //Changed for testing purposes
        StartCoroutine(SpawnNPCswithCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        infectedCount = GameObject.FindGameObjectsWithTag("Infected").Length;

        if(infectedCount == 0)
        {
            StartWave();
        }
      
    }

    private void SpawnInfected()
    {
        int spawnerID = Random.Range(0, spawners.Length);
        var spawned = Instantiate(infected, spawners[spawnerID].transform.position, spawners[spawnerID].transform.rotation);
        SetVariables(spawned);
        levelManager.numInfected++;
    }
    private void SpawnHealthy()
    {
        int spawnerID = Random.Range(0, spawners.Length);
        var spawned = Instantiate(healthy, spawners[spawnerID].transform.position, spawners[spawnerID].transform.rotation);
        SetVariables(spawned);
        levelManager.numHealthy++;
    }

    private void SetVariables(GameObject spawned) { 
        spawned.GetComponent<NPC>().centrePoint = centerPoint;
        spawned.GetComponent<NPC>().levelManager = levelManager;
    }

    
    private void StartWave()
    {
        /* //waveNum = 1;
         infectedSpawnAmount = 4;
         healthySpawnAmount = 8;
         //infectedCured = 0;

         for(int i = 0; i < infectedSpawnAmount; i++)
         {
             SpawnInfected();
         }*/

        StartCoroutine(SpawnNPCswithCoroutine());


    }

    private void NextWave()
    {
        //waveNum++;
        infectedSpawnAmount += 4;
        //infectedCured = 0;

        for (int i = 0; i < infectedSpawnAmount; i++)
        {
            SpawnInfected();
        }

    }


    //This could be reused, update the spawn amount integers and call the method to start a new wave
    IEnumerator SpawnNPCswithCoroutine() {
        for (int i = 0; i < healthySpawnAmount; ++i)
        {
            SpawnHealthy();
            yield return new WaitForSeconds(0.2f);
        }

        for (int i = 0; i < infectedSpawnAmount; ++i)
        {
            SpawnInfected();
            yield return new WaitForSeconds(0.2f);
        }
        levelManager.initialized = true;
    }

}
