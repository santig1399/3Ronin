using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PlayerHealth player;
    public GameObject bossPrefab;
    private Boss boss;
    private EnemyHealth enemyHealth;
    private Minon minion;
   
    private void Awake()
    {
        
        DontDestroyOnLoad(this);

        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        //player = FindObjectOfType<PlayerHealth>();
        //bossSpawner = FindObjectOfType<BossSpawnManager>();
        //boss = FindObjectOfType<Boss>();
        //enemyHealth = FindObjectOfType<EnemyHealth>();
        //minion = FindObjectOfType<Minon>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z)) {

            Load();
        }
    }
    private void OnApplicationQuit()
    {
        player = FindObjectOfType<PlayerHealth>();
        
        boss = FindObjectOfType<Boss>();
        enemyHealth = FindObjectOfType<EnemyHealth>();
        minion = FindObjectOfType<Minon>();
        SaveSystem.Save(player,boss,enemyHealth,minion);
        print("Se salio ");
    }

    public void Load()
    {
        player = FindObjectOfType<PlayerHealth>();
       
        boss = FindObjectOfType<Boss>();
        enemyHealth = FindObjectOfType<EnemyHealth>();
        minion = FindObjectOfType<Minon>();

        PlayerData data = SaveSystem.Load();

        if (player != null) {
            //player data loaded
            player.currentHeatlh = data.playerHealth;
            //player.TakeDamage(0);
            Vector3 position;
            position.x = data.position[0];
            position.y = data.position[1];
            position.z = data.position[2];
            player.transform.position = position;

        }


        //boss data load
        if (boss != null)
        {
            
            Vector3 bossPosition;
            bossPosition.x = data.bossPosition[0];
            bossPosition.y = data.bossPosition[1];
            bossPosition.z = data.bossPosition[2];
            boss.transform.position = bossPosition;
            enemyHealth.currentHeatlh = data.bossHealth;
            Debug.Log("boss was null");
        }
        else if (data.bossWasInstantiate && data.bossHealth > 0)
        {
            Instantiate(bossPrefab, new Vector3(data.bossPosition[0], data.bossPosition[1], data.bossPosition[2]), Quaternion.identity);
            enemyHealth.currentHeatlh = data.bossHealth;
            
            Debug.Log("boss was created becaause is null but was instantiated");
        }

        //minion data load
        if (minion != null)
        {
            enemyHealth.currentHeatlh = data.minionHealth;
            enemyHealth.TakeDamage(0);
            Vector3 minionPosition;
            minionPosition.x = data.minionPosition[0];
            minionPosition.y = data.minionPosition[1];
            minionPosition.z = data.minionPosition[2];
            minion.transform.position = minionPosition;
        }


        //}
    }

}
