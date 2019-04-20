using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossSpawnManager : MonoBehaviour
{
    public float minX;
    public float minY;
    public float maxX;
    public float maxY;

    private Boss boss;
    public GameObject bossPrefab;
    private Vector3 spawnPoint;
    private Vector3 centerRoom;
    
    
    public bool activated;
    private GameObject player;
    private Animator uiAnim;
    
    public Image bossImage;
    public Text bossNameText;
    public GameObject twinManager;

    public string bossName;
    public Sprite bossSprite;
    private InputHandler playerMov;

    private void Start()
    {
        boss = bossPrefab.GetComponent<Boss>();
        spawnPoint.Set(((maxX - minX) / 5) + minX, ((maxY - minY) / 2) + minY, 0);
        player = GameObject.FindGameObjectWithTag("Player");
        centerRoom.Set(((maxX - minX) / 2) + minX, ((maxY - minY) / 2) + minY,0);
        uiAnim = GameObject.FindGameObjectWithTag("UILevelInfo").GetComponent<Animator>();
        playerMov = GameObject.FindGameObjectWithTag("Player").GetComponent<InputHandler>();
        

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player") && !activated && bossPrefab != null) {
            print("player is on");
            boss.MinX = this.minX;
            boss.MinY = this.minY;
            boss.MaxX = this.maxX;
            boss.MaxY = this.maxY;

            bossImage.sprite = bossSprite;
            bossNameText.text = bossName;

            StartCoroutine(StageInfo());
            //Instantiate(bossPrefab, spawnPoint, Quaternion.identity);
            player.transform.position = centerRoom;
            activated = true;
            twinManager.SetActive(false);
        }
    }

    IEnumerator StageInfo() {

        uiAnim.SetTrigger("Fight");
        playerMov.enabled = false; 
        
        yield return new WaitForSeconds(2f);
        playerMov.enabled = true;
        
        yield return new WaitForSeconds(0.2f);
        Instantiate(bossPrefab, spawnPoint, Quaternion.identity);
        boss.wasInstantiated = true;
       ;
    }
}
