using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHeatlh;
    private float maxValue;
    public Slider healthSlider;
    public RectTransform fillImage;

    public AudioClip healingClip;
    public AudioClip hurtClip;

    Animator anim;


    void Start()
    {
        currentHeatlh = maxHealth;
        anim = GetComponent<Animator>();
        healthSlider.value = 100;
        maxValue = fillImage.sizeDelta.x;
    }

    
    void Update()
    {
        if (currentHeatlh <= 0) {
            Debug.Log("current health: " + currentHeatlh);
            Die();

        }
        if (currentHeatlh > maxHealth) {
            currentHeatlh = maxHealth;
        }

        //fillImage.sizeDelta = new Vector2(Mathf.Clamp(Mathf.MoveTowards(currentHeatlh * 130f / maxHealth,0f, 5f),0f,130f), 66.1f);
        
    }

    public void TakeHealth(int health) {
        if (currentHeatlh < maxHealth) {
            currentHeatlh += health;
            //healthSlider.value = currentHeatlh * 100 / maxHealth;
            //play healing sound
            fillImage.sizeDelta = new Vector2(Mathf.Clamp(Mathf.MoveTowards(currentHeatlh * 130f / maxHealth, 0f, 5f), 0f, 130f), 66.1f);
            Debug.Log(" taking healh");
        }
    }
    public void TakeDamage(int damage) {
        if (currentHeatlh > 0) {
            currentHeatlh -= damage;
            //healthSlider.value = currentHeatlh * 100 / maxHealth;
            fillImage.sizeDelta = new Vector2(Mathf.Clamp(Mathf.MoveTowards(currentHeatlh * 130f / maxHealth, 0f, 5f), 0f, 130f), 66.1f);
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
