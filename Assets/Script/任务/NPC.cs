using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    [Header("npc预设")]
    public Player_Class npc;
    [Header("npc交谈模组")]
    public GameObject npcTalk;
    [Header("npc任务模组")]
    public GameObject player;
    public bool mission;
    public int missionIndex;

    [Header("npc战斗模组")]
    public GameObject battleManage;
    public List<GameObject> enemyList = new List<GameObject>();//
    public List<GameObject> npcList = new List<GameObject>();//世界npc列表
    public GameObject itemObject;//战利品
    [Header("npc交互模组")]
    public List<Item> NpcFavouriteItem = new List<Item>();
    public List<Item> NpcInteractionItem = new List<Item>();

    

    
   
    public  void OnEnable() 
    {
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
        //NpcFavouriteItem = npc.npcFavouriteItem;
        //NpcInteractionItem = npc.npcInteractionItem;
        //enemyClass = gameObject.GetComponent<NPCBattle>().enemyClass;
        npcTalk = GameObject.Find("UI").transform.GetChild(8).gameObject;
        player = GameObject.Find("Player");
        battleManage = GameObject.Find("UI").transform.GetChild(6).gameObject;

        missionIndex = Random.Range(0 , npc.npcMissionTalk.Count);
        
        
    }
    private void OnTriggerEnter2D(Collider2D other) 
   {
       if(other.gameObject.CompareTag("Player"))//碰撞检测
       {
           
           npcTalk.GetComponent<NPCTalk>().npc = npc;
           npcTalk.GetComponent<NPCTalk>().npcObject = gameObject;

           npcTalk.SetActive(true);

          battleManage.GetComponent<BattleManage>().enemyList = enemyList;
          battleManage.GetComponent<BattleManage>().enemyObject = gameObject;
          battleManage.GetComponent<BattleManage>().npcObject = npcList;
       }
    
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
       if(other.gameObject.CompareTag("Player"))//碰撞检测
       {
           npcTalk.SetActive(false);
       }
    
    }
    
   

}
