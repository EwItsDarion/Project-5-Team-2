/*
 Sarahi Murillo 
Team Project 5

Summary:
 
 
 
 
 
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private int waveNum = 0;
    private int infectedSpawnAmount = 4;
    private int infectedCured = 0;
    private int healthySpawnAmount = 8;

    public GameObject[] spawners;
    public GameObject infected;
    public GameObject healthy;
    public Transform centerPoint;
    public LevelManager levelManager;

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
        /*if(Input.GetKeyDown(KeyCode.T))
        {
            //calling method
            SpawnInfected();
        }*/
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
        waveNum = 1;
        infectedSpawnAmount = 4;
        healthySpawnAmount = 8;
        infectedCured = 0;

        for(int i = 0; i < infectedSpawnAmount; i++)
        {
            SpawnInfected();
        }

    }

    private void NextWave()
    {
        waveNum++;
        infectedSpawnAmount += 4;
        infectedCured = 0;

        for (int i = 0; i < infectedSpawnAmount; i++)
        {
            SpawnInfected();
        }

    }


    //This should probably be altered to accept different npc numbers at some point.
    IEnumerator SpawnNPCswithCoroutine() {
        for (int i = 0; i < healthySpawnAmount; i++)
        {
            SpawnHealthy();
            yield return new WaitForSeconds(0.2f);
        }

        for (int i = 0; i < infectedSpawnAmount; i++)
        {
            SpawnInfected();
            yield return new WaitForSeconds(0.2f);
        }
        levelManager.initialized = true;
    }

}
