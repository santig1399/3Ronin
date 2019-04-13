using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    //payer data
    public int health;
    public float[] position;

    //boss data
    public bool bossWasInstantiate;
    //public bool bossWasDead;
    public float[] bossPosition;
    public int bossHealth;

    //minion data
    //public bool minionWasDead;
    public float[] minionPosition;
    public int minionHealth;

    public PlayerData(PlayerHealth player, BossSpawnManager bossSpawner,Boss boss, EnemyHealth enemyHealth, Minon minion) {
        this.health = player.currentHeatlh;
        this.position = new float[3];
        this.position[0] = player.transform.position.x;
        this.position[1] = player.transform.position.y;
        this.position[2] = player.transform.position.z;

        //boss
        if (boss != null) {
            this.bossWasInstantiate = bossSpawner.activated;
            this.bossPosition = new float[3];
            this.bossPosition[0] = boss.transform.position.x;
            this.bossPosition[1] = boss.transform.position.y;
            this.bossPosition[2] = boss.transform.position.z;
            this.bossHealth = enemyHealth.currentHeatlh;
        }
        

        //minion
        this.minionHealth = enemyHealth.currentHeatlh;
        this.minionPosition = new float[3];
        this.minionPosition[0] = minion.transform.position.x;
        this.minionPosition[1] = minion.transform.position.y;
        this.minionPosition[2] = minion.transform.position.z;
    }
}
