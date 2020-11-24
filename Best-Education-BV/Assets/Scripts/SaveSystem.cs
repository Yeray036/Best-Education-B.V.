using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    //Due to no mysqlserver the data will be saved locally on the machine in binary format, instead of plain text to prevent cheating.
    //SAVE
    public static void SavePlayer(Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        //This will be the path we're the savefile should be located, it will be different for every machine. 
        //because it will take a directory that doesn't get changed or deleted. after the plus it needs to get a
        //savefile name and your own extension.
        string path = Application.persistentDataPath + "/player.sav";
        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData data = new PlayerData(player);

        //Now we need to save this information using the stream and data.
        formatter.Serialize(stream, data);
        stream.Close();
    }

    //LOAD
    //Because we want the information from the PlayerData object saved in the player.sav file "LOAD PLAYER".
    //This will deserilize the binary file, and moves the attributes to this return method.
    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.sav";
        //If this action need to be performed multiple times, you should first check if there is indeed a save file. or else the code will crash.
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            //Now the Deserialize from the file in the stream and see the text inside as PlayerData.
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
            //Return data is "Return PlayerData".
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
