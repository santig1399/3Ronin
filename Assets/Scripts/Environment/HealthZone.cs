using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthZone : MonoBehaviour
{
    public float timeToHeal;
    private float timmer;
    public int healthAmmount;
    private PlayerHealth playerHealth;
    [SerializeField]
    private bool isUsed = false;
    void Start()
    {
        timmer = timeToHeal;
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>(); 
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isUsed)
        {
           
            if (timmer <= 0)
            {
                playerHealth.TakeHealth(healthAmmount);
                timmer = timeToHeal;
            }
            else {
                timmer -= Time.deltaTime;
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){
            isUsed = true;
        }
    }

   
}
