using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class GameSaveManager : MonoBehaviour
{
    public Inventory mybag;
    // Start is called before the first frame update
    public void SaveGame()
    {
        Debug.Log(Application.persistentDataPath);
        if(!Directory.Exists(Application.persistentDataPath + "SaveData"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "SaveData");
            //Debug.Log("111");
        }
        BinaryFormatter formatter = new BinaryFormatter();//二进制转化
        FileStream file = File.Create(Application.persistentDataPath + "SaveData/saveData.txt");
        var json = JsonUtility.ToJson(mybag);
        formatter.Serialize(file, json);
        file.Close();
       
    }

    // Update is called once per frame
    public void LoadGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        if(File.Exists(Application.persistentDataPath + "SaveData/saveData.txt"))
        {
            FileStream file = File.Open(Application.persistentDataPath + "SaveData/saveData.txt", FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file),mybag);
            file.Close();
        }
        
    }
}
