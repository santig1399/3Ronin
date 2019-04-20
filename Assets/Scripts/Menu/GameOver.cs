using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private PlayerHealth playerHealth;

    public GameObject respawnMenu;
    public GameObject gameOverMenu;

    private void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }
    private void Update()
    {
        if (playerHealth != null) {
            if (playerHealth.currentHeatlh <= 0)
            {
                if (playerHealth.canRespawn == true)
                {
                    respawnMenu.SetActive(true);
                    Time.timeScale = 0;
                }
                else
                {
                    gameOverMenu.SetActive(true);
                    Time.timeScale = 0;
                }
            }
        }
       
    }

    public void Respawn() {
        //compare de currency ammount
        respawnMenu.SetActive(false);
        playerHealth.canRespawn = false;
        playerHealth.TakeHealth(playerHealth.maxHealth);
        Time.timeScale = 1;
    }

    public void NoRespawn()
    {
        playerHealth.canRespawn = false;
        respawnMenu.SetActive(false);
        gameOverMenu.SetActive(true);
        playerHealth.Die();
        Time.timeScale = 0;
    }

    public void ExitFromGameOver()
    {
        gameOverMenu.SetActive(false);
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

}
