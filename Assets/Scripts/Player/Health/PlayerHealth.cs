using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHeatlh;
    private float maxValue;
    public bool canRespawn;
    public Slider healthSlider;
    public RectTransform fillImage;
    public Text lifeText;

    public GameObject respawnMenu;
    public GameObject gameOverMenu;

    public AudioClip healingClip;
    public AudioClip hurtClip;

    Animator anim;


    void Start()
    {
        canRespawn = true;
        currentHeatlh = maxHealth;
        anim = GetComponent<Animator>();
        healthSlider.value = 100;
        maxValue = fillImage.sizeDelta.x;
        lifeText.text = currentHeatlh.ToString() + "/" + maxHealth.ToString();
    }

    
    void Update()
    {
        if (currentHeatlh <= 0 && !canRespawn) {
            Debug.Log("current health: " + currentHeatlh);
            Die();
        }
        if (currentHeatlh > maxHealth) {
            currentHeatlh = maxHealth;
        }
        
        fillImage.sizeDelta = new Vector2(Mathf.Clamp(Mathf.MoveTowards(currentHeatlh * 130f / maxHealth,0f, 5f),0f,130f), 66.1f);
        
    }

    public void TakeHealth(int health) {
        if (currentHeatlh < maxHealth) {
            currentHeatlh += health;
            //healthSlider.value = currentHeatlh * 100 / maxHealth;
            //play healing sound
            fillImage.sizeDelta = new Vector2(Mathf.Clamp(Mathf.MoveTowards(currentHeatlh * 130f / maxHealth, 0f, 5f), 0f, 130f), 66.1f);
            lifeText.text = currentHeatlh.ToString() + "/" + maxHealth.ToString();
            Debug.Log(" taking healh");
        }
    }
    public void TakeDamage(int damage) {
        if (currentHeatlh > 0) {
            currentHeatlh -= damage;
            //healthSlider.value = currentHeatlh * 100 / maxHealth;
            fillImage.sizeDelta = new Vector2(Mathf.Clamp(Mathf.MoveTowards(currentHeatlh * 130f / maxHealth, 0f, 5f), 0f, 130f), 66.1f);
            lifeText.text = currentHeatlh.ToString() + "/" + maxHealth.ToString();
            // hurt sound;
            Debug.Log("Taking Damage");
        }
    }
    public void Die() {
        //dead animation
        //dead sound
        //try again scen
        if (this != null) {
            Destroy(this.gameObject);
            Debug.Log("player dead");

        }
        
        
    }
}
