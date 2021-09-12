using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Player", menuName = "Player/New Player")]
public class Player_Class : ScriptableObject
{
     [Header("玩家配置属性")]
    public string playerName;
    public Sprite playerImage;
    public Sprite playerPicture;

     [Header("装备列表")]
    public List<Item> equipmentList = new List<Item>();
    
     [Header("玩家信息和故事")]
    [TextArea]
     public string playerInformation, playerStory;//信息
     [Header("是否NPC")]
     public bool NPC;
      [Header("npc问好语句")]
     public List<string> npcTalk = new List<string>();
      [Header("npc任务")]
     public List<Mission> npcMission = new List<Mission>();
     [Header("npc任务简介")]
     public List<string> npcMissionInfo = new List<string>();
      [Header("npc任务文本")]
     public List<TextAsset> npcMissionTalk = new List<TextAsset>();
     //[Header("npc任务需求(可以空白)")]
     //public List<Item> npcMissionNeed = new List<Item>();
      //[Header("npc任务奖励(可以空白)")]
     //public List<Item> npcMissionItem = new List<Item>();
     //[Header("npc交谈语句")]
     //public List<string> npcChat = new List<string>();
      [Header("npc拒绝语句")]
     public List<string> npcRefuse = new List<string>();
      [Header("npc感谢语句")]
     public List<string> npcThank = new List<string>();
      [Header("npc无任务语句")]
     public List<string> npcNullMission = new List<string>();
      [Header("npc任务满了语句")]
     public List<string> npcMaxMission = new List<string>();
     [Header("npc魅力不够语句")]
     public List<string> npcNullCharm = new List<string>();
     //[Header("npc交互文本")]
     //public List<TextAsset> npcInteraction = new List<TextAsset>();
     [Header("npc战斗语句")]
     public List<string> npcBattleTalk = new List<string>();

     
     //[Header("npc特征列表")]
     //public List<string> npcFeature = new List<string>();
     [Header("npc喜爱列表(可以空白)")]
     public List<Item> npcFavouriteItem = new List<Item>();
     [Header("npc死亡掉落(可以空白)")]
     public List<Item> npcDeathItem = new List<Item>();
     [Header("npc交互文本")]
     public List<TextAsset> npcInteraction = new List<TextAsset>();
     [Header("npc交互拒绝语句")]
     public List<string> npcRefuseInteraction = new List<string>();
     [Header("npc交互列表(可以空白)")]
     public List<Item> npcInteractionItem = new List<Item>();


     
     
    
    [Header("基础属性")]

    public float totalhp,replyHp;//血量与最大血量
    public float totalmp,replyMp;//魔量与最大魔量
    
    public float totalsp,replySp;//体力
    public float ad;//物攻
    public float ap;//法强
    public float def;//物防
    public float mdef;//魔防
    public float speed;//速度
    public float dodge;//闪避
    public float crit;//暴击率
    public float iq;//脑力
    public float charm;//魅力
    public float critDamge;//暴伤
    public float drainLife;//吸血
    public float skillOdds;
    public float exp;//经验
    public int level;//等级

    public float totalhpPCT;
    public float totalmpPCT;
    public float totalspPCT;
    public float spPCT;
    public float adPCT;
    public float apPCT;
    public float defPCT;
    public float mdefPCT;
    public float speedPCT;
    //public float dodgePCT;
    //public float critPCT;
    public float iqPCT;
    public float charmPCT;
    //public float critDamgePCT;
    //public float drainLifePCT;
    public float replyHpPCT;
    public float replyMpPCT;
    public float replySpPCT;
   
    public int sword;
    public int gun;


 


    
   
}
