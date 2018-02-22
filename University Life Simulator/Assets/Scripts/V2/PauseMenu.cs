using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    private static bool paused = false;

    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (!paused && pauseMenuUI.activeSelf == true)
            pauseMenuUI.SetActive(false);
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
        Time.timeScale = 1f;
        paused = false;

    }

    public void pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }

    public void load_settings()
    {
        Debug.Log("Bring Up Settings Menu...");
        //SceneManager.LoadScene("Settings");
    }

    public void quit()
    {
        Debug.Log("Bring Up Settings Menu...");
        Application.Quit();
    }
}
