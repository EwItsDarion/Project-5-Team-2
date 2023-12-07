using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    /*  public int numHealthy; // fairly unused right now, but can be used if we want to switch to a percentage win condition rather than completion
        public int numInfected;*/
    public int totalNPC;  //Commented out because I want to 
    public int wave;
    public bool isWaveActive;

    private int numTotal;               //Move 15-23 to a game Manager ?
    //public bool wonDemo;
    public bool gameOver;

    public List<Wave> waveTemplates;

    public Spawner spawner;
    // Start is called before the first frame update

    public Text scoreText;         
    public Slider slider;
    public float FillSpeed = .05f;      //

    private float targetProgress = 0;
    private void Awake()
    {
        //slider = gameObject.GetComponent<Slider>();
    }
    void Start()
    {
        //IncrementProgress(0.75f);

        isWaveActive = false;
        spawner.StartWave(waveTemplates[0]);

    }

    // Update is called once per frame
    void Update()
    {

        if (spawner.finishedSpawning) { //can probably be changed, this is some sub-par logic to work with some slightly janky systems.
            totalNPC = spawner.numHealthy + spawner.numInfected;
            slider.maxValue = totalNPC;
            slider.value = 0;
            spawner.finishedSpawning = false; //so it only happens once
        }

        

/*        if (gameOver == true) {
            if (wonDemo == true) //Game Over and Won
            {
                scoreText.text = "You Survived!" + "\n" + "Press R to try Again!";
            }
            else { //Game Over and Lost
                scoreText.text = "You Got Infected!" + "\n" + "Press R to try Again!";
            }
        }*/

        if(gameOver && Input.GetKeyUp(KeyCode.R)) 
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }

        /*        if(slider.value < targetProgress)
                {
                    slider.value += FillSpeed * Time.deltaTime;
                }*/
        slider.value = spawner.numHealthy;

    }

    public void CheckWin() {
        if (spawner.numInfected == 0) {
            isWaveActive = false ;
            gameOver = true;
        }
    }

/*    public void IncrementProgress(float newProgress)
    {
       targetProgress = slider.value + newProgress;
    }*/
}
