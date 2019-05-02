using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("MenuTheme");
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
        FindObjectOfType<AudioManager>().Play("StartButton");
        FindObjectOfType<AudioManager>().Stop("MenuTheme");
    }

    public void Back(){
        SceneManager.LoadScene("MainMenu");
    }
    public void Store()
    {
        SceneManager.LoadScene("Store");
        FindObjectOfType<AudioManager>().Stop("MenuTheme");
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    
}