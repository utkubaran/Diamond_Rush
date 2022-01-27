using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    /// <summary>
    /// This script is for save & load function of the game.
    /// Save & Load system could be applied with PlayerPrefs but I would like to use Json to
    /// show my skills.
    /// </summary>
    /// 
    public static DataManager instace;

    private string file = "player_data.txt";

    public string FilePath { get { return Application.persistentDataPath + "/" + file; } }

    private void Awake()
    {
        instace = this;
    }

    public void Save(PlayerData playerData)
    {

        string json = JsonUtility.ToJson(playerData);
        WriteToFile(file, json);
    }

    public PlayerData Load()
    {
        string json = ReadFromFile(file);
        PlayerData playerData = JsonUtility.FromJson<PlayerData>(json);
        return playerData;
    }

    private void WriteToFile(string fileName, string json)
    {
        string path = GetFilePath(fileName);
        FileStream fileStream = new FileStream(path, FileMode.Create);

        using(StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(json);
        }
    }

    private string ReadFromFile(string fileName)
    {
        string path = GetFilePath(fileName);

        if (File.Exists(path))
        {
            using(StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadToEnd();
                return json;
            }
        }
        else
        {
            Debug.LogWarning("File not found!");
            return null;
        }
    }

    private string GetFilePath(string fileName)
    {
        return Application.persistentDataPath + "/" + fileName;
    }
}
