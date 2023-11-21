using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonAction : MonoBehaviour
{
    public Canvas canvasToDisable;

    public void DisableCanvas()
    {
        canvasToDisable.enabled = false;
    }
    public void ButtonPressed()
    {
        // Load second scene in the build settings 
        DisableCanvas();
        SceneManager.LoadScene(1);

    }
}
