using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem{

    public static void Save(PlayerHealth playerHealth, Boss boss, EnemyHealth enemyHealth, Minon minion) {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/gamedata.sgv";
        FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate);
        if (boss != null)
        {

            PlayerData data = new PlayerData(playerHealth, boss, enemyHealth, minion);
            formatter.Serialize(fileStream, data);
        }
        else {
            PlayerData data = new PlayerData(playerHealth,minion);
            formatter.Serialize(fileStream, data);
        }

        fileStream.Close();
        
    }

    public static PlayerData Load() {
        string path = Application.persistentDataPath + "/gamedata.sgv";
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
