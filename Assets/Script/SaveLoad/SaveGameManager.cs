using System.IO;
using UnityEngine;

namespace SaveLoad
{
    public static class SaveGameManager
    {
        public static SaveData CurrentSaveData = new SaveData();
        public const string SaveDirectory = "/SaveData/";
        public const string FileName = "SaveGame.dat";

        public static bool Save()
        {
            var dir = Application.persistentDataPath + SaveDirectory;
            if(!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            string json = JsonUtility.ToJson(CurrentSaveData, true);
            File.WriteAllText(dir + FileName, json);
            
            return true;
        }
        public static void Load()
        {
            string fullPath = Application.persistentDataPath + SaveDirectory + FileName;
            SaveData tempData = new SaveData();

            if(File.Exists(fullPath))
            {
                string json = File.ReadAllText(fullPath);
                tempData = JsonUtility.FromJson<SaveData>(json);
            } else {
                Debug.LogError("Save file does not exist!");

            }
            CurrentSaveData = tempData;

        }
    }
    

}
