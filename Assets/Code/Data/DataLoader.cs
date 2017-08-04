using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class DataLoader : MonoBehaviour {

    public void Update()
    {
        // Save the player data
        if (Input.GetKeyDown(KeyCode.S))
            SaveDataToJson();

        // Load the player data
        if (Input.GetKeyDown(KeyCode.L))
            LoadDataFromJson();

    }

    public static void SaveData()
    {
        // Store the data you want to save in the player data
        PlayerData playerSaveData = new PlayerData();
        playerSaveData.PlayerScore = Levels.CurrentLevel.Player.PlayerScore;

        // Save the PlayerData data structure
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/score.dat");
        bf.Serialize(file, playerSaveData);
        file.Close();

    }

    public static void SaveDataToJson()
    {
        PlayerData playerSaveData = new PlayerData();
        playerSaveData.PlayerScore = Levels.CurrentLevel.Player.PlayerScore;

        string playerJson = JsonUtility.ToJson(playerSaveData);
        File.WriteAllText(Application.persistentDataPath + "ScoreJson.json", playerJson.ToString());
    }

    public static void LoadData()
    {
        // First check if the file exists
        if (File.Exists(Application.persistentDataPath + "/score.dat"))
        {
            // Load in the binary save data
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open((Application.persistentDataPath + "/score.dat"), FileMode.Open);
            PlayerData playerSaveData = (PlayerData)bf.Deserialize(file);
            file.Close();

            // Set the player score based on the save data
            Levels.CurrentLevel.Player.PlayerScore = playerSaveData.PlayerScore;
        }
    }

    public static void LoadDataFromJson()
    {
        if(File.Exists(Application.persistentDataPath + "ScoreJson.json"))
        {
            string playerJson = File.ReadAllText(Application.persistentDataPath + "ScoreJson.json");
            PlayerData playerSaveData = new PlayerData();
            playerSaveData = JsonUtility.FromJson<PlayerData>(playerJson);

            Levels.CurrentLevel.Player.PlayerScore = playerSaveData.PlayerScore;
        }
    }
}
