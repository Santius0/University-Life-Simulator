using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Assertions;

using GameFramework.GameStructure.Levels;
using GameFramework.GameStructure;
using GameFramework.UI.Dialogs.Components;

public class PauseMenu : MonoBehaviour
{

    private static bool paused = false;

    public GameObject pauseMenuUI;

    private void Start()
    {
        pauseMenuUI.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
                resume();
            else
                pause();
        }

    }

    public void resume()
    {
        pauseMenuUI.SetActive(false);
        LevelManager.Instance.ResumeLevel();
        //Time.timeScale = 1f; //gets set in gameframework's LevelManager.Instance.ResumeLevel()
        paused = false;

    }

    public void pause()
    {
        pauseMenuUI.SetActive(true);
        Assert.IsTrue(LevelManager.IsActive, "Ensure that you have added a LevelManager component to your scene!");
        LevelManager.Instance.PauseLevel(true);
        //Time.timeScale = 0f; //gets set in gameframework's LevelManager.Instance.PauseLevel(true)
        paused = true;
    }

    public void load_settings()
    {
        Debug.Log("Bring Up Settings Menu...");
        //Assert.IsTrue(Settings.IsActive, "You must add a settings prefab to your scene!");
        //Settings.Instance.Show();
    }

    public void quit()
    {
        Debug.Log("Bring Up Settings Menu...");
        GameManager.Instance.SaveState();
        Application.Quit();
    }
}
