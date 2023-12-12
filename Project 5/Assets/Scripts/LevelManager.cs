using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using StarterAssets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    /*  public int numHealthy; // fairly unused right now, but can be used if we want to switch to a percentage win condition rather than completion
        public int numInfected;*/
    public int totalNPC;  //Commented out because I want to 
    public int wave;        //Integer wave value used to give the correct template when changing waves and also control game over
    public bool isWaveActive; //Is the wave active? (spawner is done spawning)

    private int numTotal;  //used for UI
    public bool gameOver;
    public bool wonLevel; //used for level end control
    public bool waveInitialized; // Control variable for UI

    public List<Wave> waveTemplates;    //List of templates for use in the spawner.

    public GameObject Player;

    public Spawner spawner;
    // Start is called before the first frame update
    //public GameObject waveButton;

    public Text scoreText;
    public Text waveTransition;
    public Slider slider;
    public float FillSpeed = .05f;

    private float targetProgress = 0;
    private void Awake()
    {
        //slider = gameObject.GetComponent<Slider>();
    }
    void Start()
    {
        //IncrementProgress(0.75f);
        wave = 0;
        isWaveActive = false;
        wonLevel = false;
        ActivateWave();

    }

    // Update is called once per frame
    void Update()
    {

        if (spawner.finishedSpawning && !waveInitialized) //UI update logic, if the spawner is finished spawning, and the wave hasn't been initialized(shitty name for UI update after spawner finishes)
        { //can probably be changed, this is some sub-par logic to work with some slightly janky systems.
            waveInitialized = true;
            isWaveActive = true;
            totalNPC = spawner.numHealthy + spawner.numInfected;
            slider.maxValue = totalNPC;
            slider.value = 0;
            //spawner.finishedSpawning = false; //so it only happens once
        }

        if (isWaveActive && spawner.numInfected == 0) //if the wave is active and the spawner isn't listing any infected then the wave is completed
        {//Boolean logic between this conditional and the one after it feels mega cringe but should work
            isWaveActive = false;
            wave++;
            if (wave < waveTemplates.Count)
            { //Are all waves done? if no
                waveTransition.enabled = true;
            }
            else { //finished with level when all waves are done
                wonLevel = true;
                gameOver = true; //we probably need a different name and also behavior for this
            }
            
        }

        if (!isWaveActive && spawner.finishedSpawning) { //If the wave is not active and the spawner isn't spawning, then this is probably after a wave has been completed
            if (Input.GetKeyDown(KeyCode.E)) {
                ActivateWave();
                waveTransition.enabled = false;
            }
        }


        if (Player.GetComponent<Player>().health <= 0) { // if player dies, end level.
            gameOver = true;
            wonLevel = false;
        }

        /*        if (!isWaveActive) {  //perhaps we turn off the player controller when we finish a wave??
                    Player.GetComponent < FirstPersonController>().enabled = false;  //this might be dumb
                }*/


                if (gameOver == true) {
                    if (wonLevel == true) //Game Over and Won
                    {
                        scoreText.text = "You Survived!" + "\n" + "Press R to try Again!";
                    }
                    else { //Game Over and Lost
                        scoreText.text = "You Got Infected!" + "\n" + "Press R to try Again!";
                    }
                }

        if (gameOver && Input.GetKeyUp(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }

        /*        if(slider.value < targetProgress)
                {
                    slider.value += FillSpeed * Time.deltaTime;
                }*/
        slider.value = spawner.numHealthy; //update slider info

    }

/*    public void EnableButton()
    {
        waveButton.SetActive(true);
    }*/

    public void ActivateWave()
    {
        waveInitialized= false;
        spawner.StartWave(waveTemplates[wave]);
    }

    public void CheckWin()
    {
        if (spawner.numInfected == 0)
        {
            isWaveActive = false;
            gameOver = true;
        }
    }

    /*    public void IncrementProgress(float newProgress)
        {
           targetProgress = slider.value + newProgress;
        }*/
}