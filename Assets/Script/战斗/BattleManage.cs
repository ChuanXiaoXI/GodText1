using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class BattleManage : MonoBehaviour
{  
    [Header("战斗是否开始")]
    public bool fighting;

    [Header("player队伍设置")]
    public List<GameObject> playerPoints = new List<GameObject>();//player的点
    public List<GameObject> playerList = new List<GameObject>();//team列表
    public List<GameObject> playerBattleList = new List<GameObject>();
    //public GameObject teamManage;//队伍管理
    //public List<GameObject> playerPrefab;//playe预制体
    public List<GameObject> remainPlayerList = new List<GameObject>();
    [Header("enemy队伍设置")]
    public List<GameObject> enemyPoints = new List<GameObject>();//enemy的点
    //public GameObject enemyPrefab;//emeny预制体
    //public int enemyNum;//生成数量
    public  List<GameObject> enemyList = new List<GameObject>() ;
    public List<GameObject> remainEnemyList = new List<GameObject>();
    [Header("buff显示设置")]
    public GameObject buffPrefabObject;
    public GameObject buffObject;
   // public int enemyPoint;
    [Header("速度最大值判定")]
    public float maxSpeed;
    public float[] playerSpeed;   
    public float[] enemySpeed;
    [Header("战斗结束")]
    public int enemyPoint;
    public GameObject victory;

    public GameObject enemyObject;
    
    public GameObject npcManager;
    public GameObject npcDefeatSence;
    public Text npcDefeatText;
    public List<GameObject> npcTalkSence = new List<GameObject>();
    //public List<GameObject> npcObject = new List<GameObject>();

    //public GameObject itemPrefab;//战利品
    //public GameObject itemObject;
 
    // Start is called before the first frame update
    void Start()
    { 
     //SetUpUnits();
    }
    public void  OnEnable() 
    {   
        maxSpeed = 10000;
        SetUpUnits();
        StartSkill();
    }


    // Update is called once per frame
    public void Update()
    { 
        Victory();
        MaxSpeed();
        //Victory();
        //MaxSpeed();
       // Death();
        
    }
    public void SetUpUnits()
    {
        fighting = true;
        for (int i = 0; i < 8; i++)
        {
            if(playerList[i].GetComponent<TeamPlayer>().playerClass != null)
            {
              playerBattleList[i] = playerList[i].GetComponent<TeamPlayer>().playerBattlePrefab;
            }
        }
        for (int i = 0; i < 8; i++)
        {
            if(playerBattleList[i] != null)
            {
              Instantiate(playerBattleList[i]).transform.parent = playerPoints[i].transform;
              playerPoints[i].transform.GetChild(0).gameObject.GetComponent<PlayerBattle>().player = playerList[i].GetComponent<TeamPlayer>();
              playerPoints[i].transform.GetChild(0).gameObject.transform.position = playerPoints[i].transform.position;
              remainPlayerList.Add(playerPoints[i].transform.GetChild(0).gameObject);
            }
        }
        for (int i = 0; i < enemyList.Count; i++)
        {
            if(enemyList[i] != null)
            {
            Instantiate(enemyList[i]).transform.parent = enemyPoints[i].transform;
            //enemyPoints[i].transform.GetChild(0).gameObject.GetComponent<EnemyUI>().playerClass = enemyClass[i];
            enemyPoints[i].transform.GetChild(0).gameObject.transform.position = enemyPoints[i].transform.position;
            remainEnemyList.Add(enemyPoints[i].transform.GetChild(0).gameObject); 
            }
        }     
    }
    public void MaxSpeed()
    {
        float playerMaxSpeed;
        float enemyMaxSpeed; 
         
        for (int i = 0; i < remainPlayerList.Count; i++)
        { 
            if(remainPlayerList[i] != null)
            {
            playerSpeed[i] = remainPlayerList[i].GetComponent<PlayerBattle>().player.speed;
            remainPlayerList[i].GetComponent<PlayerBattle>().player.target = true;
            }
            if(remainPlayerList[i] == null)
            {
            playerSpeed[i] = 0;
            }
            
        }
        playerMaxSpeed = Mathf.Max(playerSpeed);
         
        //玩家速度最大值
        for (int i = 0; i < remainEnemyList.Count; i++)
        {
            if(remainEnemyList[i] != null)
            {
            enemySpeed[i] = remainEnemyList[i].GetComponent<EnemyUI>().speed;
            remainEnemyList[i].GetComponent<EnemyUI>().target = true;
            }
            if(remainEnemyList[i] == null)
            {
            enemySpeed[i] = 0;
            } 
        }
        enemyMaxSpeed = Mathf.Max(enemySpeed);
        //enemy速度最大值
        if(playerMaxSpeed >= enemyMaxSpeed)
        {
            maxSpeed = playerMaxSpeed;
        }
        if(playerMaxSpeed < enemyMaxSpeed)
        {
            maxSpeed = enemyMaxSpeed;
        }
        //获得速度最大值
        for (int i = 0; i < remainPlayerList.Count; i++)
        {
            if(remainPlayerList[i] != null)
            {
                remainPlayerList[i].GetComponent<PlayerBattle>().player.maxSpeed = maxSpeed;
            }
            if(remainEnemyList[i] != null)
            {
                remainEnemyList[i].GetComponent<EnemyUI>().maxSpeed = maxSpeed;
            }
        }

    }
   public void StartSkill()//领域技能
{

    for (int i = 0; i < remainPlayerList.Count; i++)
    {   
        for (int j = 0; j < remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList.Count; j++)
       {
         if (remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[j] != null)
         {
             if(remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[j].startSkill && remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[j].teamBuff)//团队buff
             {
                 for (int k = 0; k < remainPlayerList.Count; k++)
                {                
                    if(remainPlayerList[k].GetComponent<PlayerBattle>().player.buffAndDebuffList.Contains(remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[j].buff))
                    {
                        for (int l = 0; l < remainPlayerList[k].GetComponent<PlayerBattle>().player.buffAndDebuffList.Count; l++)
                        {
                            if(remainPlayerList[k].GetComponent<PlayerBattle>().player.buffAndDebuffList[l] == remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[j].buff)
                            {
                                //Debug.Log("111");
                                if(remainPlayerList[k].GetComponent<PlayerBattle>().player.buffObjectList[l].GetComponent<PlayerBattle>().player.iq >= remainPlayerList[i].GetComponent<PlayerBattle>().player.iq)
                                {
                                    continue;
                                }
                                if(remainPlayerList[k].GetComponent<PlayerBattle>().player.buffObjectList[l].GetComponent<PlayerBattle>().player.iq < remainPlayerList[i].GetComponent<PlayerBattle>().player.iq)
                                {
                                    remainPlayerList[k].GetComponent<PlayerBattle>().player.buffTime[l] = remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[j].buff.buffTime;
                                    remainPlayerList[k].GetComponent<PlayerBattle>().player.buffObjectList[l] = remainPlayerList[i];
                                    remainPlayerList[k].GetComponent<PlayerBattle>().player.buffAndDebuffList[l] = remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[j].buff;
                                    break;
                                }
                            }
                        }
                    }
                    if(!remainPlayerList[k].GetComponent<PlayerBattle>().player.buffAndDebuffList.Contains(remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[j].buff))
                    {
                     for (int l = 0; l < remainPlayerList[k].GetComponent<PlayerBattle>().player.buffAndDebuffList.Count; l++)
                     {
                         if(remainPlayerList[k].GetComponent<PlayerBattle>().player.buffAndDebuffList[l] == null)
                       {
                         remainPlayerList[k].GetComponent<PlayerBattle>().player.buffTime[l] = remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[j].buff.buffTime;
                         remainPlayerList[k].GetComponent<PlayerBattle>().player.buffObjectList[l] = remainPlayerList[i];
                         remainPlayerList[k].GetComponent<PlayerBattle>().player.buffAndDebuffList[l] = remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[j].buff;
                         
                        //Debug.Log("111");
                              remainPlayerList[k].transform.GetChild(8).gameObject.GetComponent<EnemyBuffManager>().buffList.Add(remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[j].buff);   
                              buffObject = Instantiate(buffPrefabObject);
                              buffObject.transform.parent = remainPlayerList[k].transform.GetChild(8).gameObject.transform;                              
                              buffObject.GetComponent<Buff>().buffHeld = 1;
                              buffObject.GetComponent<Buff>().buff = remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[j].buff;
                              
                               remainPlayerList[k].GetComponent<PlayerBattle>().player.buffInfoIsAlive = true;
                              remainPlayerList[k].GetComponent<PlayerBattle>().player.buffInfo = remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[j].buff.buffString;
                              
                              //buff显示                                                                                                                                     
                         break;
                       }
                         
                     }
                    }
                    
                 
                }
                

             }
             if(remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[j].startSkill && remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[j].teamDebuff && !remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[j].dizzy)//团队debuff
             {
                 for (int k = 0; k < remainEnemyList.Count ; k++)
                 {

                      if(remainEnemyList[k].GetComponent<EnemyUI>().buffAndDebuffList.Contains(remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[j].buff))
                    {
                        for (int l = 0; l < remainEnemyList[k].GetComponent<EnemyUI>().buffAndDebuffList.Count; l++)
                        {
                            if(remainEnemyList[k].GetComponent<EnemyUI>().buffAndDebuffList[l] == remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[j].buff)
                            {
                                if(remainEnemyList[k].GetComponent<EnemyUI>().buffObjectList[l].GetComponent<PlayerBattle>().player.iq >= remainPlayerList[i].GetComponent<PlayerBattle>().player.iq)
                                {
                                    continue;
                                }
                                if(remainEnemyList[k].GetComponent<EnemyUI>().buffObjectList[l].GetComponent<PlayerBattle>().player.iq < remainPlayerList[i].GetComponent<PlayerBattle>().player.iq)
                                {
                                    remainEnemyList[k].GetComponent<EnemyUI>().buffTime[l] = remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[j].buff.buffTime;
                                    remainEnemyList[k].GetComponent<EnemyUI>().buffObjectList[l] = remainPlayerList[i];
                                    remainEnemyList[k].GetComponent<EnemyUI>().buffAndDebuffList[l] = remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[j].buff;

                                     remainEnemyList[k].transform.GetChild(5).gameObject.GetComponent<EnemyBuffManager>().buffList.Add(remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[j].buff);   
                                     buffObject = Instantiate(buffPrefabObject);
                                     buffObject.transform.parent = remainEnemyList[k].transform.GetChild(5).gameObject.transform;                              
                                     buffObject.GetComponent<Buff>().buffHeld = 1;
                                     buffObject.GetComponent<Buff>().buff = remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[j].buff;
                               
                               
                               remainEnemyList[k].GetComponent<EnemyUI>().buffInfoIsAlive = true;
                               remainEnemyList[k].GetComponent<EnemyUI>().buffInfo = remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[j].buff.buffString;
                              
                              //buff显示

                                    break;

                                }
                            }
                        }

                    }
                    if(!remainEnemyList[k].GetComponent<EnemyUI>().buffAndDebuffList.Contains(remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[j].buff))
                    {
                        for (int l = 0; l < remainEnemyList[k].GetComponent<EnemyUI>().buffAndDebuffList.Count; l++)
                        {
                         
                             if(remainEnemyList[k].GetComponent<EnemyUI>().buffAndDebuffList[l] == null)
                             {
                             remainEnemyList[k].GetComponent<EnemyUI>().buffTime[l] = remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[j].buff.buffTime;
                             remainEnemyList[k].GetComponent<EnemyUI>().buffObjectList[l] = remainPlayerList[i];
                             remainEnemyList[k].GetComponent<EnemyUI>().buffAndDebuffList[l] = remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[j].buff;
                             
                             break;
                             }                       
                        }
                    }
                   
                 }
             }
              if(remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[j].startSkill && remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[j].teamDebuff && remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[j].dizzy)//团队眩晕
             {
                 for (int k = 0; k < remainEnemyList.Count ; k++)
                 {
                     if(remainPlayerList[i].GetComponent<PlayerBattle>().player.charm < remainEnemyList[k].GetComponent<EnemyUI>().charm)
                     {
                         continue;
                     }
                     if(remainPlayerList[i].GetComponent<PlayerBattle>().player.charm >= remainEnemyList[k].GetComponent<EnemyUI>().charm)
                     {
                         for (int l = 0; l < remainEnemyList[k].GetComponent<EnemyUI>().buffAndDebuffList.Count; l++)
                         {
                             remainEnemyList[k].GetComponent<EnemyUI>().buffTime[l] = remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[j].buff.buffTime;
                             remainEnemyList[k].GetComponent<EnemyUI>().buffObjectList [l] = remainPlayerList[i];
                             remainEnemyList[k].GetComponent<EnemyUI>().buffAndDebuffList[l] = remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[j].buff;

                              remainEnemyList[k].GetComponent<EnemyUI>().buffManage.GetComponent<EnemyBuffManager>().buffList.Add(remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[j].buff);   
                              buffObject = Instantiate(buffPrefabObject);
                              buffObject.transform.parent = remainEnemyList[k].GetComponent<EnemyUI>().buffManage.transform;                              
                              buffObject.GetComponent<Buff>().buffHeld = 1;
                              buffObject.GetComponent<Buff>().buff = remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[j].buff;
                              
                              
                              remainEnemyList[k].GetComponent<EnemyUI>().buffInfoIsAlive = true;
                               remainEnemyList[k].GetComponent<EnemyUI>().buffInfo = remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[j].buff.buffString;
                              //buff显示
                            
                             break;
                         }
                     }
                     
                 }
             }

              if(remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[j].startSkill && remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[j].teamDamage)//团队伤害
            { 
                if(remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[j].adSkill)
                {
                     for (int k = 0; k < remainEnemyList.Count ; k++)
                     {
                       remainEnemyList[k].GetComponent<EnemyUI>().hp -= ((remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[j].adSkillFactor * remainPlayerList[i].GetComponent<PlayerBattle>().player.ad) - (remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[j].adSkillFactor * remainEnemyList[k].GetComponent<EnemyUI>().def));
                       remainEnemyList[k].GetComponent<EnemyUI>().targetUnit = remainPlayerList[i].GetComponent<PlayerBattle>().player.gameObject;
                       for (int n = 0; n < remainPlayerList[i].GetComponent<PlayerBattle>().player.damageList.Count; n++)
                            { 
                            if(remainPlayerList[i].GetComponent<PlayerBattle>().player.damageList[n] == 0)
                           {
                               remainPlayerList[i].GetComponent<PlayerBattle>().player.damageList[n] = ((remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[j].adSkillFactor * remainPlayerList[i].GetComponent<PlayerBattle>().player.ad) - (remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[j].adSkillFactor * remainEnemyList[k].GetComponent<EnemyUI>().def));
                               remainEnemyList[k].GetComponent<EnemyUI>().damageNumObjectIsAlive = true;//伤害数值显示
                               remainEnemyList[k].GetComponent<EnemyUI>().damageNumber = remainPlayerList[i].GetComponent<PlayerBattle>().player.damageList[n];
                               break;
                           }
                            }
                       
                     }
                }
                if(remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[j].hpSkill)
                {
                     for (int k = 0; k < remainEnemyList.Count ; k++)
                     {
                       remainEnemyList[k].GetComponent<EnemyUI>().hp -= ((remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[j].hpSkillFactor * remainPlayerList[i].GetComponent<PlayerBattle>().player.totalhp) - (remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[j].hpSkillFactor * remainEnemyList[k].GetComponent<EnemyUI>().def));
                       remainEnemyList[k].GetComponent<EnemyUI>().targetUnit = remainPlayerList[i].GetComponent<PlayerBattle>().player.gameObject;
                        for (int n = 0; n < remainPlayerList[i].GetComponent<PlayerBattle>().player.damageList.Count; n++)
                            { 
                            if(remainPlayerList[i].GetComponent<PlayerBattle>().player.damageList[n] == 0)
                           {
                               remainPlayerList[i].GetComponent<PlayerBattle>().player.damageList[n] = ((remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[j].hpSkillFactor * remainPlayerList[i].GetComponent<PlayerBattle>().player.totalhp) - (remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[j].hpSkillFactor * remainEnemyList[k].GetComponent<EnemyUI>().def));
                               remainEnemyList[k].GetComponent<EnemyUI>().damageNumObjectIsAlive = true;//伤害数值显示
                               remainEnemyList[k].GetComponent<EnemyUI>().damageNumber = remainPlayerList[i].GetComponent<PlayerBattle>().player.damageList[n];
                               break;
                           }
                            }
                       
                     }
                }
                if(remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[j].apSkill)
                {
                    for (int k = 0; k < remainEnemyList.Count ; k++)
                     {
                       remainEnemyList[k].GetComponent<EnemyUI>().hp -= ((remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[j].apSkillFactor * remainPlayerList[i].GetComponent<PlayerBattle>().player.ap) - (remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[j].apSkillFactor * remainEnemyList[k].GetComponent<EnemyUI>().mdef));
                       remainEnemyList[k].GetComponent<EnemyUI>().targetUnit = remainPlayerList[i].GetComponent<PlayerBattle>().player.gameObject;
                       for (int n = 0; n < remainPlayerList[i].GetComponent<PlayerBattle>().player.damageList.Count; n++)
                            { 
                            if(remainPlayerList[i].GetComponent<PlayerBattle>().player.damageList[n] == 0)
                           {
                               remainPlayerList[i].GetComponent<PlayerBattle>().player.damageList[n] =((remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[j].apSkillFactor * remainPlayerList[i].GetComponent<PlayerBattle>().player.ap) - (remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[j].apSkillFactor * remainEnemyList[k].GetComponent<EnemyUI>().mdef));
                               remainEnemyList[k].GetComponent<EnemyUI>().damageNumObjectIsAlive = true;//伤害数值显示
                               remainEnemyList[k].GetComponent<EnemyUI>().damageNumber = remainPlayerList[i].GetComponent<PlayerBattle>().player.damageList[n];
                               break;
                           }
                            }
                       
                     }
                }
                if(remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[j].iqSkill)
                {
                    for (int k = 0; k < remainEnemyList.Count ; k++)
                     {
                       remainEnemyList[k].GetComponent<EnemyUI>().hp -= ((remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[j].iqSkillFactor * remainPlayerList[i].GetComponent<PlayerBattle>().player.iq) - (remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[j].iqSkillFactor * remainEnemyList[k].GetComponent<EnemyUI>().mdef));
                       remainEnemyList[k].GetComponent<EnemyUI>().targetUnit = remainPlayerList[i].GetComponent<PlayerBattle>().player.gameObject;
                       for (int n = 0; n < remainPlayerList[i].GetComponent<PlayerBattle>().player.damageList.Count; n++)
                            { 
                            if(remainPlayerList[i].GetComponent<PlayerBattle>().player.damageList[n] == 0)
                           {
                               remainPlayerList[i].GetComponent<PlayerBattle>().player.damageList[n] =((remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[j].iqSkillFactor * remainPlayerList[i].GetComponent<PlayerBattle>().player.iq) - (remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[j].iqSkillFactor * remainEnemyList[k].GetComponent<EnemyUI>().mdef));
                               remainEnemyList[k].GetComponent<EnemyUI>().damageNumObjectIsAlive = true;//伤害数值显示
                               remainEnemyList[k].GetComponent<EnemyUI>().damageNumber = remainPlayerList[i].GetComponent<PlayerBattle>().player.damageList[n];
                               break;
                           }
                            }
                       
                     }
                }
            }
         }
       }
    }

 //enemy
 for (int i = 0; i < remainEnemyList.Count; i++)
    {   for (int j = 0; j < remainEnemyList[i].GetComponent<EnemyUI>().skillList.Count; j++)
       {
         if (remainEnemyList[i].GetComponent<EnemyUI>().skillList[j] != null)
         {
             if(remainEnemyList[i].GetComponent<EnemyUI>().skillList[j].startSkill && remainEnemyList[i].GetComponent<EnemyUI>().skillList[j].teamBuff)//团队buff
             {
                 for (int k = 0; k < remainEnemyList.Count; k++)
                 {
                    
                     if(remainEnemyList[k].GetComponent<EnemyUI>().buffAndDebuffList.Contains(remainEnemyList[k].GetComponent<EnemyUI>().skillList[j].buff))
                     {
                         for (int l = 0; l < remainEnemyList[k].GetComponent<EnemyUI>().buffAndDebuffList.Count; l++)
                        {
                            if(remainEnemyList[k].GetComponent<EnemyUI>().buffAndDebuffList[l] == remainEnemyList[i].GetComponent<EnemyUI>().skillList[j].buff)
                            {
                                if(remainEnemyList[k].GetComponent<EnemyUI>().buffObjectList[l].GetComponent<EnemyUI>().iq >= remainEnemyList[i].GetComponent<EnemyUI>().iq)
                                {
                                    continue;
                                }
                                if(remainEnemyList[k].GetComponent<EnemyUI>().buffObjectList[l].GetComponent<EnemyUI>().iq < remainEnemyList[i].GetComponent<EnemyUI>().iq)
                                {
                                    remainEnemyList[k].GetComponent<EnemyUI>().buffTime[l] = remainEnemyList[i].GetComponent<EnemyUI>().skillList[j].buff.buffTime;
                                    remainEnemyList[k].GetComponent<EnemyUI>().buffObjectList[l] = remainEnemyList[i];
                                    remainEnemyList[k].GetComponent<EnemyUI>().buffAndDebuffList[l] = remainEnemyList[i].GetComponent<EnemyUI>().skillList[j].buff;
                                    break;

                                }
                            }
                        }

                     }
                      if(!remainEnemyList[k].GetComponent<EnemyUI>().buffAndDebuffList.Contains(remainEnemyList[k].GetComponent<EnemyUI>().skillList[j].buff))
                     {                
                     for (int l = 0; l < remainEnemyList[k].GetComponent<EnemyUI>().buffAndDebuffList.Count; l++)
                     {
                         if(remainEnemyList[k].GetComponent<EnemyUI>().buffAndDebuffList[l] == null)
                       {
                         remainEnemyList[k].GetComponent<EnemyUI>().buffTime[l] = remainEnemyList[i].GetComponent<EnemyUI>().skillList[j].buff.buffTime;
                         remainEnemyList[k].GetComponent<EnemyUI>().buffObjectList[l] = remainEnemyList[i];
                         remainEnemyList[k].GetComponent<EnemyUI>().buffAndDebuffList[l] = remainEnemyList[i].GetComponent<EnemyUI>().skillList[j].buff;

                              remainEnemyList[k].transform.GetChild(5).gameObject.GetComponent<EnemyBuffManager>().buffList.Add(remainEnemyList[i].GetComponent<EnemyUI>().skillList[j].buff);   
                              buffObject = Instantiate(buffPrefabObject);
                              buffObject.transform.parent = remainEnemyList[k].transform.GetChild(5).gameObject.transform;                              
                              buffObject.GetComponent<Buff>().buffHeld = 1;
                              buffObject.GetComponent<Buff>().buff = remainEnemyList[i].GetComponent<EnemyUI>().skillList[j].buff;
                              
                              
                              remainEnemyList[k].GetComponent<EnemyUI>().buffInfoIsAlive = true;
                               remainEnemyList[k].GetComponent<EnemyUI>().buffInfo = remainEnemyList[i].GetComponent<EnemyUI>().skillList[j].buff.buffString;
                              //buff显示
                         
                         break;
                       }
                     }
                     }
                     
                 }

             }
             if(remainEnemyList[i].GetComponent<EnemyUI>().skillList[j].startSkill && remainEnemyList[i].GetComponent<EnemyUI>().skillList[j].teamDebuff && !remainEnemyList[i].GetComponent<EnemyUI>().skillList[j].dizzy)//团队debuff
             {
                 for (int k = 0; k < remainPlayerList.Count ; k++)
                 {
                     if(remainPlayerList[k].GetComponent<PlayerBattle>().player.buffAndDebuffList.Contains(remainEnemyList[k].GetComponent<EnemyUI>().skillList[j].buff))
                     {
                         for (int l = 0; l < remainPlayerList[k].GetComponent<PlayerBattle>().player.buffAndDebuffList.Count; l++)
                        {
                            if(remainPlayerList[k].GetComponent<PlayerBattle>().player.buffAndDebuffList[l] == remainEnemyList[i].GetComponent<EnemyUI>().skillList[j].buff)
                            {
                                if(remainPlayerList[k].GetComponent<PlayerBattle>().player.buffObjectList[l].GetComponent<EnemyUI>().iq >= remainEnemyList[i].GetComponent<EnemyUI>().iq)
                                {
                                    continue;
                                }
                                if(remainPlayerList[k].GetComponent<PlayerBattle>().player.buffObjectList[l].GetComponent<EnemyUI>().iq < remainEnemyList[i].GetComponent<EnemyUI>().iq)
                                {
                                    remainPlayerList[k].GetComponent<PlayerBattle>().player.buffTime[l] = remainEnemyList[i].GetComponent<EnemyUI>().skillList[j].buff.buffTime;
                                    remainPlayerList[k].GetComponent<PlayerBattle>().player.buffObjectList[l] = remainEnemyList[i].GetComponent<EnemyUI>().ownObject;
                                    remainPlayerList[k].GetComponent<PlayerBattle>().player.buffAndDebuffList[l] = remainEnemyList[i].GetComponent<EnemyUI>().skillList[j].buff;
                                    break;

                                }
                            }
                        }
                     }
                      if(!remainPlayerList[k].GetComponent<PlayerBattle>().player.buffAndDebuffList.Contains(remainEnemyList[k].GetComponent<EnemyUI>().skillList[j].buff))
                     { 
                     for (int l = 0; l < remainPlayerList[k].GetComponent<PlayerBattle>().player.buffAndDebuffList.Count; l++)
                     {
                         if(remainPlayerList[k].GetComponent<PlayerBattle>().player.buffAndDebuffList[l] == null)
                         {
                             remainPlayerList[k].GetComponent<PlayerBattle>().player.buffTime[l] = remainEnemyList[i].GetComponent<EnemyUI>().skillList[j].buff.buffTime;
                             remainPlayerList[k].GetComponent<PlayerBattle>().player.buffObjectList[l] = remainEnemyList[i];
                             remainPlayerList[k].GetComponent<PlayerBattle>().player.buffAndDebuffList[l] = remainEnemyList[i].GetComponent<EnemyUI>().skillList[j].buff;
                             

                              remainPlayerList[k].transform.GetChild(8).gameObject.GetComponent<EnemyBuffManager>().buffList.Add(remainEnemyList[i].GetComponent<EnemyUI>().skillList[j].buff);   
                              buffObject = Instantiate(buffPrefabObject);
                              buffObject.transform.parent =  remainPlayerList[k].transform.GetChild(8).gameObject.transform;                              
                              buffObject.GetComponent<Buff>().buffHeld = 1;
                              buffObject.GetComponent<Buff>().buff = remainEnemyList[i].GetComponent<EnemyUI>().skillList[j].buff;
                              
                              
                               remainPlayerList[k].GetComponent<PlayerBattle>().player.buffInfoIsAlive = true;
                               remainPlayerList[k].GetComponent<PlayerBattle>().player.buffInfo = remainEnemyList[i].GetComponent<EnemyUI>().skillList[j].buff.buffString;
                              //buff显示
                             break;
                         }
                         
                     }
                     }
                     
                 }
             }
              if(remainEnemyList[i].GetComponent<EnemyUI>().skillList[j].startSkill && remainEnemyList[i].GetComponent<EnemyUI>().skillList[j].teamDebuff && remainEnemyList[i].GetComponent<EnemyUI>().skillList[j].dizzy)//团队眩晕
             {
                 for (int k = 0; k < remainPlayerList.Count ; k++)
                 {
                     if(remainPlayerList[k].GetComponent<PlayerBattle>().player.charm > remainEnemyList[i].GetComponent<EnemyUI>().charm)
                     {
                         continue;
                     }
                     if(remainPlayerList[k].GetComponent<PlayerBattle>().player.charm <= remainEnemyList[i].GetComponent<EnemyUI>().charm)
                     {
                         for (int l = 0; l < remainPlayerList[i].GetComponent<PlayerBattle>().player.buffAndDebuffList.Count; l++)
                         {
                             remainPlayerList[k].GetComponent<PlayerBattle>().player.buffTime[l] = remainEnemyList[i].GetComponent<EnemyUI>().skillList[j].buff.buffTime;
                             remainPlayerList[k].GetComponent<PlayerBattle>().player.buffObjectList[l] = remainEnemyList[i];
                             remainPlayerList[k].GetComponent<PlayerBattle>().player.buffAndDebuffList[l] = remainEnemyList[i].GetComponent<EnemyUI>().skillList[j].buff;
                            
                             remainPlayerList[k].GetComponent<PlayerBattle>().player.buffManage.GetComponent<EnemyBuffManager>().buffList.Add(remainEnemyList[i].GetComponent<EnemyUI>().skillList[j].buff);   
                              buffObject = Instantiate(buffPrefabObject);
                              buffObject.transform.parent = remainPlayerList[k].GetComponent<PlayerBattle>().player.buffManage.transform;                              
                              buffObject.GetComponent<Buff>().buffHeld = 1;
                              buffObject.GetComponent<Buff>().buff = remainEnemyList[i].GetComponent<EnemyUI>().skillList[j].buff;
                              
                              
                              remainPlayerList[k].GetComponent<PlayerBattle>().player.buffInfoIsAlive = true;
                               remainPlayerList[k].GetComponent<PlayerBattle>().player.buffInfo = remainEnemyList[i].GetComponent<EnemyUI>().skillList[j].buff.buffString;
                              //buff显示
                             break;
                         }
                     }
                     
                 }
             }

              if(remainEnemyList[i].GetComponent<EnemyUI>().skillList[j].startSkill && remainEnemyList[i].GetComponent<EnemyUI>().skillList[j].teamDamage)//团队伤害
            { 
                if(remainEnemyList[i].GetComponent<EnemyUI>().skillList[j].adSkill)
                {
                     for (int k = 0; k < remainPlayerList.Count ; k++)
                     {
                       remainPlayerList[k].GetComponent<PlayerBattle>().player.hp -= ((remainEnemyList[i].GetComponent<EnemyUI>().skillList[j].adSkillFactor * remainEnemyList[i].GetComponent<EnemyUI>().ad) - (remainEnemyList[i].GetComponent<EnemyUI>().skillList[j].adSkillFactor * remainPlayerList[k].GetComponent<PlayerBattle>().player.def));
                       remainPlayerList[k].GetComponent<PlayerBattle>().player.targetUnit = remainEnemyList[i];

                       for (int n = 0; n < remainEnemyList[i].GetComponent<EnemyUI>().damageList.Count; n++)
                            { 
                            if(remainEnemyList[i].GetComponent<EnemyUI>().damageList[n] == 0)
                           {
                               remainEnemyList[i].GetComponent<EnemyUI>().damageList[n] = ((remainEnemyList[i].GetComponent<EnemyUI>().skillList[j].adSkillFactor * remainEnemyList[i].GetComponent<EnemyUI>().ad) - (remainEnemyList[i].GetComponent<EnemyUI>().skillList[j].adSkillFactor * remainPlayerList[k].GetComponent<PlayerBattle>().player.def));
                               remainPlayerList[k].GetComponent<PlayerBattle>().player.damageNumObjectIsAlive = true;//伤害数值显示
                               remainPlayerList[k].GetComponent<PlayerBattle>().player.damageNumber = remainEnemyList[i].GetComponent<EnemyUI>().damageList[n];
                               break;
                           }
                            }
                     }
                }
                 if(remainEnemyList[i].GetComponent<EnemyUI>().skillList[j].hpSkill)
                {
                     for (int k = 0; k < remainPlayerList.Count ; k++)
                     {
                       remainPlayerList[k].GetComponent<PlayerBattle>().player.hp -= ((remainEnemyList[i].GetComponent<EnemyUI>().skillList[j].hpSkillFactor * remainEnemyList[i].GetComponent<EnemyUI>().totalhp) - (remainEnemyList[i].GetComponent<EnemyUI>().skillList[j].hpSkillFactor * remainPlayerList[k].GetComponent<PlayerBattle>().player.def));
                       remainPlayerList[k].GetComponent<PlayerBattle>().player.targetUnit = remainEnemyList[i];

                        for (int n = 0; n < remainEnemyList[i].GetComponent<EnemyUI>().damageList.Count; n++)
                            { 
                            if(remainEnemyList[i].GetComponent<EnemyUI>().damageList[n] == 0)
                           {
                               remainEnemyList[i].GetComponent<EnemyUI>().damageList[n] = ((remainEnemyList[i].GetComponent<EnemyUI>().skillList[j].hpSkillFactor * remainEnemyList[i].GetComponent<EnemyUI>().totalhp) - (remainEnemyList[i].GetComponent<EnemyUI>().skillList[j].hpSkillFactor * remainPlayerList[k].GetComponent<PlayerBattle>().player.def));
                               remainPlayerList[k].GetComponent<PlayerBattle>().player.damageNumObjectIsAlive = true;//伤害数值显示
                               remainPlayerList[k].GetComponent<PlayerBattle>().player.damageNumber = remainEnemyList[i].GetComponent<EnemyUI>().damageList[n];
                               break;
                           }
                            }
                     }
                }
                if(remainEnemyList[i].GetComponent<EnemyUI>().skillList[j].apSkill)
                {
                    for (int k = 0; k < remainPlayerList.Count ; k++)
                     {
                       remainPlayerList[k].GetComponent<PlayerBattle>().player.hp -= ((remainEnemyList[i].GetComponent<EnemyUI>().skillList[j].apSkillFactor * remainEnemyList[i].GetComponent<EnemyUI>().ap) - (remainEnemyList[i].GetComponent<EnemyUI>().skillList[j].apSkillFactor * remainPlayerList[k].GetComponent<PlayerBattle>().player.mdef));
                       remainPlayerList[k].GetComponent<PlayerBattle>().player.targetUnit = remainEnemyList[i];

                        for (int n = 0; n < remainEnemyList[i].GetComponent<EnemyUI>().damageList.Count; n++)
                            { 
                            if(remainEnemyList[i].GetComponent<EnemyUI>().damageList[n] == 0)
                           {
                               remainEnemyList[i].GetComponent<EnemyUI>().damageList[n] = ((remainEnemyList[i].GetComponent<EnemyUI>().skillList[j].apSkillFactor * remainEnemyList[i].GetComponent<EnemyUI>().ap) - (remainEnemyList[i].GetComponent<EnemyUI>().skillList[j].apSkillFactor * remainPlayerList[k].GetComponent<PlayerBattle>().player.mdef));
                               remainPlayerList[k].GetComponent<PlayerBattle>().player.damageNumObjectIsAlive = true;//伤害数值显示
                               remainPlayerList[k].GetComponent<PlayerBattle>().player.damageNumber = remainEnemyList[i].GetComponent<EnemyUI>().damageList[n];
                               break;
                           }
                            }
                       
                     }
                }
                if(remainEnemyList[i].GetComponent<EnemyUI>().skillList[j].iqSkill)
                {
                    for (int k = 0; k < remainPlayerList.Count ; k++)
                     {
                       remainPlayerList[k].GetComponent<PlayerBattle>().player.hp -= ((remainEnemyList[i].GetComponent<EnemyUI>().skillList[j].iqSkillFactor * remainEnemyList[i].GetComponent<EnemyUI>().iq) - (remainEnemyList[i].GetComponent<EnemyUI>().skillList[j].iqSkillFactor * remainPlayerList[k].GetComponent<PlayerBattle>().player.mdef));
                       remainPlayerList[k].GetComponent<PlayerBattle>().player.targetUnit = remainEnemyList[i];

                        for (int n = 0; n < remainEnemyList[i].GetComponent<EnemyUI>().damageList.Count; n++)
                            { 
                            if(remainEnemyList[i].GetComponent<EnemyUI>().damageList[n] == 0)
                           {
                               remainEnemyList[i].GetComponent<EnemyUI>().damageList[n] =((remainEnemyList[i].GetComponent<EnemyUI>().skillList[j].iqSkillFactor * remainEnemyList[i].GetComponent<EnemyUI>().iq) - (remainEnemyList[i].GetComponent<EnemyUI>().skillList[j].iqSkillFactor * remainPlayerList[k].GetComponent<PlayerBattle>().player.mdef));
                               remainPlayerList[k].GetComponent<PlayerBattle>().player.damageNumObjectIsAlive = true;//伤害数值显示
                               remainPlayerList[k].GetComponent<PlayerBattle>().player.damageNumber = remainEnemyList[i].GetComponent<EnemyUI>().damageList[n];
                               break;
                           }
                            }
                       
                     }
                }
            }
         }
       }
    }        
}
    public void Death()
    {
        for (int i = 0; i < remainEnemyList.Count; i++)
        {
            if(remainEnemyList[i].GetComponent<EnemyUI>().hp <= 0)
            {
                //Destroy(remainEnemyList[i]);
                remainEnemyList.Remove(remainEnemyList[i]);
               
            }
        }
        for (int i = 0; i < remainPlayerList.Count; i++)
        {
            if(remainPlayerList[i].GetComponent<PlayerBattle>().player.hp <= 0)
            {
                Destroy(remainPlayerList[i]);
                remainPlayerList.Remove(remainPlayerList[i]);
            }
            
        }
        

    }
    public void Victory()
    {
        if(remainEnemyList.Count == 0)
        {
            if(!enemyObject.GetComponent<EnemyUI>().playerClass.NPC)
            {
              victory.SetActive(true);
              if(enemyObject != null)
             {
              Destroy(enemyObject);
             }
            }
            if(enemyObject.GetComponent<EnemyUI>().playerClass.NPC)
            {
                npcManager.SetActive(true);
                npcDefeatSence.SetActive(true);
                 for (int i = 0; i < npcTalkSence.Count ; i++)
                 {
                     npcTalkSence[i].SetActive(false);
                 }
                 npcDefeatText.text = "你已经击败了" + enemyObject.GetComponent<NPC>().npc.playerName + ",你要如何处置？";

               // npcTalkSence.SetActive(false);
           
            }
            /*if(enemyObject.GetComponent<EnemyUI>().playerClass.NPC)
            {
              if(enemyObject.GetComponent<NPC>().npc.npcDeathItem.Count != 0)
              {
                int itemIndex = Random.Range(0 ,enemyObject.GetComponent<NPC>().npc.npcDeathItem.Count - 1);
                itemObject = Instantiate(itemPrefab);
                itemObject.GetComponent<ItemOnWorld>().thisItem = enemyObject.GetComponent<NPC>().npc.npcDeathItem[itemIndex];
                //itemObject = Instantiate(itemPrefab);
                itemObject.transform.DOMove(new Vector3( enemyObject.transform.position.x + 0.14f, enemyObject.transform.position.y + -1.0f, 0f), 1.0f);
              }
              for(int i = 0; i < enemyObject.GetComponent<NPC>().npcList.Count ; i++)
              {
                  if(enemyObject.GetComponent<NPC>().npcList[i] != enemyObject)
                  {
                  Destroy(enemyObject.GetComponent<NPC>().npcList[i]);
                  }
              }
            }*/
           

            for (int i = 0; i < remainPlayerList.Count ; i++)
            {
                if(remainPlayerList[i] != null)
                {
                    remainPlayerList[i].GetComponent<PlayerBattle>().player.damage = 0; 
                    remainPlayerList[i].GetComponent<PlayerBattle>().player.turn = 0;
                    remainPlayerList[i].GetComponent<PlayerBattle>().player.swordMax = 0;
                    for (int j = 0; j < remainPlayerList[i].GetComponent<PlayerBattle>().player.damageNumList.Count; j++)
                    {
                        remainPlayerList[i].GetComponent<PlayerBattle>().player.damageNumList[j] = 0;
                    }
                    for (int j = 0; j < remainPlayerList[i].GetComponent<PlayerBattle>().player.buffAndDebuffList.Count; j++)
                    {
                        remainPlayerList[i].GetComponent<PlayerBattle>().player.buffAndDebuffList[j] = null;
                    }
                    for (int j = 0; j < remainPlayerList[i].GetComponent<PlayerBattle>().player.buffTime.Count; j++)
                    {
                        remainPlayerList[i].GetComponent<PlayerBattle>().player.buffTime[j] = 0;
                    }
                    for (int j = 0; j < remainPlayerList[i].GetComponent<PlayerBattle>().player.buffObjectList.Count; j++)
                    {
                        remainPlayerList[i].GetComponent<PlayerBattle>().player.buffObjectList[j] = null;
                    }
               //Destroy(remainPlayerList[i]);
                    
                }

            }
            
        }
    }
    public void Fail()
    {

    }

}
