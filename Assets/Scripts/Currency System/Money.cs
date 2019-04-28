using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    private Currency currency;
    private int silverCoins;
    private int goldCoins;

    public Text silverCoinsText;
    public Text goldCoinsText;


    void Start()
    {
        currency = FindObjectOfType<Currency>();
      
    }

    private void Update()
    {
        silverCoins = currency.currentSilverCoins;
        goldCoins = currency.currentGoldCoins;

        silverCoinsText.text = "x" + silverCoins;
        goldCoinsText.text = "x" + goldCoins;
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.T))
        {
            EarnMoney("gold", 2);
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            EarnMoney("silver", 10);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            SpendMoney("gold", 1);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            SpendMoney("silver", 9);
        } 
#endif
    }

    public void EarnMoney(string typeofCoin , int ammount) {
        if (typeofCoin == "silver")
        {
            silverCoins += ammount;
            silverCoinsText.text = "x" + silverCoins;
            currency.currentSilverCoins = silverCoins;
        }
        else if (typeofCoin == "gold") {
            goldCoins += ammount;
            goldCoinsText.text = "x" + goldCoins;
            currency.currentGoldCoins = goldCoins;
        }
    }
    public void SpendMoney(string typeofCoin , int ammount) {
        if (typeofCoin == "silver")
        {
            if (silverCoins - ammount >= 0)
            {
                silverCoins -= ammount;
                silverCoinsText.text = "x" + silverCoins;
                currency.currentSilverCoins = silverCoins;
            }
            else {
                Debug.Log("not enought silver coins");
            }    
        }
        else if (typeofCoin == "gold")
        {
            if (goldCoins - ammount >= 0)
            {
                goldCoins -= ammount;
                goldCoinsText.text = "x" + goldCoins;
                currency.currentGoldCoins = goldCoins;
            }
            else
            {
                Debug.Log("not enought gold coins");
            }
        }
    }
}
