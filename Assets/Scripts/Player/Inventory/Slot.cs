using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public int index;
    private Inventory inventory;
    private GameObject player;
    private Item item;
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        player = GameObject.FindGameObjectWithTag("Player");
        item = GameObject.FindGameObjectWithTag("Player").GetComponent<Item>();

    }

    // Update is called once per frame
    void Update()
    {
        if (player != null) {
            Vector2 itemPos = new Vector2(player.transform.position.x, player.transform.position.y + 3);
            if (transform.childCount <= 0)
            {
                inventory.isFull[index] = false;
            }
        }
        
    }

    public void Cross() {
        Vector2 itemPos = new Vector2(player.transform.position.x, player.transform.position.y + 1);
        foreach (Transform child in transform) {
            Instantiate(child.GetComponent<Item>().item,itemPos, Quaternion.identity);
            Destroy(child.gameObject);
        }
    }
    public void UseItem() {
        
        foreach (Transform child in transform)
        {
            //if (item.type == Item.typeOfItem.Potion) {
            //    Debug.Log("es una pocion");
            //}
            Instantiate(item.useEffect, player.transform.position, Quaternion.identity);
            Destroy(child.gameObject);
        }
    }
}

