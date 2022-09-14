using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem {
    
    public static void SaveGame(UserData data){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.bin";
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static UserData LoadData(){
        string path = Application.persistentDataPath+"/player.bin";
        if (File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            UserData data = formatter.Deserialize(stream) as UserData;
            stream.Close();
            return data;
        }
        else{
            Debug.Log("CANT LOAD PLAYER");
            return null;
        }
    }

    public static void SetData(int lvl, int moves, int rank){
        UserData data = SaveSystem.LoadData();
        data.user_data[lvl, 0] = moves;
        data.user_data[lvl, 1] = rank;
        SaveSystem.SaveGame(data);
    }
}