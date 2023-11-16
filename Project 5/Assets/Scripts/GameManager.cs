/*
		 * Arthur Peterson-Veatch
		 * GameManager.cs
		 * OOP proj
		 * Game Management code for menus and pausing
		 */


using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    
    public int score = 0;

    public GameObject pauseMenu;

    //level tracking variable
    private string CurrentLevelname = string.Empty;

    //methods to load and unload scenes

    public void LoadLevel(string levelName) {
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);

        if (ao == null) {
            Debug.Log("[GameManager] Unable to load level " + levelName);
            return;
        }

        CurrentLevelname= levelName;
        
    }

    public void UnloadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.UnloadSceneAsync(levelName);

        if (ao == null)
        {
            Debug.Log("[GameManager] Unable to unload level " + levelName);
            return;
        }

    }

    public void UnloadCurrentLevel() {
        AsyncOperation ao = SceneManager.UnloadSceneAsync(CurrentLevelname);

        if (ao == null)
        {
            Debug.Log("[GameManager] Unable to unload level " + CurrentLevelname);
            return;
        }

    }

    public void Pause()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }
    public void Unpause()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) {
            Pause();
        }
    }

}