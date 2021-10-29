using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class GameSaveManager : MonoBehaviour
{
    public PlayerData playerData;
    public GameObject teamManager;
    public GameObject bagManager;
    public GameObject timeManager;

    // Start is called before the first frame update
    public void SaveGame()
    {
        playerData.worldIndex = timeManager.GetComponent<TimeManage>().level;
        for (int i = 0; i < bagManager.transform.childCount; i++)
        {
            if(bagManager.transform.GetChild(i).gameObject.transform.childCount == 0)
            {
                playerData.bagList[i] = null;
            }
            if(bagManager.transform.GetChild(i).gameObject.transform.childCount != 0)
            {
                playerData.bagList[i] = bagManager.transform.GetChild(i).gameObject.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item;
            }
        }
        for (int i = 0; i < teamManager.transform.childCount; i++)
        {
            if(teamManager.transform.GetChild(i).gameObject.GetComponent<TeamPlayer>().playerClass  == null)
            {
                playerData.playerList[i] = null;
            }
            if(teamManager.transform.GetChild(i).gameObject.GetComponent<TeamPlayer>().playerClass  != null)
            {
                playerData.playerList[i] = teamManager.transform.GetChild(i).gameObject.GetComponent<TeamPlayer>();
            }
        }


        if(!Directory.Exists(Application.persistentDataPath + "SaveData1"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "SaveData1"); 
        }
        BinaryFormatter formatter = new BinaryFormatter();//二进制转化
        FileStream file = File.Create(Application.persistentDataPath + "SaveData1/saveData.txt");
        var json = JsonUtility.ToJson(playerData);
        formatter.Serialize(file, json);
        file.Close();    
    }

    // Update is called once per frame
   /* public void LoadGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        if(File.Exists(Application.persistentDataPath + "SaveData1/saveData.txt"))
        {
            FileStream file = File.Open(Application.persistentDataPath + "SaveData1/saveData.txt", FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file),playerData);
            file.Close();
        }
        
    }*/
}
