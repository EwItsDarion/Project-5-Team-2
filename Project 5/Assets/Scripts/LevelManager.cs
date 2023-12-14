using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using StarterAssets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public GameObject winImage;
    public GameObject loseImage;

    public List<Wave> waveTemplates;    //List of templates for use in the spawner.

    public GameObject Player;
    //public Image loseImage;

    public Spawner spawner;

    public string nextLevel;
    // Start is called before the first frame update
    //public GameObject waveButton;

    public Text scoreText;
    public Text dialogueText;
    public string dialogueCharacter = "Dr. Bright";
    public List<string> currentDialogue;
    public bool isDialogueActive;
    public Queue<string> dialogueQueue;
    public int numCount = 0;

    public Slider slider;
    public float FillSpeed = .05f;

    private float targetProgress = 0;
    private void Awake()
    {
        //SceneManager.SetActiveScene(SceneManager.GetSceneByName(GameManager.Instance.CurrentLevelname)); simply didn't work
        dialogueQueue = new Queue<string>();
    }
    void Start()
    {
        //SceneManager.SetActiveScene(SceneManager.GetSceneByName(GameManager.Instance.CurrentLevelname));
        //IncrementProgress(0.75f);
        wave = 0;
        isWaveActive = false;
        wonLevel = false;
        ActivateWave();

        dialogueQueue.Enqueue("Welcome to the simulation. Please try your best to survive.");
        dialogueQueue.Enqueue("Prepare for the first wave...");
        dialogueText.text = dialogueQueue.Dequeue();
        isDialogueActive = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (isDialogueActive && dialogueQueue.Count > 0)
        {
            dialogueText.text = dialogueQueue.Dequeue();

            if (dialogueQueue.Count == 0)
            {
                isDialogueActive = false;
            }


        }

        if (Input.GetKeyDown(KeyCode.N) && !isDialogueActive)
        {
            dialogueQueue.Enqueue("Preparing for the next wave...");
            dialogueText.text = dialogueQueue.Dequeue();
            isDialogueActive = true;
        }

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
            numCount++;
            wave++;
            if (numCount == 3)
            {
                int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                if (currentSceneIndex != 6)
                {
                    int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
                    SceneManager.LoadScene(nextSceneIndex);
                }
                else
                {
                    winImage.SetActive(true);
                }
            }

            if (wave < waveTemplates.Count)
            { //Are all waves done? if no
                dialogueText.enabled = true;
            }
            else
            { //finished with level when all waves are done
                wonLevel = true;
                print("The game is finished.");
                gameOver = true; //we probably need a different name and also behavior for this
            }

        }

        if (!isWaveActive && spawner.finishedSpawning && !gameOver)
        { //If the wave is not active and the spawner isn't spawning and the game isn't over, then this is probably after a wave has been completed
            scoreText.text = "Wave Complete!" + "\n" + "Press E for next wave!";
            if (Input.GetKeyDown(KeyCode.E))
            {
                ActivateWave();
                dialogueText.enabled = false;
            }
        }


        if (Player.GetComponent<Player>().health <= 0)
        { // if player dies, end level.
            gameOver = true;
            wonLevel = false;
        }



        /*        if (!isWaveActive) {  //perhaps we turn off the player controller when we finish a wave??
                    Player.GetComponent < FirstPersonController>().enabled = false;  //this might be dumb
                }*/


        if (gameOver == true)
        {
            if (wonLevel == true) //Game Over and Won
            {
                scoreText.text = "You Survived!" + "\n" + "Press E for next Level!";
            }
            else
            { //Game Over and Lost
                scoreText.text = "You Got Infected!" + "\n" + "Press R to try Again!";
                loseImage.SetActive(true);
            }
        }

        if (gameOver && !wonLevel && Input.GetKeyUp(KeyCode.R))
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(nextSceneIndex);
           // GameManager.Instance.NextLevel(GameManager.Instance.CurrentLevelname); //not actually next level in this case but loading a new instance and unloading this instance of the same level
        }

        if (gameOver && wonLevel && Input.GetKeyUp(KeyCode.E))
        {
            //spawner.DespawnAllNPCs();
            print("Attempting to load the next level");

            spawner.StartWave(waveTemplates[wave]);


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
        scoreText.text = "";
        dialogueQueue.Enqueue(dialogueCharacter + ": Starting wave " + wave);
        dialogueText.text = dialogueQueue.Dequeue();
        isDialogueActive = true;

        waveInitialized = false;
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