using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public GameObject pickEffect;
    public GameObject useEffect;
    public GameObject item;
    public enum typeOfItem {Potion, Enchantment,Power}
    public typeOfItem type;

    public int health;

    public void UseItem() {
        if (type == typeOfItem.Potion)
        {
            FindObjectOfType<PlayerHealth>().TakeHealth(health);
            Debug.Log("Was a Potion");
        }
        else if (type == typeOfItem.Enchantment)
        {
            Debug.Log("Was an enchantment");
        }
        else if (type == typeOfItem.Power){
            Debug.Log("Was a power");
        }
        Debug.Log("Use Effect Must Be instantiate");
        Destroy(gameObject);
    }
}
