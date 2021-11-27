using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class GameSaveManager : MonoBehaviour
{
    public PlayerData playerData;
    public GameObject teamManager;
    public GameObject bagManager;
    public GameObject timeManager;
    public Text saveText;
    

    // Start is called before the first frame update
    public void SaveGame()
    {

        playerData.worldIndex = timeManager.GetComponent<TimeManage>().level;//传递轮回次数

        for (int i = 0; i < bagManager.transform.childCount; i++)
        {
            if(bagManager.transform.GetChild(i).gameObject.transform.childCount != 0)
            {
               if(bagManager.transform.GetChild(i).gameObject.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.consumable)
               {
                   Destroy(bagManager.transform.GetChild(i).gameObject.transform.GetChild(0).gameObject);
               }
            }
        }//删除背包内所有消耗品

        for (int i = 0; i < bagManager.transform.childCount; i++)
        {
            if(bagManager.transform.GetChild(i).gameObject.transform.childCount == 0)
            {
                playerData.bagList[i] = null;
            }
            if(bagManager.transform.GetChild(i).gameObject.transform.childCount != 0)
            {
                playerData.bagList[i] = bagManager.transform.GetChild(i).gameObject.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item;
                playerData.equipmentIndexList[i] = bagManager.transform.GetChild(i).gameObject.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().gemPrepertyIndex;
            }
        }//传递背包数据
        for (int i = 0; i < teamManager.transform.childCount; i++)
        {
            playerData.saveList[i].playerClass = teamManager.transform.GetChild(i).gameObject.GetComponent<TeamPlayer>().playerClass;
            playerData.saveList[i].growthAd = teamManager.transform.GetChild(i).gameObject.GetComponent<TeamPlayer>().growthAd;
            playerData.saveList[i].growthAp = teamManager.transform.GetChild(i).gameObject.GetComponent<TeamPlayer>().growthAp;
            playerData.saveList[i].growthTotalhp = teamManager.transform.GetChild(i).gameObject.GetComponent<TeamPlayer>().growthTotalhp; 
            playerData.saveList[i].growthSpeed = teamManager.transform.GetChild(i).gameObject.GetComponent<TeamPlayer>().growthSpeed; 
            playerData.saveList[i].growthDef = teamManager.transform.GetChild(i).gameObject.GetComponent<TeamPlayer>().growthDef; 
            playerData.saveList[i].growthMdef = teamManager.transform.GetChild(i).gameObject.GetComponent<TeamPlayer>().growthMdef; 
            playerData.saveList[i].growthCritDamge = teamManager.transform.GetChild(i).gameObject.GetComponent<TeamPlayer>().growthCritDamge; 
            playerData.saveList[i].growthIq = teamManager.transform.GetChild(i).gameObject.GetComponent<TeamPlayer>().growthIq;
            playerData.saveList[i].growthCharm = teamManager.transform.GetChild(i).gameObject.GetComponent<TeamPlayer>().growthCharm; 

            playerData.saveList[i].point = teamManager.transform.GetChild(i).gameObject.GetComponent<TeamPlayer>().point;
            playerData.saveList[i].Cpoint = teamManager.transform.GetChild(i).gameObject.GetComponent<TeamPlayer>().Cpoint;
            playerData.saveList[i].Spoint = teamManager.transform.GetChild(i).gameObject.GetComponent<TeamPlayer>().Spoint;
            playerData.saveList[i].SSSpoint = teamManager.transform.GetChild(i).gameObject.GetComponent<TeamPlayer>().SSSpoint;

            playerData.saveList[i].bloodNum = teamManager.transform.GetChild(i).gameObject.GetComponent<TeamPlayer>().bloodNum;
            for(int j = 0; j < teamManager.transform.GetChild(i).gameObject.GetComponent<TeamPlayer>().equipmentList.Count; j++)
            {
                if(teamManager.transform.GetChild(i).gameObject.GetComponent<TeamPlayer>().equipmentList[j] == null)
                {
                    playerData.saveList[i].equipmentList[j] = null; 
                    playerData.saveList[i].equipmentIndexList[j] = 0;
                }
                if(teamManager.transform.GetChild(i).gameObject.GetComponent<TeamPlayer>().equipmentList[j] != null)
                {
                    playerData.saveList[i].equipmentList[j] = teamManager.transform.GetChild(i).gameObject.GetComponent<TeamPlayer>().equipmentList[j].item;
                    playerData.saveList[i].equipmentIndexList[j] = teamManager.transform.GetChild(i).gameObject.GetComponent<TeamPlayer>().equipmentList[j].gemPrepertyIndex;
                }
               
                //playerData.saveList[i].equipmentIndexList[j] = teamManager.transform.GetChild(i).gameObject.GetComponent<TeamPlayer>().equipmentList[j].gemPrepertyIndex;
            }
            

        }
        saveText.text = playerData.saveList[0].playerClass.playerName + "     " + "第" + playerData.worldIndex.ToString() + "轮回";

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
   public void LoadGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        if(File.Exists(Application.persistentDataPath + "SaveData1/saveData.txt"))
        {
            FileStream file = File.Open(Application.persistentDataPath + "SaveData1/saveData.txt", FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file),playerData);
            file.Close();
        }
        InventoryMange.LoadGame();

                 
    }
}
