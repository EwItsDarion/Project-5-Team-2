using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonAction : MonoBehaviour
{
  /*  public Canvas canvasToDisable;

    public void DisableCanvas()
    {
        canvasToDisable.enabled = false;
    }
    public void ButtonPressed()
    {
        // Load second scene in the build settings 
        DisableCanvas();
        SceneManager.LoadScene(1);

    }*/

    public void Tutorial()
    {
        // Will load the next scene 
        //Main Menue = 0 and tutorial = 1 

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Play()
    {
        //load scene 2 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);

    }

}
