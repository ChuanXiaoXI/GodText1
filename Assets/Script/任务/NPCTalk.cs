using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class NPCTalk : MonoBehaviour
{
    [Header("npc属性")]
    public Player_Class npc;
    public GameObject npcObject;
    public Image npcImage;
    public Text npcName;
   
    [Header("npcUI组件")]
    public Text npcTalk;
    public Text npcMission;
    public Text npcChat;
    public Text npcInteractionSelectText;
    public Text npcItemText;
    public GameObject npcTalkObject;
    public GameObject npcMissionObject;
    public GameObject npcChatObject;
    public GameObject npcInteractionSelect;
    public GameObject npcInteractionObject;
    public GameObject npcDefeatSence;
    //public GameObject npcMissionInfo;
    [Header("npc任务组件")]
    public List<GameObject> missionList = new List<GameObject>();
    public Mission mission;
    [Header("玩家队伍")]
    public GameObject teamManager;
    public List<GameObject> playerList = new List<GameObject>();
    public float[] playerCharm;
    [Header("交互机制")]
    //public List<GameObject> interactionList = new List<GameObject>();
    //public List<TextAsset> npcInteraction = new List<TextAsset>();
    public List<GameObject> bagList = new List<GameObject>();
    public int interactionIndex;
    public int bagIndex;
    public GameObject itemPrefab;
    public GameObject itemObject;
    public bool interaction;
    
    public GameObject npcItem;

     public GameObject battleManage;
     public bool battle;

    public void OnEnable()
    {
        battle = false;
        npcTalk.text = null;
        npcMission.text = null;
        npcChat.text = null;
        npcInteractionSelectText.text = null;
        //battleManage = GameObject.Find("UI").transform.GetChild(6).gameObject;
        npcTalkObject.SetActive(true);
        npcMissionObject.SetActive(false);
        npcChatObject.SetActive(false);
        npcInteractionObject.SetActive(false);
        npcInteractionSelect.SetActive(false);
        npcDefeatSence.SetActive(false);
        npcName.text = npc.playerName;
        npcImage.sprite = npc.playerImage;
        npcHello();
        if(npc.npcMission[npcObject.GetComponent<NPC>().missionIndex] != null)
        {                
        mission = npc.npcMission[npcObject.GetComponent<NPC>().missionIndex];
        }

        //MissionFinish();
    }
    public void Start()
    {
        teamManager = GameObject.Find("Team");
    }
    public void npcHello()
    {
        
        int index = Random.Range(0 , npc.npcTalk.Count);
        npcTalk.text = npc.npcTalk[index];//随机问好语句
       
       
    }
    
    public void ChatButton()
    {
        if(npcObject.GetComponent<NPC>().mission)
        { 
        float playerMaxCharm;
        //float enemyMaxSpeed;    
        for (int i = 0; i < playerList.Count; i++)
        {
            if(playerList[i] != null)
            {
            playerCharm[i] = playerList[i].GetComponent<TeamPlayer>().charm;
            
            }
            if(playerList[i] == null)
            {
            playerCharm[i] = 0;
            }
            
        }
        playerMaxCharm = Mathf.Max(playerCharm);
        if(playerMaxCharm >= npcObject.GetComponent<EnemyUI>().charm)
        {
        npcMissionObject.GetComponent<NPCChatButton>().npc = npcObject;
        npcMissionObject.GetComponent<NPCChatButton>().textFile = npc.npcMissionTalk[npcObject.GetComponent<NPC>().missionIndex];
        npcTalkObject.SetActive(false);
        npcMissionObject.SetActive(true);
        npcChatObject.SetActive(false);
        npcInteractionObject.SetActive(false);
        npcInteractionSelect.SetActive(false);
        }
        if(playerMaxCharm < npcObject.GetComponent<EnemyUI>().charm)
        {
          int chatIndex = Random.Range(0 , npc.npcNullCharm.Count);  
          npcMissionObject.GetComponent<NPCChatButton>().npc = npcObject;
          npcChat.text = npc.npcNullCharm[chatIndex];
          npcTalkObject.SetActive(false);
          npcMissionObject.SetActive(false);
          npcChatObject.SetActive(true);
          npcInteractionObject.SetActive(false);
          npcInteractionSelect.SetActive(false);
        }
        }
        if(!npcObject.GetComponent<NPC>().mission)
        {
            int npcNullMissionIndex = Random.Range(0 , npc.npcNullMission.Count);
            npcChat.text = npc.npcNullMission[npcNullMissionIndex];
            npcMissionObject.GetComponent<NPCChatButton>().npc = npcObject;
            npcTalkObject.SetActive(false);
            npcMissionObject.SetActive(false);
            npcChatObject.SetActive(true);
            npcInteractionObject.SetActive(false);
            npcInteractionSelect.SetActive(false);

        }
    }
    public void AcceptButton()
    {
        if(teamManager.GetComponent<TeamManage>().strength >= 2)
        {
        if(npcObject.GetComponent<NPC>().mission)
        {
           if(npc.npcMission[npcObject.GetComponent<NPC>().missionIndex] != null) 
           {           
             for (int i = 0; i < missionList.Count; i++)
            {
            if(missionList[i].GetComponent<PlayerMission>().mission == null)
            {
                int thankIndex = Random.Range(0 , npc.npcThank.Count);
                missionList[i].SetActive(true);
                missionList[i].GetComponent<PlayerMission>().mission = mission;
                npcObject.GetComponent<NPC>().mission = false;
                npcChat.text = npc.npcThank[thankIndex];
                teamManager.GetComponent<TeamManage>().strength -= teamManager.GetComponent<TeamManage>().socialStrength;
                npcTalkObject.SetActive(false);
                npcMissionObject.SetActive(false);
                npcChatObject.SetActive(true);
                npcInteractionObject.SetActive(false);
                npcInteractionSelect.SetActive(false);
                break;
            }
            }
        if(missionList[0].GetComponent<PlayerMission>().mission != null && missionList[1].GetComponent<PlayerMission>().mission != null && missionList[2].GetComponent<PlayerMission>().mission != null && missionList[3].GetComponent<PlayerMission>().mission != null && missionList[4].GetComponent<PlayerMission>().mission != null && missionList[5].GetComponent<PlayerMission>().mission != null)
        {
                int npcNullMissionIndex = Random.Range(0 , npc.npcNullMission.Count);
                npcChat.text = npc.npcNullMission[npcNullMissionIndex];
                npcTalkObject.SetActive(false);
                npcMissionObject.SetActive(false);
                npcChatObject.SetActive(true);
                npcInteractionObject.SetActive(false);
                npcInteractionSelect.SetActive(false);
        } 

            }
            if(npc.npcMission[npcObject.GetComponent<NPC>().missionIndex] == null)
            {
                int thankIndex = Random.Range(0 , npc.npcThank.Count);
                npcChat.text = npc.npcThank[thankIndex];
                npcTalkObject.SetActive(false);
                npcMissionObject.SetActive(false);
                npcChatObject.SetActive(true);
                npcInteractionObject.SetActive(false);
                npcInteractionSelect.SetActive(false);

            } 
        }
    }
    }

    
    public void RefuseButton()
    {
                int npcRefuseIndex = Random.Range(0 , npc.npcRefuse.Count);
                npcChat.text = npc.npcRefuse[npcRefuseIndex];
                npcTalkObject.SetActive(false);
                npcMissionObject.SetActive(false);
                npcChatObject.SetActive(true);
                npcInteractionObject.SetActive(false);
                npcInteractionSelect.SetActive(false);

    }
  public void BattleButton()
  {
      if(teamManager.GetComponent<TeamManage>().strength >= teamManager.GetComponent<TeamManage>().battleStrength)
      {
        teamManager.GetComponent<TeamManage>().strength -= teamManager.GetComponent<TeamManage>().battleStrength;        
        int npcBattleTalkIndex = Random.Range(0 , npc.npcBattleTalk.Count);
        npcChat.text = npc.npcBattleTalk[npcBattleTalkIndex];
        npcTalkObject.SetActive(false);
        npcMissionObject.SetActive(false);
        npcChatObject.SetActive(true);
        npcInteractionObject.SetActive(false);
        npcInteractionSelect.SetActive(false);
        battle = true;
      }
    //Destroy(npcObject);
    //battleManage.SetActive(true);
    //gameObject.SetActive(false);
  }
  public void IsOKButton()
  {
      if(battle)
      {
          battleManage.SetActive(true);
          gameObject.SetActive(false);
      }
      if(!battle)
      {
          gameObject.SetActive(false);
      }
      
  }
  public void InteractionButton()
{
    
    for(int i = 0; i < bagList.Count; i++)
    {
        if(bagList[i].transform.childCount != 0)
        {
        for(int j = 0; j < npcObject.GetComponent<NPC>().NpcFavouriteItem.Count; j++)
        {
           
            if(bagList[i].transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item != npcObject.GetComponent<NPC>().NpcFavouriteItem[j])
            {
                //Debug.Log("00"+ i);
               // Debug.Log("11" + j);
                npcChat.text = "背包里没有可交互的物品，对方并不想搭理你";
                interaction = false;
                npcTalkObject.SetActive(false);
                npcMissionObject.SetActive(false);
                npcChatObject.SetActive(true);
                npcInteractionObject.SetActive(false);
                npcInteractionSelect.SetActive(false);
               
                //continue;
                
            }
           // else
            
                
            
             if(bagList[i].transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item == npcObject.GetComponent<NPC>().NpcFavouriteItem[j])
            {
                //Debug.Log("22"+ i);
                //Debug.Log("33" + j);
                interactionIndex = j;
                bagIndex = i;
                npcInteractionSelectText.text = "对方想要你背包里的" + "“" + npcObject.GetComponent<NPC>().NpcFavouriteItem[j].itemName + "”" + "是否要给与对方";
                interaction = true;
                npcTalkObject.SetActive(false);
                npcMissionObject.SetActive(false);
                npcChatObject.SetActive(false);
                npcInteractionObject.SetActive(false);
                npcInteractionSelect.SetActive(true);       
                return;
                
                
            }    //break;      
        }//break;

        }
    }

    /*if(interaction == true)
    {
         npcTalkObject.SetActive(false);
                npcMissionObject.SetActive(false);
                npcChatObject.SetActive(false);
                npcInteractionObject.SetActive(false);
                npcInteractionSelect.SetActive(true);

    }
    if(interaction == false)
    {
        npcTalkObject.SetActive(false);
                npcMissionObject.SetActive(false);
                npcChatObject.SetActive(true);
                npcInteractionObject.SetActive(false);
                npcInteractionSelect.SetActive(false);

    }*/
    
    
}
public void ItemInteractionAccept()
{
    if(teamManager.GetComponent<TeamManage>().strength >= teamManager.GetComponent<TeamManage>().socialStrength)
    {
                npcInteractionObject.GetComponent<NPCInteraction>().textFile = npc.npcInteraction[interactionIndex];
                teamManager.GetComponent<TeamManage>().strength -= teamManager.GetComponent<TeamManage>().socialStrength;
                npcTalkObject.SetActive(false);
                npcMissionObject.SetActive(false);
                npcChatObject.SetActive(false);
                npcInteractionObject.SetActive(true);
                npcInteractionSelect.SetActive(false);
    }
    

}
public void ItemInteractionRefuse()
{
                int npcRefuseInteractionIndex = Random.Range(0 , npc.npcRefuseInteraction.Count);
                npcChat.text = npc.npcRefuseInteraction[npcRefuseInteractionIndex];
                npcTalkObject.SetActive(false);
                npcMissionObject.SetActive(false);
                npcChatObject.SetActive(true);
                npcInteractionObject.SetActive(false);
                npcInteractionSelect.SetActive(false);
    
}
  
 
public void MissionFinish()
{
    for (int i = 0; i < missionList.Count; i++)
    {
        if(missionList[i].GetComponent<PlayerMission>().gameObjectName != null)
        {
            if(missionList[i].GetComponent<PlayerMission>().gameObjectName == npc.playerName)
            {
                missionList[i].GetComponent<PlayerMission>().finish = true;
            }
        }
    }
}
 
  public void InteractionOKButton()
  {   
     if(npc.npcInteractionItem[interactionIndex] != null) 
     {
      itemObject = Instantiate(itemPrefab);
      bagList[bagIndex].transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().itemHeld -= 1;

     }
      gameObject.SetActive(false);

  }
  public void KillButton()
  {
      npcItem.SetActive(true);
      npcItem.GetComponent<NPCItem>().getItemTime = 2;
      npcDefeatSence.SetActive(false);
      npcItemText.text = "你杀了" + npc.playerName + ",你可以带走2样东西";   
      for (int i = 0; i < npcObject.GetComponent<NPC>().npcItemList.Count; i++)
      {
          npcItem.GetComponent<NPCItem>().npcItemList.Add(npcObject.GetComponent<NPC>().npcItemList[i]);
      }
      //npcItem.GetComponent<NPCItem>().npcItemList = npcObject.GetComponent<NPC>().npcItemList; 
      npcItem.GetComponent<NPCItem>().npcMarkObject = npcObject;      
      //Destroy(npcObject);
      gameObject.SetActive(false);

  }
  public void ForgiveButton()
  {
      npcItem.SetActive(true);
      npcItem.GetComponent<NPCItem>().getItemTime = 1;
      npcDefeatSence.SetActive(false);
      npcItemText.text = "你饶恕了" + npc.playerName + ",你可以带走1样东西";   
      for (int i = 0; i < npcObject.GetComponent<NPC>().npcItemList.Count; i++)
      {
          npcItem.GetComponent<NPCItem>().npcItemList.Add(npcObject.GetComponent<NPC>().npcItemList[i]);
      }
      //npcItem.GetComponent<NPCItem>().npcItemList = npcObject.GetComponent<NPC>().npcItemList; 
      npcItem.GetComponent<NPCItem>().npcMarkObject = npcObject;      
      //Destroy(npcObject);
      gameObject.SetActive(false);

  }

}
