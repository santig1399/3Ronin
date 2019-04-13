using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem{

    public static void Save(PlayerHealth playerHealth, BossSpawnManager bossSpawner, Boss boss, EnemyHealth enemyHealth, Minon minion) {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/gameinfo.sgv";
        FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate);

        PlayerData data = new PlayerData(playerHealth, bossSpawner, boss, enemyHealth,minion);
        formatter.Serialize(fileStream, data);

        fileStream.Close();
        
    }

    public static PlayerData Load() {
        string path = Application.persistentDataPath + "/gameinfo.sgv";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path,FileMode.Open);

            PlayerData data = formatter.Deserialize(fileStream) as PlayerData;
            fileStream.Close();
            return data;
        }
        else {
            Debug.LogError("save file not found in: " + path);
            return null;
        }

    }
    
}
