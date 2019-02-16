using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
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
        if (currentHeatlh <= 0)
        {
            Debug.Log("Enemy current health: " + currentHeatlh);
            Die();

        }
    }

    public void TakeDamage(int damage)
    {
        
            currentHeatlh -= damage;
            // hurt sound;
            Debug.Log("Enemy is Taking Damage");
     
    }
    public void Die()
    {
        //dead animation
        //dead sound
        //try again scene
        Debug.Log("Enemy dead");
        Destroy(gameObject);

    }
}
