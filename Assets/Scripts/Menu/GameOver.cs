using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private PlayerHealth playerHealth;

    public GameObject respawnMenu;
    public GameObject gameOverMenu;
    private Money money;

    private void Start()
    {
        money = FindObjectOfType<Money>();
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

    public void Respawn(string coin) {
        if (coin == "gold")
        {
            if (money.goldCoins - 10 >= 0)
            {
                respawnMenu.SetActive(false);
                playerHealth.canRespawn = false;
                playerHealth.TakeHealth(playerHealth.maxHealth);
                Time.timeScale = 1;
                money.SpendMoney(coin, 10);
            }
        }
        else if (coin == "silver") {
            if (money.silverCoins - 3 >= 0)
            {
                respawnMenu.SetActive(false);
                playerHealth.canRespawn = false;
                playerHealth.TakeHealth(playerHealth.maxHealth);
                Time.timeScale = 1;
                money.SpendMoney(coin, 3);
            }
        }
        
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
        FindObjectOfType<AudioManager>().Stop("AmbientMusic");
        Time.timeScale = 1;
    }

}
