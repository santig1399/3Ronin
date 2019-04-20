using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   
    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Back(){
        SceneManager.LoadScene("MainMenu");
    }
    public void Store()
    {
        SceneManager.LoadScene("Store");
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    
}