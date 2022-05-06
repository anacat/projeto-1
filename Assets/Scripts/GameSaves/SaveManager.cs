using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager
{
    public static string fileName = "/save.game";
    
    public static void SaveGame(GameSave gameSave)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + fileName);

        bf.Serialize(file, gameSave);
        file.Close();

        Debug.Log(string.Format("Saved at {0} coins, at {1}", gameSave.coinsCaught, Application.persistentDataPath + fileName));
    }

    public static GameSave Load()
    {
        GameSave gameSave = null;

        if (DoesSaveFileExist())
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + fileName, FileMode.Open);

            gameSave = (GameSave)bf.Deserialize(file);
            file.Close();
            
            Debug.Log(string.Format("Loaded {0} coins, from {1}", gameSave.coinsCaught, Application.persistentDataPath + fileName));
        }

        return gameSave;
    }

    public static bool DoesSaveFileExist()
    {
        return File.Exists(Application.persistentDataPath + fileName);
    }
}

//estrutura de dados que irão ser guardados; facilita a conversão do dados para binário e vice-versa
//tem de ser marcada como serializable para converter em binário
[Serializable]
public class GameSave 
{
    public int coinsCaught;
    public string gameString;
}