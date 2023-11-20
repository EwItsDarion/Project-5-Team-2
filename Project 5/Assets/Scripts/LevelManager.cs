using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public int numHealthy; // fairly unused right now, but can be used if we want to switch to a percentage win condition rather than completion
    public int numInfected;
    public int totalNPC;

    private int numTotal;
    public bool wonDemo;
    public bool gameOver;
    public bool initialized;
    // Start is called before the first frame update
    void Start()
    {
        wonDemo = false;
        initialized = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver == true) {
            if (wonDemo == true) //Game Over and Won
            {
                
            }
            else { //Game Over and Lost
                
            }
        }

    }

    public void CheckWin() {
        if (numInfected == 0) {
            wonDemo = true;
            gameOver = true;
        }
    }
}
