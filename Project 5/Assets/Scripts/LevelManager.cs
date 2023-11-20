using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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

     public Text scoreText;
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

        wonDemo = false;
        initialized = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (initialized) { //can probably be changed, this is some sub-par logic to work with some slightly janky systems.
            totalNPC = numHealthy + numInfected;
            slider.maxValue = totalNPC;
            slider.value = 0;
            initialized = false; //so it only happens once
        }

        if (gameOver == true) {
            if (wonDemo == true) //Game Over and Won
            {
                scoreText.text = "You Survived!" + "\n" + "Press R to try Again!";
            }
            else { //Game Over and Lost
                scoreText.text = "You Got Infected!" + "\n" + "Press R to try Again!";
            }
        }

        if(gameOver && Input.GetKeyUp(KeyCode.R)) 
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }

        /*        if(slider.value < targetProgress)
                {
                    slider.value += FillSpeed * Time.deltaTime;
                }*/
        slider.value = numHealthy;

    }

    public void CheckWin() {
        if (numInfected == 0) {
            wonDemo = true;
            gameOver = true;
        }
    }

/*    public void IncrementProgress(float newProgress)
    {
       targetProgress = slider.value + newProgress;
    }*/
}
