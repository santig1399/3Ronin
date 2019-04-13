using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PlayerHealth player;
    private BossSpawnManager bossSpawner;
    private Boss boss;
    private EnemyHealth enemyHealth;
    private Minon minion;

    void Start()
    {
        player = FindObjectOfType<PlayerHealth>();
        bossSpawner = FindObjectOfType<BossSpawnManager>();
        boss = FindObjectOfType<Boss>();
        enemyHealth = FindObjectOfType<EnemyHealth>();
        minion = FindObjectOfType<Minon>();

        DontDestroyOnLoad(this);
        
    }
    private void OnApplicationQuit()
    {
        SaveSystem.Save(player,bossSpawner,boss,enemyHealth,minion);
        print("Se salio ");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SaveSystem.Save(player, bossSpawner, boss, enemyHealth, minion);
            print("Saved Game");
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            PlayerData data = SaveSystem.Load();

            //player data loaded
            player.currentHeatlh = data.health;
            //player.TakeDamage(0);
            Vector3 position;
            position.x = data.position[0];
            position.y = data.position[1];
            position.z = data.position[2];
            GameObject.FindGameObjectWithTag("Player").transform.position = position;

            //boss data load
            if (boss != null)
            {
                bossSpawner.activated = data.bossWasInstantiate;
                Vector3 bossPosition;
                bossPosition.x = data.bossPosition[0];
                bossPosition.y = data.bossPosition[1];
                bossPosition.z = data.bossPosition[2];
                boss.transform.position = bossPosition;
                enemyHealth.currentHeatlh = data.bossHealth;
            }
            else if (data.bossWasInstantiate && data.bossHealth > 0) {
                Instantiate(bossSpawner.bossPrefab, new Vector3(data.bossPosition[0], data.bossPosition[1], data.bossPosition[2]), Quaternion.identity);
                enemyHealth.currentHeatlh = data.bossHealth;
                bossSpawner.activated = data.bossWasInstantiate;
            }
           
            //minion data load
            if (minion != null) {
                enemyHealth.currentHeatlh = data.minionHealth;
                enemyHealth.TakeDamage(0);
                Vector3 minionPosition;
                minionPosition.x = data.minionPosition[0];
                minionPosition.y = data.minionPosition[1];
                minionPosition.z = data.minionPosition[2];
                minion.transform.position = minionPosition;
            }
            
        }
    }

}
