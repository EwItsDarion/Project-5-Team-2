using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonAction : MonoBehaviour
{
  public void ButtonPressed()
    {
        // Load second scene in the build settings 
        SceneManager.LoadScene(1);
    }
}
