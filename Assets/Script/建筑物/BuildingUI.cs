using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BuildingUI : MonoBehaviour
{
    [Header("player队伍")]
    public GameObject teamManager;

    [Header("npc列表")]
    public List<Player_Class> npcList = new List<Player_Class>();
    public GameObject npcManager;
    [Header("‘拜访’按钮")]
    public GameObject firstManager;
    [Header("‘搜寻’按钮")]
    public GameObject itemManager;
    public Text itemManagerText;
    

     [Header("building持有物品模组")]
     public List<Item> buildingPrefabItemList1 = new List<Item>();
     public List<Item> buildingPrefabItemList2 = new List<Item>();
     public List<Item> buildingPrefabItemList3 = new List<Item>();
     public List<Item> buildingItemList1 = new List<Item>();
     public List<Item> buildingItemList2 = new List<Item>();
     public List<Item> buildingItemList = new List<Item>();

     public void Start()
     {
         BuildingItem();

     }

    public void BuildingItem()
    {
        buildingItemList1.Clear();
        for(int i = 0; i < buildingPrefabItemList1.Count; i++)
        {
             buildingItemList1.Add(buildingPrefabItemList1[i]);
        }
        buildingItemList2.Clear();
        for(int i = 0; i < buildingPrefabItemList2.Count; i++)
        {
            buildingItemList2.Add(buildingPrefabItemList2[i]);
        }

        for(int i = 0; i < 7; i++)
         {
             int randomIndex = Random.Range(0,buildingItemList1.Count);
             buildingItemList.Add(buildingItemList1[randomIndex]);
             buildingItemList1.Remove(buildingItemList1[randomIndex]);
         }
          for(int i = 0; i < 3; i++)
         {
             int randomIndex = Random.Range(0,buildingItemList2.Count);
             buildingItemList.Add(buildingItemList2[randomIndex]);
             buildingItemList2.Remove(buildingItemList2[randomIndex]);
         }
         for(int i = 0; i < buildingPrefabItemList3.Count; i++)
         {
             buildingItemList.Add(buildingPrefabItemList3[i]);
         }
    }

    public void VisitButton()
    {
        firstManager.SetActive(false);
        npcManager.SetActive(true);
    }
    public void SearchButton()
    {
        if(teamManager.GetComponent<TeamManage>().strength >= teamManager.GetComponent<TeamManage>().searchStrength)
        {
            teamManager.GetComponent<TeamManage>().strength -= teamManager.GetComponent<TeamManage>().searchStrength;
            itemManager.SetActive(true);
            itemManager.GetComponent<NPCItem>().getItemTime = 1;
            itemManagerText.text = "你找到了以下物品,你可以选择带走1样";  
            for (int i = 0; i < buildingItemList.Count; i++)
             {
                itemManager.GetComponent<NPCItem>().npcItemList.Add(buildingItemList[i]);
             }

        }

    }

}
