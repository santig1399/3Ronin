using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHeatlh;

    public AudioClip healingClip;
    public AudioClip hurtClip;
    public Slider healthSlider;
    Animator anim;


    void Start()
    {
        currentHeatlh = maxHealth;
        healthSlider.value = currentHeatlh * 100 / maxHealth; 
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        healthSlider.value = currentHeatlh * 100 / maxHealth;

        if (currentHeatlh <= 0)
        {
            Debug.Log("Enemy current health: " + currentHeatlh);
            Die();

        }
    }

    public void TakeDamage(int damage)
    {
        
        currentHeatlh -= damage;
        healthSlider.value = currentHeatlh * 100 /maxHealth;
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
