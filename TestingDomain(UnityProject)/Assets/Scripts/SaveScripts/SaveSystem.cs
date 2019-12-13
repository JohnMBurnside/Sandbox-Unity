using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
public static class SaveSystem
{
    public static void SavePlayer(Movement player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.save";
        FileStream stream = new FileStream(path, FileMode.Create);
        Save data = new Save(player);
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static Save LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.save";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            Save data = formatter.Deserialize(stream) as Save;
            stream.Close();
            return data;
        }
        else
        {
            Debug.Log("Save Error: Save file not found in " + path);
            return null;
        }
    }
}
