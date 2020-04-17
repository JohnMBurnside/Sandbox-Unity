/*using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem
{
    //SAVE FUNCTIONS
    #region SAVE PLAYER FUNCTION
    public static void SavePlayer(Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.save";
        FileStream stream = new FileStream(path, FileMode.Create);
        Save data = new Save(player);
        formatter.Serialize(stream, data);
        stream.Close();
    }
    #endregion
    #region SAVE FUNCTION
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
    #endregion
}*/