using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Currency : MonoBehaviour
{
    public int currentSilverCoins;
    public int currentGoldCoins;
    public int startSilverCoins;
    public int startGoldCoins;
    [SerializeField]
    private int startAmmount = 0;

    public static Currency instance;

    void Awake()
    {
        DontDestroyOnLoad(this);

        if (instance == null)
        {
            instance = this;
        }
        else {
            Destroy(gameObject);
            return;
        }
        startAmmount = PlayerPrefs.GetInt("StartAmmount");

        if (startAmmount != 0) {
            currentSilverCoins = PlayerPrefs.GetInt("SilverCoins");
            currentGoldCoins = PlayerPrefs.GetInt("GoldCoins");
            Debug.Log("Loaded Currency" + currentSilverCoins + currentGoldCoins);
        }
        else if (startAmmount == 0) {
            currentSilverCoins = startSilverCoins;
            currentGoldCoins = startGoldCoins;
            startAmmount = 1;
            PlayerPrefs.SetInt("StartAmmount", startAmmount);
            Debug.Log("setted initial ammount");
        }
        
        
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("SilverCoins", currentSilverCoins);
        PlayerPrefs.SetInt("GoldCoins", currentGoldCoins);
     
        Debug.Log("Saved Currency");
    }

}
