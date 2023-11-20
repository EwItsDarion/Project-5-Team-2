using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonActionCredits : MonoBehaviour
{
  public void CreditSceneChange()
    {
        SceneManager.LoadScene(2);
    }
}
