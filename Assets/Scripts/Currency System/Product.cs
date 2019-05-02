using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class Product : MonoBehaviour
{
    public string nameOfProduct;
    public int cost;
    public string typeOfCoin;

    public enum TypeOfProduct { BlackMask,WhiteMask}
    public TypeOfProduct typeOfProduct;

    public int itemsSolds;
    public int totalAmmount;

    private int BlackMaskSold;
    private int WhiteMaskSold;

    private Money money;
    void Start()
    {
        itemsSolds = PlayerPrefs.GetInt("ItemsSolds");
        totalAmmount = PlayerPrefs.GetInt("TotalAmmount");
        money = FindObjectOfType<Money>();
    }


    public void Buy() {

        itemsSolds++;
        totalAmmount += cost;

        if (typeOfProduct == TypeOfProduct.BlackMask)
        {
            BlackMaskSold++;
        }
        else if (typeOfProduct == TypeOfProduct.WhiteMask) {
            WhiteMaskSold++;
        }

        money.SpendMoney(typeOfCoin, cost);

        AnalyticsEvent.Custom("Product Sold", new Dictionary<string, object> {
            {"Product name", nameOfProduct},
            {"Type of product", typeOfProduct},
            {"Coin_Used",typeOfCoin},
            {"Cost", cost }
        });

        print("Should report");
        PlayerPrefs.SetInt("ItemsSolds", itemsSolds);
        PlayerPrefs.SetInt("TotalAmmount", totalAmmount);
    }


    public void CloseStore() {
        Analytics.CustomEvent("Product type most sold", new Dictionary<string, object> { //items sold each time that store is opened
            {"Whithe Mask",WhiteMaskSold},
            {"Black Mask", BlackMaskSold},
            {"Total", WhiteMaskSold+BlackMaskSold}
        });

        WhiteMaskSold = 0;
        BlackMaskSold = 0;
    }

    private void OnApplicationQuit()
    {
        Analytics.CustomEvent("Total sold (all lifetime)", new Dictionary<string, object> {
            {"total_items", itemsSolds},
            {"Total_Ammount", totalAmmount}
            });

        Dictionary<string, object> eventData = new Dictionary<string, object>();
        eventData.Add("Total Items Sold", itemsSolds);
        eventData.Add("Total Ammount Spended", totalAmmount);
        Analytics.CustomEvent("Total_Gold_Spended", eventData);
    }
}
