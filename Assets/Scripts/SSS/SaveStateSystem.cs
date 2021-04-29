using System;
using UnityEngine;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using DataContainers;


namespace SSS
{
    public static class SaveStateSystem
    {
        public static String _dataPath = Path.Combine(Application.persistentDataPath + "/player.fun");

        public static void SavePlayer(Save thePlayerData)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream stream = new FileStream(_dataPath, FileMode.Create);

            PlayerData data = new PlayerData(thePlayerData);
            
            formatter.Serialize(stream,data);
            stream.Close();
        }

        public static PlayerData LoadPlayer()
        {
            if (File.Exists(_dataPath))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(_dataPath, FileMode.Open);
                
                PlayerData data = formatter.Deserialize(stream) as PlayerData;
                stream.Close();
                
                return data;
            }
            else
            {
                Debug.LogError("Save file not found in " + _dataPath);
                return null;
            }
        }
    }
}
