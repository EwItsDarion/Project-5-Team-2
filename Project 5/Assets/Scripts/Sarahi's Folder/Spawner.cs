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
    private int infectedSpawnAmount = 0;
    private int infectedCured = 0;

    public GameObject[] spawners;
    public GameObject infected;

    // Start is called before the first frame update
    void Start()
    {
        spawners = new GameObject[5];
        
        for(int i = 0; i < spawners.Length; i++)
        {
            spawners[i] = transform.GetChild(i).gameObject;
        }

        StartWave();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            //calling method
            SpawnInfected();
        }
    }

    private void SpawnInfected()
    {
        int spawnerID = Random.Range(0, spawners.Length);
        Instantiate(infected, spawners[spawnerID].transform.position, spawners[spawnerID].transform.rotation);
    }

    
    private void StartWave()
    {
        waveNum = 1;
        infectedSpawnAmount = 4;
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

}
