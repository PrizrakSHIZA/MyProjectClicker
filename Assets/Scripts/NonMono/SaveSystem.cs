using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public static class SaveSystem
{
    /*
    public static void Save(int money, int level, int language, DateTime lastraid, List<Item> items)
    {
        Player.data.money = money;
        Player.data.level = level;
        Player.data.lastraid = lastraid;
        Player.data.items = items;
        Player.data.language = language;

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/save.sv";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(money, level, language, lastraid, items);

        formatter.Serialize(stream, data);
        stream.Close();
    }
    */

    public static void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/save.sv";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = Player.data;

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData Load()
    {
        string path = Application.persistentDataPath + "/save.sv";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;

            stream.Close();

            return data;
        }
        else
        {
            return null;
        }
    }
}
