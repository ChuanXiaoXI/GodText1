using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMange : MonoBehaviour
{
    static InventoryMange instance;
    public PlayerData playerData;

    public GameObject timeManage;
    public List<GameObject> playerList = new List<GameObject>();
    public List<GameObject> equipmentGridList = new List<GameObject>();
    public List<GameObject> slots = new List<GameObject>();
    public GameObject itemPrefab;
    public GameObject itemObject;

    
    void Awake()
    {
        if(instance != null)
          Destroy(this);
          instance = this;
    }
    private void OnEnable() 
    {
       // RefreshItem();
    }
    public void Update()
    {
        //RefreshItem();
    }
    public static void LoadGame()
    {
        instance.timeManage.GetComponent<TimeManage>().level = instance.playerData.worldIndex;

        for (int i = 0; i < instance.slots.Count; i++)
        {
            if(instance.slots[i].transform.childCount != 0)
            {
                Destroy(instance.slots[i].transform.GetChild(0).gameObject);
            }
            
        }

        for (int i = 0; i < instance.playerData.bagList.Count; i++)
        {
            if(instance.playerData.bagList[i] != null)
           {
                //Debug.Log("3484");
                instance.itemObject = Instantiate(instance.itemPrefab);
                instance.itemObject.transform.parent = instance.slots[i].transform;
                instance.itemObject.transform.position = instance.slots[i].transform.position;
                instance.itemObject.GetComponent<ItemOnDrag>().item = instance.playerData.bagList[i];
           } 
        }


        for (int i = 0; i < instance.equipmentGridList.Count; i++)
        {
             for (int j = 0; j < 9; j++)
             {
                if(instance.equipmentGridList[i].transform.GetChild(j).gameObject.transform.childCount != 0)
                {
                    Destroy(instance.equipmentGridList[i].transform.GetChild(j).gameObject.transform.GetChild(0).gameObject);
                }

             }
            
        }
         for (int i = 0; i < instance.equipmentGridList.Count; i++)
         {
             if(instance.playerData.saveList[i].playerClass != null)
             {
                 for (int j = 0; j < 9; j++)
                 {
                     if(instance.playerData.saveList[i].equipmentList[j] != null)
                     {
                         instance.itemObject = Instantiate(instance.itemPrefab);
                         instance.itemObject.transform.parent = instance.equipmentGridList[i].transform.GetChild(j).gameObject.transform;
                         instance.itemObject.transform.position = instance.equipmentGridList[i].transform.GetChild(j).gameObject.transform.position;
                         instance.itemObject.GetComponent<ItemOnDrag>().item = instance.playerData.saveList[i].equipmentList[j];

                     }
                 }
             }
         }
         
        for (int i = 0; i < instance.playerList.Count; i++)
        {
            instance.playerList[i].GetComponent<TeamPlayer>().playerClass = instance.playerData.saveList[i].playerClass;
            
            instance.playerList[i].GetComponent<TeamPlayer>().growthAd = instance.playerData.saveList[i].growthAd;
            instance.playerList[i].GetComponent<TeamPlayer>().growthAp = instance.playerData.saveList[i].growthAp;
            instance.playerList[i].GetComponent<TeamPlayer>().growthTotalhp = instance.playerData.saveList[i].growthTotalhp; 
            instance.playerList[i].GetComponent<TeamPlayer>().growthSpeed = instance.playerData.saveList[i].growthSpeed; 
            instance.playerList[i].GetComponent<TeamPlayer>().growthDef = instance.playerData.saveList[i].growthDef; 
            instance.playerList[i].GetComponent<TeamPlayer>().growthMdef = instance.playerData.saveList[i].growthMdef; 
            instance.playerList[i].GetComponent<TeamPlayer>().growthCritDamge = instance.playerData.saveList[i].growthCritDamge; 
            instance.playerList[i].GetComponent<TeamPlayer>().growthIq = instance.playerData.saveList[i].growthIq;
            instance.playerList[i].GetComponent<TeamPlayer>().growthCharm = instance.playerData.saveList[i].growthCharm; 

            instance.playerList[i].GetComponent<TeamPlayer>().point = instance.playerData.saveList[i].point;
            instance.playerList[i].GetComponent<TeamPlayer>().Cpoint = instance.playerData.saveList[i].Cpoint;
            instance.playerList[i].GetComponent<TeamPlayer>().Spoint = instance.playerData.saveList[i].Spoint;
            instance.playerList[i].GetComponent<TeamPlayer>().SSSpoint = instance.playerData.saveList[i].SSSpoint;

            instance.playerList[i].GetComponent<TeamPlayer>().bloodNum = instance.playerData.saveList[i].bloodNum;
            for (int j = 0; j < instance.playerList[i].GetComponent<TeamPlayer>().equipmentList.Count; j++)
            {
                instance.playerList[i].GetComponent<TeamPlayer>().equipmentList[j].item = instance.playerData.saveList[i].equipmentList[j]; 
            }
            
        }
        
      
    }
    public static void RefreshItem()
    {
        
       /* for (int i = 0; i < 18; i++)
        {
            if(instance.slotGrid.transform.childCount == 0)
            {
                break;
            }
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
            instance.slots.Clear();
        }
    
         for (int i = 0; i < instance.mybag.itemList.Count; i++)
       {
       
       
       instance.slots.Add(Instantiate(instance.emptySlot));
       instance.slots[i].transform.SetParent(instance.slotGrid.transform);
       instance.slots[i].GetComponent<Slot>().slotID = i;
       instance.slots[i].GetComponent<Slot>().SetupSlot(instance.mybag.itemList[i]);
       }*/
     /* for (int i = 0; i < 18; i++)
      {
          if(instance.slots[i].transform.childCount == 0)
          {
              instance.mybag.bagList[i] = null;
          }
          if(instance.slots[i].transform.childCount != 0)
          {
              instance.mybag.bagList[i] = instance.slots[i].transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item;
          }
      }*/
       

    }
}

