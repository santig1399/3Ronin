using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    //payer data
    public int playerHealth;
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

    public PlayerData(PlayerHealth player, Boss boss, EnemyHealth enemyHealth, Minon minion)
    {
        if (player != null)
        {
            this.playerHealth = player.currentHeatlh;
            this.position = new float[3];
            this.position[0] = player.transform.position.x;
            this.position[1] = player.transform.position.y;
            this.position[2] = player.transform.position.z;

        }

        //boss
        if (boss != null)
        {
            this.bossWasInstantiate = boss.wasInstantiated;
            this.bossPosition = new float[3];
            this.bossPosition[0] = boss.transform.position.x;
            this.bossPosition[1] = boss.transform.position.y;
            this.bossPosition[2] = boss.transform.position.z;
            this.bossHealth = enemyHealth.currentHeatlh;
        }


        //minion
        if (minion != null)
        {
            this.minionHealth = enemyHealth.currentHeatlh;
            this.minionPosition = new float[3];
            this.minionPosition[0] = minion.transform.position.x;
            this.minionPosition[1] = minion.transform.position.y;
            this.minionPosition[2] = minion.transform.position.z;
        }
    }

    public PlayerData(PlayerHealth playerHealth) {
        this.playerHealth = playerHealth.currentHeatlh;
        this.position = new float[3];
        position[0] = playerHealth.transform.position.x;
        position[1] = playerHealth.transform.position.y;
        position[2] = playerHealth.transform.position.z;
    }

    public PlayerData(PlayerHealth playerHealth, Minon minion) {
        this.playerHealth = playerHealth.currentHeatlh;
        this.position = new float[3];
        position[0] = playerHealth.transform.position.x;
        position[1] = playerHealth.transform.position.y;
        position[2] = playerHealth.transform.position.z;
    }
}
