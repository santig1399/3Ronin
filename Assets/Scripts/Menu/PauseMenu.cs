using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenu;
    public GameObject Controls;

    private void Update()
    {
        if (gameIsPaused)
        {
            Pause();
        }
        else {
            Resume();
        }
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Controls.SetActive(true);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Controls.SetActive(false);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
    public void Menu() {
        SceneManager.LoadScene("MainMenu");        
    }
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
