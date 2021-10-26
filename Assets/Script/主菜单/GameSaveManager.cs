using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class GameSaveManager : MonoBehaviour
{
    public GameObject teamManager;
    public GameObject bagManager;
    //public Inventory mybag;
    public PlayerData playerData;
    // Start is called before the first frame update
    public void SaveGame()
    {
        
        if(!Directory.Exists(Application.persistentDataPath + "SaveData1"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "SaveData1");
            //Debug.Log("111");
        }
        BinaryFormatter formatter = new BinaryFormatter();//二进制转化
        FileStream file = File.Create(Application.persistentDataPath + "SaveData1/saveData.txt");
        var json = JsonUtility.ToJson(playerData);
        formatter.Serialize(file, json);
        file.Close();
       
    }

    // Update is called once per frame
    public void LoadGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        if(File.Exists(Application.persistentDataPath + "SaveData1/saveData.txt"))
        {
            FileStream file = File.Open(Application.persistentDataPath + "SaveData1/saveData.txt", FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file),playerData);
            file.Close();
        }
        
    }
}
