using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHeatlh;

    public AudioClip healingClip;
    public AudioClip hurtClip;

    Animator anim;


    void Start()
    {
        currentHeatlh = maxHealth;
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        if (currentHeatlh <= 0) {
            Debug.Log("current health: " + currentHeatlh);
            Die();

        }
    }

    public void TakeHealth(int health) {
        if (currentHeatlh < maxHealth) {
            currentHeatlh += health;
            //play healing sound
            Debug.Log(" taking healh");
        }
    }
    public void TakeDamage(int damage) {
        if (currentHeatlh > 0) {
            currentHeatlh -= damage;
            // hurt sound;
            Debug.Log("Taking Damage");
        }
    }
    public void Die() {
        //dead animation
        //dead sound
        //try again scene
        Debug.Log("player dead");
        Destroy(gameObject);

    }
}
