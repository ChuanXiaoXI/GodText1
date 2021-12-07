using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    [Header("npc预设")]
    public Player_Class npc;
    public Text npcName;
    [Header("npc交谈模组")]
    public GameObject npcTalk;
    [Header("npc任务模组")]
    public GameObject player;
    public bool mission;
    public int missionIndex;

    [Header("npc战斗模组")]
    public GameObject battleManage;
    public List<GameObject> enemyList = new List<GameObject>();//
    //public List<GameObject> npcList = new List<GameObject>();//世界npc列表
    //public GameObject itemObject;//战利品
    [Header("npc交互模组")]
    public List<Item> NpcFavouriteItem = new List<Item>();
    public List<Item> NpcInteractionItem = new List<Item>();
       [Header("npc持有物品模组")]
     public List<Item> npcItemList1 = new List<Item>();
     public List<Item> npcItemList2 = new List<Item>();
     //public List<Item> npcItemList3 = new List<Item>();
     public List<Item> npcItemList = new List<Item>();

    

    public void Update()
    {
        if(npc != null)
        {
            npcName.text = npc.playerName;
        }
        if(npc == null)
        {
           gameObject.SetActive(false);
        }
    }
   
    public void Start()
    {
         if(npc != null)
        {
            npcName.text = npc.playerName;
        }
        gameObject.GetComponent<EnemyUI>().playerClass = npc;//属性传值
       // NPCItem();
        npcTalk = GameObject.Find("UI").transform.GetChild(8).gameObject;
        player = GameObject.Find("Player");
        battleManage = GameObject.Find("UI").transform.GetChild(6).gameObject;

        missionIndex = Random.Range(0 , npc.npcMissionTalk.Count); 
    }
   
    public  void OnEnable() 
    {
       
       /* NpcFavouriteItem.Clear();
        NpcInteractionItem.Clear();
        for(int i = 0; i < npc.npcFavouriteItem.Count; i++)
        {
            NpcFavouriteItem.Add(npc.npcFavouriteItem[i]);
        }
         for(int i = 0; i <npc.npcInteractionItem.Count; i++)
        {
            NpcInteractionItem.Add(npc.npcInteractionItem[i]);
        }
        //NpcFavouriteItem = npc.npcFavouriteItem;
        //NpcInteractionItem = npc.npcInteractionItem;
        //enemyClass = gameObject.GetComponent<NPCBattle>().enemyClass;
        npcTalk = GameObject.Find("UI").transform.GetChild(8).gameObject;
        player = GameObject.Find("Player");
        battleManage = GameObject.Find("UI").transform.GetChild(6).gameObject;

        missionIndex = Random.Range(0 , npc.npcMissionTalk.Count);
        */
        
    }
    public void NPCItem()
    {
        npcItemList1.Clear();
        for(int i = 0; i < npc.npcItemList1.Count; i++)
        {
            npcItemList1.Add(npc.npcItemList1[i]);
        }
        npcItemList2.Clear();
        for(int i = 0; i < npc.npcItemList2.Count; i++)
        {
            npcItemList2.Add(npc.npcItemList2[i]);
        }
         for(int i = 0; i < 7; i++)
         {
             int randomIndex = Random.Range(0,npcItemList1.Count);
             npcItemList.Add(npcItemList1[randomIndex]);
             npcItemList1.Remove(npcItemList1[randomIndex]);
         }
          for(int i = 0; i < 3; i++)
         {
             int randomIndex = Random.Range(0,npcItemList2.Count);
             npcItemList.Add(npcItemList2[randomIndex]);
             npcItemList2.Remove(npcItemList2[randomIndex]);
         }
         for(int i = 0; i < npc.npcItemList3.Count; i++)
         {
             npcItemList.Add(npc.npcItemList3[i]);
         }

         NpcFavouriteItem.Clear();
         NpcInteractionItem.Clear();
         for(int i = 0; i < npc.npcFavouriteItem.Count; i++)
         {
            NpcFavouriteItem.Add(npc.npcFavouriteItem[i]);
         }
         for(int i = 0; i <npc.npcInteractionItem.Count; i++)
         {
            NpcInteractionItem.Add(npc.npcInteractionItem[i]);
         }
    }


    public void NPCButton()
   {      
          npcTalk.GetComponent<NPCTalk>().npc = npc;
          npcTalk.GetComponent<NPCTalk>().npcObject = gameObject;
          npcTalk.SetActive(true);
          battleManage.GetComponent<BattleManage>().enemyList = enemyList;
          battleManage.GetComponent<BattleManage>().enemyObject = gameObject;
          //battleManage.GetComponent<BattleManage>().npcObject = npcList;
       
    
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
           npcTalk.SetActive(false);
    }
    
   

}
