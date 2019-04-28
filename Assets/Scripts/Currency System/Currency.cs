using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Currency : MonoBehaviour
{
    public int currentSilverCoins;
    public int currentGoldCoins;
    public int startSilverCoins;
    public int startGoldCoins;
    [SerializeField]
    private int startAmmount = 0; //bool to control initial ammount given to player

    public Dialogue InitialDialogue;
    private int  introDialogue = 0;
    public GameObject initialSplashArt;

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
        introDialogue = PlayerPrefs.GetInt("Introduction"); 

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

    public void IntroDialogue(GameObject splashart) {
        if (introDialogue == 0)
        {
            introDialogue = 1;
            PlayerPrefs.SetInt("Introduction", introDialogue);
            splashart.SetActive(true);
            FindObjectOfType<DialogueManager>().Index = 0;
            FindObjectOfType<DialogueManager>().StartDialogue(InitialDialogue);
        }
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("SilverCoins", currentSilverCoins);
        PlayerPrefs.SetInt("GoldCoins", currentGoldCoins);
        Debug.Log("Saved Currency");
        Debug.LogWarning("on quit is deleting all player prefs");
        //PlayerPrefs.DeleteAll();
        
    }

}
