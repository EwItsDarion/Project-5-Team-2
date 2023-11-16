// made a list of a class that contains a list of the number of zombies spawnes per round. List of waves that contain a list of zombie objects. 


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// declare 
//[System.Serializable]

public class WaveSpawner : MonoBehaviour
{

    [System.Serializable]
    public class WaveContent
    {
        [SerializeField] GameObject[] zombieSpawner;

        public GameObject[] GetZombieSpawnList()
        {
            return zombieSpawner;
        }
    }

    [SerializeField] WaveContent[] waves;
    int currWave = 0;
    float spawnRange = 10;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnWave()
    {
        // checks the current wave class and gets the length of the xombie object list. It iterates through the zombie objects until all objects are covered in currWave.
        for (int i = 0; i < waves[currWave].GetZombieSpawnList().Length; i++)
        {
            Instantiate(waves[currWave].GetZombieSpawnList()[i], FindSpawnLoc(), Quaternion.identity);
        }
    }

    Vector3 FindSpawnLoc()
    {
        Vector3 SpawnPos;

        float xPos = Random.Range(-spawnRange, spawnRange) + transform.position.x;
        float zPos = Random.Range(-spawnRange, spawnRange) + transform.position.z;
        // fix this position
        float yPos = transform.position.y;

        SpawnPos = new Vector3(xPos, yPos, zPos);

        if (Physics.Raycast(SpawnPos, Vector3.down, 5))
        {
            return SpawnPos;
        }
        else
        {
            return FindSpawnLoc();
        }

    }

}
