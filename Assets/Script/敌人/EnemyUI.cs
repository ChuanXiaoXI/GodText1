using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using System;
public class EnemyUI : MonoBehaviour
{  
    [Header("基类传输")]
    public Player_Class playerClass;
    public Image slotPlayerImage;
    public Text slotPlayerName;
    public Slider slider;
    public Slider speedSlider;
    [Header("点数")]
    public int point;
    public int rank;
    [Header("角色总属性值")]
    public List<Item> equipmentList = new List<Item>();//装备列表
    public int bloodNum;//血统槽数目

    public float hp;
    public float mp;
    public float sp;
    public float replyHp,baseReplyHp,equipmentReplyHp,temporaryReplyHp;
    public float baseReplyHpPCT,equipmentReplyHpPCT,temporaryReplyHpPCT;
    public float replyMp,baseReplyMp,equipmentReplyMp,temporaryReplyMp;
    public float baseReplyMpPCT,equipmentReplyMpPCT,temporaryReplyMpPCT;
    public float replySp,baseReplySp,equipmentReplySp,temporaryReplySp;
    public float baseReplySpPCT,equipmentReplySpPCT,temporaryReplySpPCT;//回复力

    public float totalhp,baseTotalhp,equipmentTotalhp,temporaryTotalhp;  
    public float baseTotalhpPCT,equipmentTotalhpPCT,temporaryTotalhpPCT;//最大血量
    public float totalmp,baseTotalmp,equipmentTotalmp,temporaryTotalmp;  
    public float baseTotalmpPCT,equipmentTotalmpPCT,temporaryTotalmpPCT;//最大魔量
    public float totalsp,baseTotalsp,equipmentTotalsp,temporaryTotalsp;  
    public float baseTotalspPCT,equipmentTotalspPCT,temporaryTotalspPCT;//最大体力
    public float ad,baseAd,equipmentAd,temporaryAd;  
    public float baseAdPCT,equipmentAdPCT,temporaryAdPCT;//物攻
    public float ap,baseAp,equipmentAp,temporaryAp;  
    public float baseApPCT,equipmentApPCT,temporaryApPCT;//法强
    public float def,baseDef,equipmentDef,temporaryDef;  
    public float baseDefPCT,equipmentDefPCT,temporaryDefPCT;//物防
    public float mdef,baseMdef,equipmentMdef,temporaryMdef;  
    public float baseMdefPCT,equipmentMdefPCT,temporaryMdefPCT;//魔防
    public float speed,baseSpeed,equipmentSpeed,temporarySpeed;  
    public float baseSpeedPCT,equipmentSpeedPCT,temporarySpeedPCT;//速度
    public float dodge,baseDodge,equipmentDodge,temporaryDodge;  
    //public float baseDodgePCT,equipmentDodgePCT,temporaryDodgePCT;//闪避
    public float crit,baseCrit,equipmentCrit,temporaryCrit;  
    //public float baseCritPCT,equipmentCritPCT,temporaryCritPCT;//暴击率
    public float iq,baseIq,equipmentIq,temporaryIq,baseIqPCT;  
    public float equipmentIqPCT,temporaryIqPCT;//脑力
    public float charm,baseCharm,equipmentCharm,temporaryCharm;  
    public float baseCharmPCT,equipmentCharmPCT,temporaryCharmPCT;//魅力
    public float critDamge,baseCritDamge,equipmentCritDamge;  
    public float temporaryCritDamge;//暴伤
    public float drainLife,baseDrainLife,equipmentDrainLife;  
    public float temporaryDrainLife;//吸血
    public float skillOdds,baseSkillOdds,equipmentSkillOdds,temPorarySkillOdds;//技能施法概率
    public float sword,baseSword,equipmentSword,temporarySword;
    public float gun,baseGun,equipmentGun,temporaryGun;
    [Header("战斗系统")]
    public GameObject playerBattlePrefab;
    public BattleManage battleManage;//控制器脚本
    public bool target;
    public float actionTime;//行动倒计时
    public float maxSpeed;//最大速度
    public GameObject targetEnemyUnit;//敌方对象
    public List<GameObject> targetEnemyUnitList = new List<GameObject>();//敌方全体单位
    public GameObject targetPlayerUnit;//我方对象
    public List<GameObject> targetPlayerUnitList = new List<GameObject>();//我方全体单位
    public GameObject ownObject;//自己，用于单体buff
    public GameObject targetUnit;//player施法对象，用于接受player方buff，如治疗，加速，减速，减防
    public List<GameObject> buffObjectList = new List<GameObject>();
    public int turn;//回合数
    [Header("伤害统计")]
    public float damageNum;//战斗总伤害
    public List<float> damageNumList = new List<float>();//回合伤害数值
    public float damage;//回合伤害值总数
    public List<float> damageList = new List<float>();//回合伤害数值
    [Header("时间系统与怪物成长系数")]
    public GameObject timeManage;
    public float timeFactor;
    public float level;

    public bool reply;//控制每天恢复的“锁”
    
    [Header("UI界面（任务和信息）")]
    //public GameObject infromation;
    public GameObject missionManager;
    public GameObject playerInformation;
    public GameObject enemyInformation;
    public GameObject itemInformation;
    public GameObject information;
    public GameObject informationManage;

   
    [Header("buff系统")]
    public BuffList buffList;//buff总列表
    public List<BuffAndDebuff> buffAndDebuffList = new List<BuffAndDebuff>();//player，buff列表，初始清空
    public List<int> buffTime = new List<int>();//buff持续时间
    public bool dizzy;
    public bool disarm;
    public float buffTotalhp;
    public float buffTotalhpPCT;
    public float buffTotalmp;
    public float buffTotalmpPCT;
    public float buffTotalsp;
    public float buffTotalspPCT;
    //public float buffSp;
    //public float buffSpPCT;
    public float buffAd;
    public float buffAdPCT;
    public float buffAp;
    public float buffApPCT;
    public float buffDef;
    public float buffDefPCT;
    public float buffMdef;
    public float buffMdefPCT;
    public float buffSpeed;
    public float buffSpeedPCT;
    public float buffDodge;
    //public float buffDodgePCT;
    public float buffCrit;
    //public float buffCritPCT;
    public float buffIq;
    public float buffIqPCT;
    public float buffCharm;
    public float buffCharmPCT;
    public float buffCritDamge;
    //public float buffCritDamgePCT;
    public float buffDrainLife;
    //public float buffDrainLifePCT;
    public float buffReplyHp;
    public float buffReplyHpPCT;
    public float buffReplyMp;
    public float buffReplyMpPCT;
    public float buffReplySp;
    public float buffReplySpPCT;
    public float buffSkillOdds;
    public float buffSword;
    public float buffGun;


    public float buffTotalhp1;
    public float buffTotalhpPCT1;
    public float buffTotalmp1;
    public float buffTotalmpPCT1;
    public float buffTotalsp1;
    public float buffTotalspPCT1;
    //public float buffSp1;
    //public float buffSpPCT1;
    public float buffAd1;
    public float buffAdPCT1;
    public float buffAp1;
    public float buffApPCT1;
    public float buffDef1;
    public float buffDefPCT1;
    public float buffMdef1;
    public float buffMdefPCT1;
    public float buffSpeed1;
    public float buffSpeedPCT1;
    public float buffDodge1;
    //public float buffDodgePCT1;
    public float buffCrit1;
    //public float buffCritPCT1;
    public float buffIq1;
    public float buffIqPCT1;
    public float buffCharm1;
    public float buffCharmPCT1;
    public float buffCritDamge1;
    //public float buffCritDamgePCT1;
    public float buffDrainLife1;
    //public float buffDrainLifePCT1;
    public float buffReplyHp1;
    public float buffReplyHpPCT1;
    public float buffReplyMp1;
    public float buffReplyMpPCT1;
    public float buffReplySp1;
    public float buffReplySpPCT1;
    public float buffSkillOdds1;
    public float buffSword1;
    public float buffGun1;

    public float buffTotalhp2;
    public float buffTotalhpPCT2;
    public float buffTotalmp2;
    public float buffTotalmpPCT2;
    public float buffTotalsp2;
    public float buffTotalspPCT2;
    //public float buffSp2;
    //public float buffSpPCT2;
    public float buffAd2;
    public float buffAdPCT2;
    public float buffAp2;
    public float buffApPCT2;
    public float buffDef2;
    public float buffDefPCT2;
    public float buffMdef2;
    public float buffMdefPCT2;
    public float buffSpeed2;
    public float buffSpeedPCT2;
    public float buffDodge2;
    public float buffCrit2;
    public float buffIq2;
    public float buffIqPCT2;
    public float buffCharm2;
    public float buffCharmPCT2;
    public float buffCritDamge2;
    public float buffDrainLife2;
    public float buffReplyHp2;
    public float buffReplyHpPCT2;
    public float buffReplyMp2;
    public float buffReplyMpPCT2;
    public float buffReplySp2;
    public float buffReplySpPCT2;
    public float buffSkillOdds2;
    public float buffSword2;
    public float buffGun2;


//[技能系统]
public List<Skill> skillList = new List<Skill>();
float swordMax;

[Header("战斗显示")]
public GameObject damageNumObject;
public GameObject damageNumobjectPoint1;
public GameObject damageNumobjectPoint2;
public GameObject damageNumObj;
//public Text damageNumText;
public float damageNumber;
public string dodgeString;
public bool damageNumObjectIsAlive;

public GameObject buffManage;
//public float waitSecond;


public void DamageNumObjectIsAlive()
{
    if(damageNumObjectIsAlive)
    {
        damageNumObj = Instantiate(damageNumObject);
        //damageNumObj.GetComponent<DamageNumber>().enemyUI = gameObject;
        //damageNumObj.GetComponent<DamageNumber>().dodgeString = dodgeString;
        //damageNumObj.GetComponent<DamageNumber>().damageNumber = damageNumber;
        damageNumObj.transform.parent = gameObject.transform;
        damageNumObj.transform.position = damageNumobjectPoint1.transform.position;

        damageNumObjectIsAlive = false;
    }
      
}

  
 public void OnMouseDown()
   {
    information.SetActive(true);
    playerInformation.SetActive(false);
    enemyInformation.SetActive(true);
    itemInformation.SetActive(false);
    enemyInformation.GetComponent<EnemyInformation>().playerscript = gameObject.GetComponent<EnemyUI>();
     
      
    }
public void Start()
{
    missionManager = GameObject.Find("MissionManager");
    //infromation = GameObject.Find("InformationManage");
    battleManage = GameObject.Find("UI").transform.GetChild(6).gameObject.GetComponent<BattleManage>();
    timeManage = GameObject.Find("World");//时间系统
    
    informationManage = GameObject.Find("InformationManage");
    information = informationManage.transform.GetChild(0).gameObject;
    enemyInformation = information.transform.GetChild(1).gameObject;
    playerInformation = information.transform.GetChild(0).gameObject;
    itemInformation = informationManage.transform.GetChild(1).gameObject;
    
    
    
    //slotPlayerImage.sprite = playerClass.playerImage;//图片传值
    Base();
    Equipment();
    PlayerInformation();
    
    hp = totalhp;mp = totalmp;sp = totalsp;
}
public void Update()
{
    slider.value = hp;
    slider.maxValue = totalhp;
    speedSlider.maxValue = (maxSpeed / speed) * 2;
    speedSlider.value = actionTime;
    ownObject = gameObject;
    DamageNumObjectIsAlive();
    Point();
    Reply();
    Equipment();
    PlayerInformation();
    Fight();
    Death();
    
}



public void PlayerInformation()
{
    if(hp >= totalhp)
    {
        hp = totalhp;
    }
    if(mp >= totalmp)
    {
        mp = totalmp;
    }
    if(sp >= totalsp)
    {
        sp = totalsp;
    }
    if(ad <= 0)
    {
        ad = 0;
    }
    if(ap <= 0)
    {
        ap = 0;
    }
    if(mp <= 0)
    {
        mp = 0;
    }
    if(sp <= 0)
    {
        sp = 0;
    }
    if(speed <= 1)
    {
        speed = 1;
    }
    
    if(timeManage.GetComponent<TimeManage>().day <= 50)
    {
        timeFactor = timeManage.GetComponent<TimeManage>().day;
    }
    if(timeManage.GetComponent<TimeManage>().day > 50)
    {
        timeFactor = 50;
    }
    if(timeManage.GetComponent<TimeManage>().level <= 50)
    {
        level = timeManage.GetComponent<TimeManage>().level;
    }
    if(timeManage.GetComponent<TimeManage>().level > 50)
    {
        level = timeManage.GetComponent<TimeManage>().level;
    }
    
    
    
    //玩家属性值公式//属性 = （基础属性 + 装备属性 + 临时附加属性（技能附加，消耗品附加）） * （1 + 基础附加百分比（道具，特性）+ 装备附加百分比 + 临时附加百分比（技能，消耗品））
    //totalhp = ((baseTotalhp + equipmentTotalhp + temporaryTotalhp + buffTotalhp) * (1.0f + baseTotalhpPCT + equipmentTotalhpPCT + temporaryTotalhpPCT + buffTotalhpPCT)) * ((1.0f + (0.1f * timeFactor)) * (1.0f + (0.1f * level)));
    totalhp = ((baseTotalhp + equipmentTotalhp + temporaryTotalhp + buffTotalhp) * (1.0f + baseTotalhpPCT + equipmentTotalhpPCT + temporaryTotalhpPCT + buffTotalhpPCT)) * ((1.0f + (0.1f * timeFactor)) * (1.0f + (0.1f * level)));
    totalmp = ((baseTotalmp + equipmentTotalmp + temporaryTotalmp + buffTotalmp) * (1.0f + baseTotalmpPCT + equipmentTotalmpPCT + temporaryTotalmpPCT + buffTotalmpPCT)) * ((1.0f + (0.1f * timeFactor)) * (1.0f + (0.1f * level)));
    totalsp = ((baseTotalsp + equipmentTotalsp + temporaryTotalsp + buffTotalsp) * (1.0f + baseTotalspPCT + equipmentTotalspPCT + temporaryTotalspPCT + buffTotalspPCT)) * ((1.0f + (0.1f * timeFactor)) * (1.0f + (0.1f * level)));
    ad = ((baseAd + equipmentAd + temporaryAd + buffAd) * (1.0f + baseAdPCT + equipmentAdPCT + temporaryAdPCT + buffAdPCT)) * ((1.0f + (0.1f * timeFactor)) * (1.0f + (0.1f * level)));
    ap = ((baseAp + equipmentAp + temporaryAp + buffAp) * (1.0f + baseApPCT + equipmentApPCT + temporaryApPCT + buffApPCT)) * ((1.0f + (0.1f * timeFactor)) * (1.0f + (0.1f * level)));
    def = ((baseDef + equipmentDef + temporaryDef + buffDef) * (1.0f + baseDefPCT + equipmentDefPCT + temporaryDefPCT + buffDefPCT)) * ((1.0f + (0.1f * timeFactor)) * (1.0f + (0.1f * level)));
    mdef = ((baseMdef + equipmentMdef + temporaryMdef + buffMdef) * (1.0f + baseMdefPCT + equipmentMdefPCT + temporaryMdefPCT + buffMdefPCT)) * ((1.0f + (0.1f * timeFactor)) * (1.0f + (0.1f * level)));
    speed = ((baseSpeed + equipmentSpeed + temporarySpeed + buffSpeed) * (1.0f + baseSpeedPCT + equipmentSpeedPCT + temporarySpeedPCT + buffSpeedPCT)) * ((1.0f + (0.1f * timeFactor)) * (1.0f + (0.1f * level)));
    dodge = (baseDodge + equipmentDodge + temporaryDodge + buffDodge); //* (1.0f + baseDodgePCT + equipmentDodgePCT + temporaryDodgePCT + buffDodgePCT);
    crit = (baseCrit + equipmentCrit + temporaryCrit + buffCrit) ;//* (1.0f + baseCritPCT + equipmentCritPCT + temporaryCritPCT + buffCritPCT);
    iq = ((baseIq + equipmentIq + temporaryIq + buffIq) * (1.0f + baseIqPCT + equipmentIqPCT + temporaryIqPCT + buffIqPCT)) * ((1.0f + (0.1f * timeFactor)) * (1.0f + (0.1f * level)));
    charm = ((baseCharm + equipmentCharm + temporaryCharm + buffCharm) * (1.0f + baseCharmPCT + equipmentCharmPCT + temporaryCharmPCT + buffCharmPCT)) * ((1.0f + (0.1f * timeFactor)) * (1.0f + (0.1f * level)));
    critDamge = (baseCritDamge + equipmentCritDamge + temporaryCritDamge + buffCritDamge);//* (1.0f + baseCritDamgePCT + equipmentCritDamgePCT + temporaryCritDamgePCT + buffCritDamgePCT);
    drainLife = (baseDrainLife + equipmentDrainLife + temporaryDrainLife + buffDrainLife); //* (1.0f + baseDrainLifePCT + equipmentDrainLifePCT + temporaryDrainLifePCT + buffDrainLifePCT);
    replyHp = ((baseReplyHp + equipmentReplyHp + temporaryReplyHp + buffReplyHp) * (1.0f + baseReplyHpPCT + equipmentReplyHpPCT + temporaryReplyHpPCT + buffReplyHpPCT)) * ((1.0f + (0.1f * timeFactor)) * (1.0f + (0.1f * level)));
    replyMp = ((baseReplyMp + equipmentReplyMp + temporaryReplyMp + buffReplyMp) * (1.0f + baseReplyMpPCT + equipmentReplyMpPCT + temporaryReplyMpPCT + buffReplyMpPCT));  
    replySp = ((baseReplySp + equipmentReplySp + temporaryReplySp + buffReplySp) * (1.0f + baseReplySpPCT + equipmentReplySpPCT + temporaryReplySpPCT + buffReplySpPCT)); 
    skillOdds = baseSkillOdds + equipmentSkillOdds + temPorarySkillOdds + buffSkillOdds;
    sword = baseSword + equipmentSword + temporarySword + buffSword;
    gun = baseGun + equipmentGun + temporaryGun + buffGun;
    
}
public void Reply()
{
    if(reply && timeManage.GetComponent<TimeManage>().time == 0)
    {
        hp += (10 * replyHp);
        mp += (10 * replyMp);
        sp += (10 * replySp);
        reply = false;
    }
    if(timeManage.GetComponent<TimeManage>().time == 1)
    {
        reply = true;
    }
}
public void Base()
{//基础属性值
    baseTotalhp = playerClass.totalhp;
    baseTotalmp = playerClass.totalmp;
    baseTotalsp = playerClass.totalsp;

    baseReplyHp = playerClass.replyHp;
    baseReplyMp = playerClass.replyMp;
    baseReplySp = playerClass.replySp;

    
    baseAd = playerClass.ad;
    baseAp = playerClass.ap;
    baseDef = playerClass.def;
    baseMdef = playerClass.mdef;
    baseSpeed = playerClass.speed;
    baseDodge = playerClass.dodge;
    baseCrit = playerClass.crit;
    baseIq = playerClass.iq;
    baseCharm = playerClass.charm;
    baseCritDamge = playerClass.critDamge;
    baseDrainLife = playerClass.drainLife;
    baseSkillOdds = playerClass.skillOdds;
    baseSword = playerClass.sword;
    baseGun = playerClass.gun;

    baseTotalhpPCT = playerClass.totalhpPCT;
    baseTotalmpPCT = playerClass.totalmpPCT;
    baseTotalspPCT = playerClass.totalspPCT;
    baseAdPCT = playerClass.adPCT;
    baseApPCT = playerClass.apPCT;
    baseDefPCT = playerClass.defPCT;
    baseMdefPCT = playerClass.mdefPCT;
    baseSpeedPCT = playerClass.speedPCT;
    //baseDodgePCT = playerClass.dodgePCT ;
    //baseCritPCT = playerClass.critPCT;
    baseIqPCT = playerClass.iqPCT;
    baseCharmPCT = playerClass.charmPCT;
    //baseCritDamgePCT = playerClass.critDamgePCT;
    //baseDrainLifePCT = playerClass.drainLifePCT;
    baseReplyHpPCT = playerClass.replyHpPCT;
    baseReplyMpPCT = playerClass.replyMpPCT;
    baseReplySpPCT = playerClass.replySpPCT;
}

public void Equipment()
{
    //装备属性值
    equipmentReplyHp = 0;
    equipmentReplyHpPCT = 0;
    equipmentReplyMp = 0;
    equipmentReplyMpPCT = 0;
    equipmentReplySp = 0;
    equipmentReplySpPCT = 0;
    equipmentTotalhp = 0;
    equipmentTotalhpPCT = 0;
    equipmentTotalmp = 0;
    equipmentTotalmpPCT = 0;
    equipmentTotalsp = 0;
    equipmentTotalspPCT = 0;
    equipmentAd = 0;
    equipmentAdPCT = 0;
    equipmentDef = 0;
    equipmentDefPCT = 0;
    equipmentAp = 0;
    equipmentApPCT = 0;
    equipmentMdef = 0;
    equipmentMdefPCT = 0;
    equipmentSpeed = 0;
    equipmentSpeedPCT = 0;
    equipmentDodge = 0;
    //equipmentDodgePCT = 0;
    equipmentCrit = 0;
    //equipmentCritPCT = 0;
    equipmentIq = 0;
    equipmentIqPCT = 0;
    equipmentCharm = 0;
    equipmentCharmPCT = 0;
    equipmentCritDamge = 0;
    //equipmentCritDamgePCT = 0;
    equipmentDrainLife = 0;
    //equipmentDrainLifePCT = 0;
    equipmentSkillOdds = 0;
    equipmentSword = 0;
    equipmentGun = 0;
    for (int i = 0; i < skillList.Count; i++)
    {
        skillList[i] = null;
    }
   
    for (int i = 0; i < equipmentList.Count; i++)
    {
        if(equipmentList[i] != null)
        {
        equipmentReplyHp += equipmentList[i].replyHp;
        equipmentReplyHpPCT += equipmentList[i].replyHpPCT;
        equipmentReplyMp += equipmentList[i].replyMp;
        equipmentReplyMpPCT += equipmentList[i].replyMpPCT;
        equipmentReplySp += equipmentList[i].replySp;
        equipmentReplySpPCT += equipmentList[i].replySpPCT;
        equipmentTotalhp += equipmentList[i].totalhp;
        equipmentTotalhpPCT += equipmentList[i].totalhpPCT;
        equipmentTotalmp += equipmentList[i].totalmp;
        equipmentTotalmpPCT += equipmentList[i].totalmpPCT;
        equipmentTotalsp += equipmentList[i].totalsp;
        equipmentTotalspPCT += equipmentList[i].totalspPCT;
        equipmentAd += equipmentList[i].ad;
        equipmentAdPCT += equipmentList[i].adPCT;
        equipmentAp += equipmentList[i].ap;
        equipmentApPCT += equipmentList[i].apPCT;
        equipmentDef += equipmentList[i].def;
        equipmentDefPCT += equipmentList[i].defPCT;
        equipmentMdef += equipmentList[i].mdef;
        equipmentMdefPCT += equipmentList[i].mdefPCT;
        equipmentSpeed += equipmentList[i].speed;
        equipmentSpeedPCT += equipmentList[i].speedPCT;
        equipmentDodge += equipmentList[i].dodge;
        //equipmentDodgePCT += equipmentList[i].dodgePCT;
        equipmentCrit += equipmentList[i].crit;
        //equipmentCritPCT += equipmentList[i].critPCT;
        equipmentIq += equipmentList[i].iq;
        equipmentIqPCT += equipmentList[i].iqPCT;
        equipmentCharm += equipmentList[i].charm;
        equipmentCharmPCT += equipmentList[i].charmPCT;
        equipmentCritDamge += equipmentList[i].critDamge;
        //equipmentCritDamgePCT += equipmentList[i].critDamgePCT;
        equipmentDrainLife += equipmentList[i].drainLife;
        //equipmentDrainLifePCT += equipmentList[i].drainLifePCT; 
        equipmentSkillOdds += equipmentList[i].skillOdds;
        equipmentSword += equipmentList[i].sword;
        equipmentGun += equipmentList[i].gun;
        for (int j = 0; j < equipmentList[i].skillList.Count; j++)
        {
            if(equipmentList[i].skillList[j] != null)
            {
             for (int l = 0; l < skillList.Count; l++)
             {
                 if(skillList[l] == null)
                 {
                     skillList[l] = equipmentList[i].skillList[j];
                     break;
                 }
             }
            }
        }
        
            
        
        }  
    }   


    
}
public void Fight()//战斗机制
{
    if(battleManage.fighting)
    {  
        
       maxSpeed = battleManage.maxSpeed;
       actionTime += Time.deltaTime;

       Buff();
       Target();
       DamageNum();

       if(actionTime >= 2 * (maxSpeed / speed))//行动开始
       {
        turn += 1; 
        actionTime = 0;
        hp += replyHp;
        mp += replyMp;
        sp += replySp;

        for (int i = 0; i < buffTime.Count; i++)
      {
        if(buffTime[i] != 0)
        {
            buffTime[i] -= 1;//持续回合数减1
        }
      }

        if(!dizzy)
        { 
          //Target();//目标判定  
          Action();
        }
        if(dizzy)
        {
            End();
        }
       }

    }
}

public void Target()//目标机制
{   
        targetPlayerUnitList = battleManage.remainEnemyList;//Enemy方列表
       if(target)
       {
              for (int i = 0; i < targetPlayerUnitList.Count; i++)
            {
               int targetIndex = Random.Range(0 , battleManage.remainEnemyList.Count);
        
              if(battleManage.remainEnemyList[targetIndex] != null)
              {
              targetPlayerUnit = battleManage.remainEnemyList[targetIndex];//Enemy单体对象
              //targetPlayerUnit.GetComponent<EnemyUI>().target = gameObject;
              break;
              }
            }
              for (int i = 0; i < battleManage.remainPlayerList.Count; i++)
             {
            int targetIndex = Random.Range(0 , battleManage.remainPlayerList.Count);

             if(battleManage.remainPlayerList[targetIndex] != null)
             {
              targetEnemyUnit = battleManage.remainPlayerList[targetIndex];//Player单体对象
              targetEnemyUnit.GetComponent<PlayerBattle>().player.targetUnit = gameObject;
              break;
             }
             target = false;
        }
       }
        targetEnemyUnitList = battleManage.remainPlayerList;
        ownObject = gameObject;
        if(targetPlayerUnit == null)
       {
           for (int i = 0; i < targetEnemyUnitList.Count; i++)
          {
            int targetIndex = Random.Range(0 , battleManage.remainEnemyList.Count);
        
            if(battleManage.remainEnemyList[targetIndex] != null)
            {
              targetPlayerUnit = battleManage.remainEnemyList[targetIndex];
              //targetEnemyUnit.GetComponent<EnemyUI>().targetObject = gameObject;
              break;
            }
          }
       }
       if(targetEnemyUnit == null)
       {
           for (int i = 0; i < battleManage.remainPlayerList.Count; i++)
        {
            int targetIndex = Random.Range(0 , battleManage.remainPlayerList.Count);
            
            if(battleManage.remainPlayerList[targetIndex] != null)
            {
              targetPlayerUnit = battleManage.remainPlayerList[targetIndex];
              targetPlayerUnit.GetComponent<PlayerBattle>().player.targetUnit = gameObject;
              break;
            }
        }
       }
       

}
public void Buff()//buff机制
{
   dizzy = false;
     disarm = false;

     buffTotalhp1 = 0;
     buffTotalhpPCT1 = 0;
     buffTotalmp1 = 0;
     buffTotalmpPCT1 = 0;
     buffTotalsp1 = 0;
     buffTotalspPCT1 = 0;
     buffAd1 = 0;
     buffAdPCT1 = 0;
     buffAp1 = 0;
     buffApPCT1 = 0;
     buffDef1 = 0;
     buffDefPCT1 = 0;
     buffMdef1 = 0;
     buffMdefPCT1 = 0;
     buffSpeed1 = 0;
     buffSpeedPCT1 = 0;
     buffDodge1 = 0;
     //buffDodgePCT1 = 0;
     buffCrit1 = 0;
     //buffCritPCT1 = 0;
     buffIq1 = 0;
     buffIqPCT1 = 0;
     buffCharm1 = 0;
     buffCharmPCT1 = 0;
     buffCritDamge1 = 0;
     //buffCritDamgePCT1 = 0;
     buffDrainLife1 = 0;
     //buffDrainLifePCT1 = 0;
     buffReplyHp1 = 0;
     buffReplyHpPCT1 = 0;
     buffReplyMp1 = 0;
     buffReplyMpPCT1 = 0;
     buffReplySp1 = 0;
     buffReplySpPCT1 = 0;
     buffSword1 = 0;
     buffGun1 = 0;
     buffSkillOdds1 = 0;

     buffTotalhp2 = 0;
     buffTotalhpPCT2 = 0;
     buffTotalmp2 = 0;
     buffTotalmpPCT2 = 0;
     buffTotalsp2 = 0;
     buffTotalspPCT2 = 0;
     buffAd2 = 0;
     buffAdPCT2 = 0;
     buffAp2 = 0;
     buffApPCT2 = 0;
     buffDef2 = 0;
     buffDefPCT2 = 0;
     buffMdef2 = 0;
     buffMdefPCT2 = 0;
     buffSpeed2 = 0;
     buffSpeedPCT2 = 0;
     buffDodge2 = 0;
     //buffDodgePCT2 = 0;
     buffCrit2 = 0;
     //buffCritPCT2 = 0;
     buffIq2 = 0;
     buffIqPCT2 = 0;
     buffCharm2 = 0;
     buffCharmPCT2 = 0;
     buffCritDamge2 = 0;
     //buffCritDamgePCT2 = 0;
     buffDrainLife2 = 0;
     //buffDrainLifePCT2 = 0;
     buffReplyHp2 = 0;
     buffReplyHpPCT2 = 0;
     buffReplyMp2 = 0;
     buffReplyMpPCT2 = 0;
     buffReplySp2 = 0;
     buffReplySpPCT2 = 0;
     buffSword2 = 0;
     buffGun2 = 0;
     buffSkillOdds2 = 0;
    for (int i = 0; i < buffAndDebuffList.Count; i++)
     {
         if(buffAndDebuffList[i] != null)
         {  
             if(buffAndDebuffList[i] == buffList.buffList[10])
             {
                dizzy = true;
             }
             if(buffAndDebuffList[i].disarm)
             {
                disarm = true;
             }

             if(buffAndDebuffList[i].singleDebuff || buffAndDebuffList[i].teamDebuff)//脑力系数固定0.0002;每100脑力影响百分之2光环；
             {
             sp += (buffAndDebuffList[i].sp + buffObjectList[i].GetComponent<TeamPlayer>().ap * buffAndDebuffList[i].skillFactor);
             mp += (buffAndDebuffList[i].mp + buffObjectList[i].GetComponent<TeamPlayer>().ap * buffAndDebuffList[i].skillFactor);
             hp += (buffAndDebuffList[i].hp + buffObjectList[i].GetComponent<TeamPlayer>().ap * buffAndDebuffList[i].skillFactor);
             buffTotalhp1 += (buffAndDebuffList[i].totalhp + buffObjectList[i].GetComponent<TeamPlayer>().ap * buffAndDebuffList[i].skillFactor);
             buffTotalhpPCT1 += (buffAndDebuffList[i].totalhpPCT + buffObjectList[i].GetComponent<TeamPlayer>().iq * buffAndDebuffList[i].skillFactor);
             buffTotalmp1 += (buffAndDebuffList[i].totalmp + buffObjectList[i].GetComponent<TeamPlayer>().ap * buffAndDebuffList[i].skillFactor);
             buffTotalmpPCT1 += (buffAndDebuffList[i].totalmpPCT + buffObjectList[i].GetComponent<TeamPlayer>().iq * buffAndDebuffList[i].skillFactor);
             buffTotalsp1 += (buffAndDebuffList[i].totalsp + buffObjectList[i].GetComponent<TeamPlayer>().ap * buffAndDebuffList[i].skillFactor);
             buffTotalspPCT1 += (buffAndDebuffList[i].totalspPCT + buffObjectList[i].GetComponent<TeamPlayer>().iq * buffAndDebuffList[i].skillFactor);
             buffAd1 += (buffAndDebuffList[i].ad + buffObjectList[i].GetComponent<TeamPlayer>().ap * buffAndDebuffList[i].skillFactor);
             buffAdPCT1 += (buffAndDebuffList[i].adPCT + buffObjectList[i].GetComponent<TeamPlayer>().iq * buffAndDebuffList[i].skillFactor);
             buffAp1 += (buffAndDebuffList[i].ap + buffObjectList[i].GetComponent<TeamPlayer>().ap* buffAndDebuffList[i].skillFactor);
             buffApPCT1 += (buffAndDebuffList[i].apPCT + buffObjectList[i].GetComponent<TeamPlayer>().iq * buffAndDebuffList[i].skillFactor);
             buffDef1 += (buffAndDebuffList[i].def + buffObjectList[i].GetComponent<TeamPlayer>().ap * buffAndDebuffList[i].skillFactor);
             buffDefPCT1 += (buffAndDebuffList[i].defPCT + buffObjectList[i].GetComponent<TeamPlayer>().iq * buffAndDebuffList[i].skillFactor);
             buffMdef1 += (buffAndDebuffList[i].mdef + buffObjectList[i].GetComponent<TeamPlayer>().ap * buffAndDebuffList[i].skillFactor);
             buffMdefPCT1 += (buffAndDebuffList[i].mdefPCT + buffObjectList[i].GetComponent<TeamPlayer>().iq * buffAndDebuffList[i].skillFactor);
             buffSpeed1 += (buffAndDebuffList[i].speed + buffObjectList[i].GetComponent<TeamPlayer>().ap * buffAndDebuffList[i].skillFactor);
             buffSpeedPCT1 += (buffAndDebuffList[i].speedPCT + buffObjectList[i].GetComponent<TeamPlayer>().iq * buffAndDebuffList[i].skillFactor);
             buffDodge1 += (buffAndDebuffList[i].dodge + buffObjectList[i].GetComponent<TeamPlayer>().ap * buffAndDebuffList[i].skillFactor);
             //buffDodgePCT1 += (buffAndDebuffList[i].dodgePCT+ buffObjectList[i].GetComponent<TeamPlayer>().iq * buffAndDebuffList[i].skillFactor * buffAndDebuffList[i].dodgePCT);
             buffCrit1 += (buffAndDebuffList[i].crit + buffObjectList[i].GetComponent<TeamPlayer>().ap * buffAndDebuffList[i].skillFactor);
             //buffCritPCT1 += (buffAndDebuffList[i].critPCT + buffObjectList[i].GetComponent<TeamPlayer>().iq * buffAndDebuffList[i].skillFactor * buffAndDebuffList[i].critPCT);
             buffIq1 += (buffAndDebuffList[i].iq + buffObjectList[i].GetComponent<TeamPlayer>().ap * buffAndDebuffList[i].skillFactor);
             buffIqPCT1 += (buffAndDebuffList[i].iqPCT + buffObjectList[i].GetComponent<TeamPlayer>().iq * buffAndDebuffList[i].skillFactor);
             buffCharm1 += (buffAndDebuffList[i].charm + buffObjectList[i].GetComponent<TeamPlayer>().ap * buffAndDebuffList[i].skillFactor);
             buffCharmPCT1 += (buffAndDebuffList[i].charmPCT + buffObjectList[i].GetComponent<TeamPlayer>().ap * buffAndDebuffList[i].skillFactor);
             buffCritDamge1 += (buffAndDebuffList[i].critDamge + buffObjectList[i].GetComponent<TeamPlayer>().iq * buffAndDebuffList[i].skillFactor);
             //buffCritDamgePCT1 += (buffAndDebuffList[i].critDamgePCT + buffObjectList[i].GetComponent<TeamPlayer>().iq * buffAndDebuffList[i].skillFactor * buffAndDebuffList[i].critDamgePCT);
             buffDrainLife1 += (buffAndDebuffList[i].drainLife + buffObjectList[i].GetComponent<TeamPlayer>().ap * buffAndDebuffList[i].skillFactor);
             //buffDrainLifePCT1 += (buffAndDebuffList[i].drainLifePCT + buffObjectList[i].GetComponent<TeamPlayer>().iq * buffAndDebuffList[i].skillFactor * buffAndDebuffList[i].drainLifePCT);
             buffReplyHp1 += (buffAndDebuffList[i].replyHp + buffObjectList[i].GetComponent<TeamPlayer>().ap * buffAndDebuffList[i].skillFactor);
             buffReplyHpPCT1 += (buffAndDebuffList[i].replyHpPCT + buffObjectList[i].GetComponent<TeamPlayer>().iq * buffAndDebuffList[i].skillFactor);
             buffReplyMp1 += (buffAndDebuffList[i].replyMp + buffObjectList[i].GetComponent<TeamPlayer>().ap * buffAndDebuffList[i].skillFactor);
             buffReplyMpPCT1 += (buffAndDebuffList[i].replyMpPCT + buffObjectList[i].GetComponent<TeamPlayer>().iq * buffAndDebuffList[i].skillFactor);
             buffReplySp1 += (buffAndDebuffList[i].replySp + buffObjectList[i].GetComponent<TeamPlayer>().ap * buffAndDebuffList[i].skillFactor);
             buffReplySpPCT1 += (buffAndDebuffList[i].replySpPCT + buffObjectList[i].GetComponent<TeamPlayer>().iq * buffAndDebuffList[i].skillFactor);
             buffSkillOdds1 += buffAndDebuffList[i].skillOdds;
             buffSword1 += buffAndDebuffList[i].sword;
             buffGun1 += buffAndDebuffList[i].gun;
             }
             if(buffAndDebuffList[i].singleBuff || buffAndDebuffList[i].teamBuff)
             {
             sp += (buffAndDebuffList[i].sp + buffObjectList[i].GetComponent<EnemyUI>().ap * buffAndDebuffList[i].skillFactor);
             mp += (buffAndDebuffList[i].mp + buffObjectList[i].GetComponent<EnemyUI>().ap * buffAndDebuffList[i].skillFactor);
             hp += (buffAndDebuffList[i].hp + buffObjectList[i].GetComponent<EnemyUI>().ap * buffAndDebuffList[i].skillFactor);
             buffTotalhp2 += (buffAndDebuffList[i].totalhp + buffObjectList[i].GetComponent<EnemyUI>().ap * buffAndDebuffList[i].skillFactor);
             buffTotalhpPCT2 += (buffAndDebuffList[i].totalhpPCT + buffObjectList[i].GetComponent<EnemyUI>().iq * buffAndDebuffList[i].skillFactor);
             buffTotalmp2 += (buffAndDebuffList[i].totalmp + buffObjectList[i].GetComponent<EnemyUI>().ap * buffAndDebuffList[i].skillFactor);
             buffTotalmpPCT2 += (buffAndDebuffList[i].totalmpPCT + buffObjectList[i].GetComponent<EnemyUI>().iq * buffAndDebuffList[i].skillFactor);
             buffTotalsp2 += (buffAndDebuffList[i].totalsp + buffObjectList[i].GetComponent<EnemyUI>().ap * buffAndDebuffList[i].skillFactor);
             buffTotalspPCT2 += (buffAndDebuffList[i].totalspPCT + buffObjectList[i].GetComponent<EnemyUI>().iq * buffAndDebuffList[i].skillFactor);
             buffAd2 += (buffAndDebuffList[i].ad + buffObjectList[i].GetComponent<EnemyUI>().ap * buffAndDebuffList[i].skillFactor);
             buffAdPCT2 += (buffAndDebuffList[i].adPCT + buffObjectList[i].GetComponent<EnemyUI>().iq * buffAndDebuffList[i].skillFactor);
             buffAp2 += (buffAndDebuffList[i].ap + buffObjectList[i].GetComponent<EnemyUI>().ap* buffAndDebuffList[i].skillFactor);
             buffApPCT2 += (buffAndDebuffList[i].apPCT + buffObjectList[i].GetComponent<EnemyUI>().iq * buffAndDebuffList[i].skillFactor);
             buffDef2 += (buffAndDebuffList[i].def + buffObjectList[i].GetComponent<EnemyUI>().ap * buffAndDebuffList[i].skillFactor);
             buffDefPCT2 += (buffAndDebuffList[i].defPCT + buffObjectList[i].GetComponent<EnemyUI>().iq * buffAndDebuffList[i].skillFactor);
             buffMdef2 += (buffAndDebuffList[i].mdef + buffObjectList[i].GetComponent<EnemyUI>().ap * buffAndDebuffList[i].skillFactor);
             buffMdefPCT2 += (buffAndDebuffList[i].mdefPCT + buffObjectList[i].GetComponent<EnemyUI>().iq * buffAndDebuffList[i].skillFactor);
             buffSpeed2 += (buffAndDebuffList[i].speed + buffObjectList[i].GetComponent<EnemyUI>().ap * buffAndDebuffList[i].skillFactor);
             buffSpeedPCT2 += (buffAndDebuffList[i].speedPCT + buffObjectList[i].GetComponent<EnemyUI>().iq * buffAndDebuffList[i].skillFactor);
             buffDodge2 += (buffAndDebuffList[i].dodge + buffObjectList[i].GetComponent<EnemyUI>().ap * buffAndDebuffList[i].skillFactor);
             //buffDodgePCT2 += (buffAndDebuffList[i].dodgePCT+ buffObjectList[i].GetComponent<EnemyUI>().iq * buffAndDebuffList[i].skillFactor * buffAndDebuffList[i].dodgePCT);
             buffCrit2 += (buffAndDebuffList[i].crit + buffObjectList[i].GetComponent<EnemyUI>().ap * buffAndDebuffList[i].skillFactor);
             //buffCritPCT2 += (buffAndDebuffList[i].critPCT + buffObjectList[i].GetComponent<EnemyUI>().iq * buffAndDebuffList[i].skillFactor * buffAndDebuffList[i].critPCT);
             buffIq2 += (buffAndDebuffList[i].iq + buffObjectList[i].GetComponent<EnemyUI>().ap * buffAndDebuffList[i].skillFactor);
             buffIqPCT2 += (buffAndDebuffList[i].iqPCT + buffObjectList[i].GetComponent<EnemyUI>().iq * buffAndDebuffList[i].skillFactor);
             buffCharm2 += (buffAndDebuffList[i].charm + buffObjectList[i].GetComponent<EnemyUI>().ap * buffAndDebuffList[i].skillFactor);
             buffCharmPCT2 += (buffAndDebuffList[i].charmPCT + buffObjectList[i].GetComponent<EnemyUI>().ap * buffAndDebuffList[i].skillFactor);
             buffCritDamge2 += (buffAndDebuffList[i].critDamge + buffObjectList[i].GetComponent<EnemyUI>().iq * buffAndDebuffList[i].skillFactor);
            // buffCritDamgePCT2 += (buffAndDebuffList[i].critDamgePCT + buffObjectList[i].GetComponent<EnemyUI>().iq * buffAndDebuffList[i].skillFactor * buffAndDebuffList[i].critDamgePCT);
             buffDrainLife2 += (buffAndDebuffList[i].drainLife + buffObjectList[i].GetComponent<EnemyUI>().ap * buffAndDebuffList[i].skillFactor);
             //buffDrainLifePCT2 += (buffAndDebuffList[i].drainLifePCT + buffObjectList[i].GetComponent<EnemyUI>().iq * buffAndDebuffList[i].skillFactor * buffAndDebuffList[i].drainLifePCT);
             buffReplyHp2 += (buffAndDebuffList[i].replyHp + buffObjectList[i].GetComponent<EnemyUI>().ap * buffAndDebuffList[i].skillFactor);
             buffReplyHpPCT2 += (buffAndDebuffList[i].replyHpPCT + buffObjectList[i].GetComponent<EnemyUI>().iq * buffAndDebuffList[i].skillFactor);
             buffReplyMp2 += (buffAndDebuffList[i].replyMp + buffObjectList[i].GetComponent<EnemyUI>().ap * buffAndDebuffList[i].skillFactor);
             buffReplyMpPCT2 += (buffAndDebuffList[i].replyMpPCT + buffObjectList[i].GetComponent<EnemyUI>().iq * buffAndDebuffList[i].skillFactor);
             buffReplySp2 += (buffAndDebuffList[i].replySp + buffObjectList[i].GetComponent<EnemyUI>().ap * buffAndDebuffList[i].skillFactor);
             buffReplySpPCT2 += (buffAndDebuffList[i].replySpPCT + buffObjectList[i].GetComponent<EnemyUI>().iq * buffAndDebuffList[i].skillFactor);
             buffSkillOdds2 += buffAndDebuffList[i].skillOdds;
             buffSword2 += buffAndDebuffList[i].sword;
             buffGun2 += buffAndDebuffList[i].gun;
             }
        }
    }
     buffTotalhp = buffTotalhp1 + buffTotalhp2;
     buffTotalhpPCT = buffTotalhpPCT1 + buffTotalhpPCT2;
     buffTotalmp = buffTotalmp1 + buffTotalmp2;
     buffTotalmpPCT = buffTotalmpPCT1 + buffTotalmpPCT2;
     buffTotalsp = buffTotalsp1 + buffTotalsp2;
     buffTotalspPCT = buffTotalspPCT1 + buffTotalspPCT2;
     buffAd = buffAd1 + buffAd2;
     buffAdPCT = buffAdPCT1 + buffAdPCT2;
     buffAp = buffAp1 + buffAp2;
     buffApPCT = buffApPCT1 + buffApPCT2;
     buffDef = buffDef1 + buffDef2;
     buffDefPCT = buffDefPCT1 + buffDefPCT2;
     buffMdef = buffMdef1 + buffMdef2;
     buffMdefPCT = buffMdefPCT1 + buffMdefPCT2;
     buffSpeed = buffSpeed1 + buffSpeed2;
     buffSpeedPCT = buffSpeedPCT1 + buffSpeedPCT2;
     buffDodge =buffDodge1 + buffDodge2;
     //buffDodgePCT = buffDodgePCT1 + buffDodgePCT2;
     buffCrit = buffCrit1 + buffCrit2;
     //buffCritPCT = buffCritPCT1 + buffCritPCT2;
     buffIq = buffIq1 + buffIq2;
     buffIqPCT = buffIqPCT1 + buffIqPCT2;
     buffCharm = buffCharm1 + buffCharm2;
     buffCharmPCT = buffCharmPCT1 + buffCharmPCT2;
     buffCritDamge = buffCritDamge1 + buffCritDamge2;
     //buffCritDamgePCT = buffCritDamgePCT1 + buffCritDamgePCT2;
     buffDrainLife = buffDrainLife1 + buffDrainLife2;
     //buffDrainLifePCT = buffDrainLifePCT1 + buffDrainLifePCT2;
     buffReplyHp = buffReplyHp1 + buffReplyHp2;
     buffReplyHpPCT = buffReplyHpPCT1 + buffReplyHpPCT2;
     buffReplyMp = buffReplyMp1 + buffReplyMp2;
     buffReplyMpPCT = buffReplyMpPCT1 + buffReplyMpPCT2;
     buffReplySp = buffReplySp1 + buffReplySp2;
     buffReplySpPCT = buffReplySpPCT1 + buffReplySpPCT2;
     buffSword = buffSword1 + buffSword2;
     buffSkillOdds = buffSkillOdds1 + buffSkillOdds2;
     buffGun = buffGun1 + buffGun2;

     for (int i = 0; i < buffTime.Count; i++)
       {
           if(buffTime[i] == 0)
           {
               buffAndDebuffList[i] = null;//清除buff
               buffObjectList[i] = null;
           }
       }

}
public void Action()//行动机制
{
    Sword();
    Gun();
    Shield();
    Book();
    Fuwen();
    Zhoushu();
    int skillNum = Random.Range(0, 100);
    if(skillNum > skillOdds)
    {
      Attack();
      End();

    }
    if(skillNum <= skillOdds)
    {
      Skill();
      End();
    }


}
public void Attack()
{ 
    //Debug.Log("111");
    
    if(!disarm && sp >= 10)
    {
        sp -= 10;
    int attackNum = Random.Range(0, 100);
    if (attackNum >= targetEnemyUnit.GetComponent<PlayerBattle>().player.dodge)
    {
       Damage();
       EndSkill();


    }
    if (attackNum < targetEnemyUnit.GetComponent<PlayerBattle>().player.dodge)
    {
        //End();
    }
    }
}
public void Sword()//剑意机制
{
     swordMax += sword;
        if(swordMax >= 23)
        {
            swordMax = 0;
            for (int i = 0; i < buffAndDebuffList.Count; i++)
            {
                if(buffAndDebuffList[i] == null)
                {
                    buffTime[i] = buffList.buffList[0].buffTime;
                    buffObjectList[i] = gameObject;
                    buffAndDebuffList[i] = buffList.buffList[0];
                    //buffTime[i] = buffList.buffList[0].buffTime;
                    //buffObjectList[i] = gameObject;
                    break;
                }
            }
        }
}
public void Gun()//枪械机制
{
    targetEnemyUnit.GetComponent<PlayerBattle>().player.hp -= gun * (ad + ap);
    hp += (gun * (ad + ap)) * drainLife;

    for (int i = 0; i < damageList.Count; i++)
    {
        if(damageList[i] == 0)
        {
            damageList[i] = gun * (ad + ap);
            break;
        }
    }

}
public void Shield()//盾防机制
{
    for (int i = 0; i < equipmentList.Count; i++)
    {   if(equipmentList[i] != null)
      {
        if(equipmentList[i].shieldFactor != 0)
        {
          for (int j = 0; j < buffAndDebuffList.Count; j++)
          {
              if(buffAndDebuffList[j] == null)
              {
                  buffTime[j] = buffList.buffList[equipmentList[i].shieldFactor].buffTime;
                  buffObjectList[j] = gameObject;
                  buffAndDebuffList[j] = buffList.buffList[equipmentList[i].shieldFactor];
                 // buffTime[j] = buffList.buffList[equipmentList[i].shieldFactor].buffTime;
                 //buffObjectList[j] = gameObject;
                  break;
              }
          }
        }
      }
    }
   
}
public void Book()
{
    for (int i = 0; i < equipmentList.Count; i++)
    {
        if(equipmentList[i] != null)
        {
            if(equipmentList[i].weaponClass == "book")
            {
                if(mp >= 30)
                {
                    mp -= 30;
                    Skill();
                }
            }
        }
    }
}
public void Fuwen()
{
   for (int i = 0; i < equipmentList.Count; i++)
    {
        if(equipmentList[i] != null)
        {
            if(equipmentList[i].weaponClass == "fuwen")
            {
                int number = Random.Range(6, 9);
                { 
                    for (int j = 0; j < buffAndDebuffList.Count; j++)
                    {
                        if(buffAndDebuffList[j] == null)
                        {
                            buffTime[j] = buffList.buffList[number].buffTime;
                            buffObjectList[j] = gameObject;
                            buffAndDebuffList[j] = buffList.buffList[number];
                            //buffTime[j] = buffList.buffList[number].buffTime;
                            //buffObjectList[j] = gameObject;
                            break;
                        }
                    }
                    for (int j = 0; j < targetPlayerUnit.GetComponent<EnemyUI>().buffAndDebuffList.Count; j++)
                    {
                        if(targetPlayerUnit.GetComponent<EnemyUI>().buffAndDebuffList[j] == null)
                        {   
                            targetPlayerUnit.GetComponent<EnemyUI>().buffTime[j] = buffList.buffList[number].buffTime;
                            targetPlayerUnit.GetComponent<EnemyUI>().buffObjectList[j] = gameObject;                    
                            targetPlayerUnit.GetComponent<EnemyUI>().buffAndDebuffList[j] = buffList.buffList[number];
                            //targetPlayerUnit.GetComponent<TeamPlayer>().buffTime[j] = buffList.buffList[number].buffTime;
                            //targetPlayerUnit.GetComponent<TeamPlayer>().buffObjectList[j] = gameObject;
                            break;
                        }
                    }
                }
            }
        }
    }
}
public void Zhoushu()
{
    for (int i = 0; i < equipmentList.Count; i++)
    {
        if(equipmentList[i] != null)
        {
            if(equipmentList[i].weaponClass == "zhoushu")
            {
                int number = Random.Range(11, 14);
                { 
                    for (int j = 0; j < targetEnemyUnit.GetComponent<PlayerBattle>().player.buffAndDebuffList.Count; j++)
                    {
                        if(targetEnemyUnit.GetComponent<PlayerBattle>().player.buffAndDebuffList[j] == null)
                        { 
                            targetEnemyUnit.GetComponent<PlayerBattle>().player.buffTime[j] = buffList.buffList[number].buffTime;
                            targetEnemyUnit.GetComponent<PlayerBattle>().player.buffObjectList[j] = gameObject;                   
                            targetEnemyUnit.GetComponent<PlayerBattle>().player.buffAndDebuffList[j] = buffList.buffList[number];
                            //targetPlayerUnit.GetComponent<PlayerBattle>().player.buffTime[j] = buffList.buffList[number].buffTime;
                            //targetPlayerUnit.GetComponent<PlayerBattle>().player.buffObjectList[j] = gameObject;
                            break;
                        }
                    }
                }
            }
        }
    }
}
public void Damage()//伤害机制
{
   int critNumber = Random.Range(0, 100);
        if(critNumber > crit)
        {  
           targetEnemyUnit.GetComponent<PlayerBattle>().player.hp -= (ad - targetEnemyUnit.GetComponent<PlayerBattle>().player.def); 
           for (int m = 0; m < damageList.Count; m++)
           {
                  if(damageList[m] == 0)
                {
                   damageList[m] = (ad - targetEnemyUnit.GetComponent<PlayerBattle>().player.def);
                   break;
                }
           }   
        }
        if(critNumber <= crit)
        {  
           targetEnemyUnit.GetComponent<PlayerBattle>().player.hp -= ((ad - targetEnemyUnit.GetComponent<PlayerBattle>().player.def) * (1.0f + critDamge));
           for (int m = 0; m < damageList.Count; m++)
           {
                  if(damageList[m] == 0)
                {
                   damageList[m] = ((ad - targetEnemyUnit.GetComponent<PlayerBattle>().player.def) * (1.0f + critDamge));
                   break;
                }
           }

        }
   
}

public void Skill()//主动技能
{

for (int i = 0; i < skillList.Count; i++)
    { 
        int targetSkillID;
        targetSkillID = Random.Range(0 , skillList.Count);
        if(skillList[targetSkillID] == null)
        {
            continue;
        }
        if(skillList[targetSkillID] != null)
        {
            if(skillList[targetSkillID].activeSkill)
            {      
                 if(mp >= skillList[targetSkillID].mp && sp >= skillList[targetSkillID].sp && hp >= skillList[targetSkillID].hp )
                {
                   mp -= skillList[targetSkillID].mp;
                   sp -= skillList[targetSkillID].sp;
                   hp -= skillList[targetSkillID].hp;
                
                   if(skillList[targetSkillID].singleDamage)//单体伤害技能
                   {
                    if(skillList[targetSkillID].adSkill)
                    {  
                       targetEnemyUnit.GetComponent<PlayerBattle>().player.hp -= ((ad * skillList[targetSkillID].adSkillFactor) - targetEnemyUnit.GetComponent<PlayerBattle>().player.def);
                      for (int n = 0; n < damageList.Count; n++)
                       {
                           if(damageList[n] == 0)
                           {
                               damageList[n] = ((ad * skillList[targetSkillID].adSkillFactor) - targetEnemyUnit.GetComponent<PlayerBattle>().player.def);
                               break;
                           }
                       }
    
                       break;
                    }
                    if(skillList[targetSkillID].hpSkill)
                    {  
                       targetEnemyUnit.GetComponent<PlayerBattle>().player.hp -= ((totalhp * skillList[targetSkillID].hpSkillFactor) - targetEnemyUnit.GetComponent<PlayerBattle>().player.def);
                       for (int n = 0; n < damageList.Count; n++)
                       {
                           if(damageList[n] == 0)
                           {
                               damageList[n] = ((totalhp * skillList[targetSkillID].hpSkillFactor) - targetEnemyUnit.GetComponent<PlayerBattle>().player.def);
                               break;
                           }
                       }
    
                       break;
                    }
                    if(skillList[targetSkillID].apSkill)
                    {  
                       
                       targetEnemyUnit.GetComponent<PlayerBattle>().player.hp -= ((ap * skillList[targetSkillID].apSkillFactor) - targetEnemyUnit.GetComponent<PlayerBattle>().player.mdef);
                       for (int m = 0; m < damageList.Count; m++)
                       {
                         if(damageList[m] == 0)
                         {
                            damageList[m] = ((ap * skillList[targetSkillID].apSkillFactor) - targetEnemyUnit.GetComponent<PlayerBattle>().player.mdef);
                            break;
                         }
                       }
                       break; 
                    }
                    if(skillList[targetSkillID].iqSkill)
                    {  
                       
                       targetEnemyUnit.GetComponent<PlayerBattle>().player.hp -= ((iq * skillList[targetSkillID].iqSkillFactor) - targetEnemyUnit.GetComponent<PlayerBattle>().player.mdef);
                       for (int m = 0; m < damageList.Count; m++)
                       {
                         if(damageList[m] == 0)
                         {
                            damageList[m] = ((iq * skillList[targetSkillID].iqSkillFactor) - targetEnemyUnit.GetComponent<PlayerBattle>().player.mdef);
                            break;
                         }
                       }
                       break; 
                    }
                   }
                   if(skillList[targetSkillID].teamDamage)//群体伤害技能
                   {
                    if(skillList[targetSkillID].adSkill)
                    {  
                       for (int j = 0; j < targetEnemyUnitList.Count; j++)
                       {  
                           
                           targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.hp -= ((ad * skillList[targetSkillID].adSkillFactor) - targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.def);
                
                           targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.targetUnit = gameObject;
                           for (int m = 0; m < damageList.Count; m++)
                          {
                              if(damageList[m] == 0)
                            { 
                               damageList[m] = ((ad * skillList[targetSkillID].adSkillFactor) - targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.def);
                               break;
                            }
                          }
                       }
                       break;
                    }
                    if(skillList[targetSkillID].hpSkill)
                    {  
                       for (int j = 0; j < targetEnemyUnitList.Count; j++)
                       {  
                           
                           targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.hp -= ((totalhp * skillList[targetSkillID].hpSkillFactor) - targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.def);
                
                           targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.targetUnit = gameObject;
                          for (int m = 0; m < damageList.Count; m++)
                          {
                              if(damageList[m] == 0)
                            { 
                               damageList[m] = ((totalhp * skillList[targetSkillID].hpSkillFactor) - targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.def);
                               break;
                            }
                          }
                       }
                       break;
                    }
                    if(skillList[targetSkillID].apSkill)
                    {
                        for (int j = 0; j < targetEnemyUnitList.Count; j++)
                       {                          
                           targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.hp -= ((ap * skillList[targetSkillID].apSkillFactor) - targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.mdef);
                           targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.targetUnit = gameObject;
                           for (int m = 0; m < damageList.Count; m++)
                          {
                              if(damageList[m] == 0)
                             { 
                               damageList[m] = ((ap * skillList[targetSkillID].apSkillFactor) - targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.mdef);
                               break;
                            }
                          }
                          
                       }
                       break;
                    }
                    if(skillList[targetSkillID].iqSkill)
                    {
                        for (int j = 0; j < targetEnemyUnitList.Count; j++)
                       {                          
                           targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.hp -= ((iq * skillList[targetSkillID].iqSkillFactor) - targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.mdef);
                           targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.targetUnit = gameObject;
                           for (int m = 0; m < damageList.Count; m++)
                          {
                              if(damageList[m] == 0)
                             { 
                               damageList[m] = ((iq * skillList[targetSkillID].iqSkillFactor) - targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.mdef);
                               break;
                            }
                          }
                       }
                       break;
                    }
                   }
                   if(skillList[targetSkillID].singleDebuff && !skillList[targetSkillID].dizzy)//单体debuff
                   {
                         for (int j = 0; j < targetEnemyUnit.GetComponent<PlayerBattle>().player.buffAndDebuffList.Count ; j++)
                         {
                             if(targetEnemyUnit.GetComponent<PlayerBattle>().player.buffAndDebuffList[j] == null)
                             {
                              targetEnemyUnit.GetComponent<PlayerBattle>().player.buffObjectList[j] = gameObject;
                              targetEnemyUnit.GetComponent<PlayerBattle>().player.buffTime[j] = skillList[targetSkillID].buff.buffTime;
                              targetEnemyUnit.GetComponent<PlayerBattle>().player.buffAndDebuffList[j] = skillList[targetSkillID].buff;
                              //targetEnemyUnit.GetComponent<PlayerBattle>().player.buffTime[j] = skillList[targetSkillID].buff.buffTime;
                              //targetEnemyUnit.GetComponent<PlayerBattle>().player.buffObjectList[j] = gameObject;
                              break;
                             }
                         }
                     break;
                   }
                   if(skillList[targetSkillID].singleDebuff && skillList[targetSkillID].dizzy)//单体眩晕
                   {
                    if(charm >= targetEnemyUnit.GetComponent<PlayerBattle>().player.charm)
                    {  
                        for (int j = 0; j < targetEnemyUnit.GetComponent<PlayerBattle>().player.buffAndDebuffList.Count ; j++)
                       {
                           if(targetEnemyUnit.GetComponent<PlayerBattle>().player.buffAndDebuffList[j] == null)
                           {
                            targetEnemyUnit.GetComponent<PlayerBattle>().player.buffTime[j] = buffList.buffList[10].buffTime;
                            targetEnemyUnit.GetComponent<PlayerBattle>().player.buffObjectList[j] = gameObject;
                            targetEnemyUnit.GetComponent<PlayerBattle>().player.buffAndDebuffList[j] = buffList.buffList[10];
                            //targetEnemyUnit.GetComponent<PlayerBattle>().player.buffTime[j] = buffList.buffList[10].buffTime;
                            //targetEnemyUnit.GetComponent<PlayerBattle>().player.buffObjectList[j] = gameObject;
                            break;
                            }
                        }
                        break;
                     }
                     if(charm < targetEnemyUnit.GetComponent<PlayerBattle>().player.charm)
                    {
                      break;
                    }
                   }
                   if(skillList[targetSkillID].teamDebuff && !skillList[targetSkillID].dizzy)//群体debuff
                   {
                    for (int j = 0; j < targetEnemyUnitList.Count; j++)
                    {
                        if(targetEnemyUnitList[j] != null)
                        {
                            for (int k = 0; k < targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffAndDebuffList.Count; k++)
                            {
                                if(targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffAndDebuffList == null)
                                {
                                    targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffTime[k] = skillList[targetSkillID].buff.buffTime;
                                    targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffObjectList[k] = gameObject;
                                    targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffAndDebuffList[k] = skillList[targetSkillID].buff;
                                    //targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffTime[k] = skillList[targetSkillID].buff.buffTime;
                                    //targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffObjectList[k] = gameObject;
                                    break;
                                }
                            }
                        }
                    }
                    break;

                   }
                   if(skillList[targetSkillID].teamDebuff && skillList[targetSkillID].dizzy)//群体眩晕
                   {
                    for (int j = 0; j < targetEnemyUnitList.Count; j++)
                    {
                        if(targetEnemyUnitList[j] != null)
                        {  
                            if(charm >= targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.charm)
                            {
                            for (int k = 0; k < targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffAndDebuffList.Count; k++)
                                 { 
                                     if(targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffAndDebuffList == null)
                                    {
                                       targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffTime[k] = buffList.buffList[10].buffTime;
                                       targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffObjectList[k] = gameObject;
                                       targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffAndDebuffList[k] = buffList.buffList[10];
                                       //targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffTime[k] = buffList.buffList[10].buffTime;
                                       //targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffObjectList[k] = gameObject;
                                       break;
                                    }
                                }
                            }
                            if(charm <targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.charm)
                            {
                                continue;
                            }
                        }
                    }
                    break;

                   }
                   if(skillList[targetSkillID].singleBuff)//队友buff
                   {
                    for (int j = 0; j < targetPlayerUnit.GetComponent<EnemyUI>().buffAndDebuffList.Count; j++)
                    {
                        if(targetPlayerUnit.GetComponent<EnemyUI>().buffAndDebuffList[j] == null)
                        {
                           targetPlayerUnit.GetComponent<EnemyUI>().buffTime[j] = skillList[targetSkillID].buff.buffTime;
                           targetPlayerUnit.GetComponent<EnemyUI>().buffObjectList[j] = gameObject;
                           targetPlayerUnit.GetComponent<EnemyUI>().buffAndDebuffList[j] = skillList[targetSkillID].buff;
                           //targetPlayerUnit.GetComponent<PlayerBattle>().player.buffTime[j] = skillList[targetSkillID].buff.buffTime;
                           //targetPlayerUnit.GetComponent<PlayerBattle>().player.buffObjectList[j] = gameObject;
                           break;
                        }
                    }
                    break;
                   
                   }
                   if(skillList[targetSkillID].ownBuff)//单体buff
                   {
                    for (int j = 0; j < buffAndDebuffList.Count; j++)
                    {
                        buffTime[j] = skillList[targetSkillID].buff.buffTime;
                        buffObjectList[j] = gameObject;
                        buffAndDebuffList[j] = skillList[targetSkillID].buff;
                        //buffTime[j] = skillList[targetSkillID].buff.buffTime;
                        //buffObjectList[j] = gameObject;
                        break;
                    }
                    break;
                   }
                   if(skillList[targetSkillID].teamBuff)//团队buff
                   {
                    for (int j = 0; j < targetPlayerUnitList.Count; j++)
                    {
                        if(targetPlayerUnitList[j] != null)
                        {
                            for (int k = 0; k < targetPlayerUnitList[j].GetComponent<EnemyUI>().buffAndDebuffList.Count; k++)
                            {
                                if(targetPlayerUnitList[j].GetComponent<EnemyUI>().buffAndDebuffList[k] == null)
                                {
                                    targetPlayerUnitList[j].GetComponent<EnemyUI>().buffTime[k] = skillList[targetSkillID].buff.buffTime;
                                    targetPlayerUnitList[j].GetComponent<EnemyUI>().buffObjectList[k] = gameObject;
                                    targetPlayerUnitList[j].GetComponent<EnemyUI>().buffAndDebuffList[k] = skillList[targetSkillID].buff;
                                    //targetPlayerUnitList[j].GetComponent<PlayerBattle>().player.buffTime[k] = skillList[targetSkillID].buff.buffTime;
                                    //targetPlayerUnitList[j].GetComponent<PlayerBattle>().player.buffObjectList[k] = gameObject;
                                    break;
                                }
                            }
                        }
                    }
                    break;
                   }
                
                }
                  if(mp < skillList[targetSkillID].mp || sp < skillList[targetSkillID].sp || hp < skillList[targetSkillID].hp)
                 {
                 Attack();
                 break;
                 }
            }
        }
    }
}
public void EndSkill()//被动技能
{
    for (int i = 0; i < skillList.Count; i++)
    {
        if(skillList[i] != null)
        {
            if(skillList[i].endSkill)
            {
                    int endSkillNum;
                    endSkillNum = Random.Range(0, 100);
                    if((endSkillNum - (charm * 0.003)) <= skillList[i].endSkillOdd)
                {
                    if(skillList[i].teamDamage)//群体伤害技能
                   {
                    if(skillList[i].adSkill)
                    {  
                       for (int j = 0; j < targetEnemyUnitList.Count; j++)
                       {  
                           
                           targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.hp -= ((ad * skillList[i].adSkillFactor) - targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.def);
                
                           targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.targetUnit = gameObject;
                           for (int m = 0; m < damageList.Count; m++)
                          {
                              if(damageList[m] == 0)
                            { 
                               damageList[m] = ((ad * skillList[i].adSkillFactor) - targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.def);
                               break;
                            }
                          }
                       }
                    }
                    if(skillList[i].hpSkill)
                    {  
                       for (int j = 0; j < targetEnemyUnitList.Count; j++)
                       {  
                           
                           targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.hp -= ((totalhp * skillList[i].hpSkillFactor) - targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.def);
                
                           targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.targetUnit = gameObject;
                           for (int m = 0; m < damageList.Count; m++)
                          {
                              if(damageList[m] == 0)
                            { 
                               damageList[m] = ((totalhp * skillList[i].hpSkillFactor) - targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.def);
                               break;
                            }
                          }
                       }
                    }
                    if(skillList[i].apSkill)
                    {
                        for (int j = 0; j < targetEnemyUnitList.Count; j++)
                       {                          
                           targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.hp -= ((ap * skillList[i].apSkillFactor) - targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.mdef);
                           targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.targetUnit = gameObject;
                            for (int m = 0; m < damageList.Count; m++)
                          {
                              if(damageList[m] == 0)
                             { 
                               damageList[m] = ((ap * skillList[i].apSkillFactor) - targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.mdef);
                               break;
                            }
                          }
                          
                       }
                    }
                    if(skillList[i].iqSkill)
                    {
                        for (int j = 0; j < targetEnemyUnitList.Count; j++)
                       {                          
                           targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.hp -= ((iq * skillList[i].iqSkillFactor) - targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.mdef);
                           targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.targetUnit = gameObject;
                           for (int m = 0; m < damageList.Count; m++)
                          {
                              if(damageList[m] == 0)
                             { 
                               damageList[m] = ((iq * skillList[i].iqSkillFactor) - targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.mdef);
                               break;
                            }
                          }
                       }
                    }
                   }
                   if(skillList[i].singleDebuff && !skillList[i].dizzy)//单体debuff
                   {
                         for (int j = 0; j < targetEnemyUnit.GetComponent<PlayerBattle>().player.buffAndDebuffList.Count ; j++)
                         {
                             if(targetEnemyUnit.GetComponent<PlayerBattle>().player.buffAndDebuffList[j] == null)
                             {
                              targetEnemyUnit.GetComponent<PlayerBattle>().player.buffTime[j] = skillList[i].buff.buffTime;
                              targetEnemyUnit.GetComponent<PlayerBattle>().player.buffObjectList[j] = gameObject;
                              targetEnemyUnit.GetComponent<PlayerBattle>().player.buffAndDebuffList[j] = skillList[i].buff;
                              //targetEnemyUnit.GetComponent<PlayerBattle>().player.buffTime[j] = skillList[i].buff.buffTime;
                              //targetEnemyUnit.GetComponent<PlayerBattle>().player.buffObjectList[j] = gameObject;
                              break;
                             }
                         }
                   }
                   if(skillList[i].singleDebuff &&skillList[i].dizzy)//单体眩晕
                   {    
                      for (int j = 0; j < targetEnemyUnit.GetComponent<PlayerBattle>().player.buffAndDebuffList.Count; j++)
                         {  
                            if(targetEnemyUnit.GetComponent<PlayerBattle>().player.buffAndDebuffList[j] == null)
                            {
                            targetEnemyUnit.GetComponent<PlayerBattle>().player.buffTime[j] = buffList.buffList[10].buffTime;
                            targetEnemyUnit.GetComponent<PlayerBattle>().player.buffObjectList[j] = gameObject;
                            targetEnemyUnit.GetComponent<PlayerBattle>().player.buffAndDebuffList[j] = buffList.buffList[10];
                            //targetEnemyUnit.GetComponent<PlayerBattle>().player.buffTime[j] = buffList.buffList[10].buffTime;
                            //targetEnemyUnit.GetComponent<PlayerBattle>().player.buffObjectList[j] = gameObject;
                            break;
                            }
                         }
                   }
                   if(skillList[i].teamDebuff && !skillList[i].dizzy)//群体debuff
                   {
                    for (int j = 0; j < targetEnemyUnitList.Count; j++)
                    {
                        if(targetEnemyUnitList[j] != null)
                        {
                            for (int k = 0; k < targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffAndDebuffList.Count; k++)
                            {
                                if(targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffAndDebuffList == null)
                                {
                                    targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffTime[k] = skillList[i].buff.buffTime;
                                    targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffObjectList[k] = gameObject;
                                    targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffAndDebuffList[k] = skillList[i].buff;
                                    //targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffTime[k] = skillList[i].buff.buffTime;
                                    //targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffObjectList[k] = gameObject;
                                    break;
                                }
                            }
                        }
                    }
                   }
                   if(skillList[i].ownBuff)//单体buff
                   {
                    for (int j = 0; j < buffAndDebuffList.Count; j++)
                    {
                        buffTime[j] = skillList[i].buff.buffTime;
                        buffObjectList[j] = gameObject;
                        buffAndDebuffList[j] = skillList[i].buff;
                        //buffTime[j] = skillList[i].buff.buffTime;
                        //buffObjectList[j] = gameObject;
                        break;
                    }
                   }
                   if(skillList[i].teamBuff)//团队buff
                   {
                    for (int j = 0; j < targetPlayerUnitList.Count; j++)
                    {
                        if(targetPlayerUnitList[j] != null)
                        {
                            for (int k = 0; k < targetPlayerUnitList[j].GetComponent<EnemyUI>().buffAndDebuffList.Count; k++)
                            {
                                if(targetPlayerUnitList[j].GetComponent<EnemyUI>().buffAndDebuffList[k] == null)
                                {
                                    targetPlayerUnitList[j].GetComponent<EnemyUI>().buffTime[k] = skillList[i].buff.buffTime;
                                    targetPlayerUnitList[j].GetComponent<EnemyUI>().buffObjectList[k] = gameObject;
                                    targetPlayerUnitList[j].GetComponent<EnemyUI>().buffAndDebuffList[k] = skillList[i].buff;
                                    //targetPlayerUnitList[j].GetComponent<PlayerBattle>().player.buffTime[k] = skillList[i].buff.buffTime;
                                    //targetPlayerUnitList[j].GetComponent<PlayerBattle>().player.buffObjectList[k] = gameObject;
                                    break;
                                }
                            }
                        }
                    }
                   }
                }
                if((endSkillNum - (charm * 0.003)) > skillList[i].endSkillOdd)
                {
                    continue;
                }
            }
        }
    }
    
}
public void End()
{
    for (int i = 0; i < skillList.Count; i++)
    { 
        if(skillList[i] != null)
        {
            if(skillList[i].turnSkill)
            {        
                if(skillList[i].singleDamage)//单体伤害技能
                {
                    if(skillList[i].adSkill)
                    {  
                       targetEnemyUnit.GetComponent<PlayerBattle>().player.hp -= ((ad * skillList[i].adSkillFactor) - targetEnemyUnit.GetComponent<PlayerBattle>().player.def);
                       targetEnemyUnit.GetComponent<PlayerBattle>().player.targetUnit = gameObject;
                       for (int n = 0; n < damageList.Count; n++)
                       {
                           if(damageList[n] == 0)
                           {
                               damageList[n] = ((ad * skillList[i].adSkillFactor) - targetEnemyUnit.GetComponent<PlayerBattle>().player.def);
                               break;
                           }
                       }          
                    }
                    if(skillList[i].hpSkill)
                    {  
                       targetEnemyUnit.GetComponent<PlayerBattle>().player.hp -= ((totalhp * skillList[i].hpSkillFactor) - targetEnemyUnit.GetComponent<PlayerBattle>().player.def);
                       targetEnemyUnit.GetComponent<PlayerBattle>().player.targetUnit = gameObject;
                       for (int n = 0; n < damageList.Count; n++)
                       {
                           if(damageList[n] == 0)
                           {
                               damageList[n] = ((totalhp * skillList[i].hpSkillFactor) - targetEnemyUnit.GetComponent<PlayerBattle>().player.def);
                               break;
                           }
                       }           
                    }
                    if(skillList[i].apSkill)
                    {  
                       targetEnemyUnit.GetComponent<PlayerBattle>().player.hp -= ((ap * skillList[i].apSkillFactor) - targetEnemyUnit.GetComponent<PlayerBattle>().player.mdef);
                       targetEnemyUnit.GetComponent<PlayerBattle>().player.targetUnit = gameObject;
                       for (int m = 0; m < damageList.Count; m++)
                       {
                         if(damageList[m] == 0)
                         {
                            damageList[m] = ((ap * skillList[i].apSkillFactor) - targetEnemyUnit.GetComponent<PlayerBattle>().player.mdef);
                            break;
                         }
                       } 
                    }
                    if(skillList[i].iqSkill)
                    {  
                       targetEnemyUnit.GetComponent<PlayerBattle>().player.hp -= ((iq * skillList[i].iqSkillFactor) - targetEnemyUnit.GetComponent<PlayerBattle>().player.mdef);
                       targetEnemyUnit.GetComponent<PlayerBattle>().player.targetUnit = gameObject;
                       for (int m = 0; m < damageList.Count; m++)
                       {
                         if(damageList[m] == 0)
                         {
                            damageList[m] = ((iq * skillList[i].iqSkillFactor) - targetEnemyUnit.GetComponent<PlayerBattle>().player.mdef);
                            break;
                         }
                       } 
                    }
                }
                if(skillList[i].teamDamage)//群体伤害技能
                {
                    if(skillList[i].adSkill)
                    {  
                       for (int j = 0; j < targetEnemyUnitList.Count; j++)
                       {  
                           targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.hp -= ((ad * skillList[i].adSkillFactor) - targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.def);
                           targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.targetUnit = gameObject;
                           for (int m = 0; m < damageList.Count; m++)
                          {
                              if(damageList[m] == 0)
                            { 
                               damageList[m] = ((ad * skillList[i].adSkillFactor) - targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.def);
                               break;
                            }
                          }
                       }
                    }
                    if(skillList[i].hpSkill)
                    {  
                       for (int j = 0; j < targetEnemyUnitList.Count; j++)
                       {  
                           targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.hp -= ((totalhp * skillList[i].hpSkillFactor) - targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.def);
                           targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.targetUnit = gameObject;
                           for (int m = 0; m < damageList.Count; m++)
                          {
                              if(damageList[m] == 0)
                            { 
                               damageList[m] = ((totalhp * skillList[i].hpSkillFactor) - targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.def);
                               break;
                            }
                          }
                       }
                    }
                    if(skillList[i].apSkill)
                    {
                        for (int j = 0; j < targetEnemyUnitList.Count; j++)
                       {                          
                           targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.hp -= ((ap * skillList[i].apSkillFactor) - targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.mdef);
                           targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.targetUnit = gameObject;
                            for (int m = 0; m < damageList.Count; m++)
                           {
                              if(damageList[m] == 0)
                             { 
                               damageList[m] = ((ap * skillList[i].apSkillFactor) - targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.mdef);
                               break;
                            }
                          }
                           
                       }

                    }
                    if(skillList[i].iqSkill)
                    {
                        for (int j = 0; j < targetEnemyUnitList.Count; j++)
                       {                          
                           targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.hp -= ((iq * skillList[i].iqSkillFactor) - targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.mdef);
                           targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.targetUnit = gameObject;
                            for (int m = 0; m < damageList.Count; m++)
                           {
                              if(damageList[m] == 0)
                             { 
                               damageList[m] = ((iq * skillList[i].iqSkillFactor) - targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.mdef);
                               break;
                            }
                          }
                           
                       }

                    }

                }
                if(skillList[i].singleDebuff)//单体debuff
                {
                   for (int j = 0; j < targetEnemyUnit.GetComponent<PlayerBattle>().player.buffAndDebuffList.Count ; j++)
                   {
                       if(targetEnemyUnit.GetComponent<PlayerBattle>().player.buffAndDebuffList[j] == null)
                       {
                           targetEnemyUnit.GetComponent<PlayerBattle>().player.buffTime[j] = skillList[i].buff.buffTime;
                           targetEnemyUnit.GetComponent<PlayerBattle>().player.buffObjectList[j] = gameObject;
                           targetEnemyUnit.GetComponent<PlayerBattle>().player.buffAndDebuffList[j] = skillList[i].buff;
                           //targetEnemyUnit.GetComponent<PlayerBattle>().player.buffTime[j] = skillList[i].buff.buffTime;
                           //targetEnemyUnit.GetComponent<PlayerBattle>().player.buffObjectList[j] = gameObject;
                           break;
                       }
                   }
                }             
                if(skillList[i].teamDebuff)//群体debuff
                {
                    for (int j = 0; j < targetEnemyUnitList.Count; j++)
                    {
                        if(targetEnemyUnitList[j] != null)
                        {
                            for (int k = 0; k < targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffAndDebuffList.Count; k++)
                            {
                                if(targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffAndDebuffList == null)
                                {
                                    targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffTime[k] = skillList[i].buff.buffTime;
                                    targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffObjectList[k] = gameObject;
                                    targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffAndDebuffList[k] = skillList[i].buff;
                                    //targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffTime[k] = skillList[i].buff.buffTime;
                                    //targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffObjectList[k] = gameObject;
                                    break;
                                }
                            }
                        }
                    }

                }
                if(skillList[i].singleBuff)//队友buff
                {
                    for (int j = 0; j < targetPlayerUnit.GetComponent<EnemyUI>().buffAndDebuffList.Count; j++)
                    {
                        if(targetPlayerUnit.GetComponent<EnemyUI>().buffAndDebuffList[j] == null)
                        {
                           targetPlayerUnit.GetComponent<EnemyUI>().buffTime[j] = skillList[i].buff.buffTime;
                           targetPlayerUnit.GetComponent<EnemyUI>().buffObjectList[j] = gameObject;
                           targetPlayerUnit.GetComponent<EnemyUI>().buffAndDebuffList[j] = skillList[i].buff;
                           //targetPlayerUnit.GetComponent<PlayerBattle>().player.buffTime[j] = skillList[i].buff.buffTime;
                           //targetPlayerUnit.GetComponent<PlayerBattle>().player.buffObjectList[j] = gameObject;
                           break;
                        }
                    }
                   
                }
                if(skillList[i].ownBuff)//自我buff
                {
                    for (int j = 0; j < buffAndDebuffList.Count; j++)
                    {
                        buffTime[j] = skillList[i].buff.buffTime;
                        buffObjectList[j] = gameObject;
                        buffAndDebuffList[j] = skillList[i].buff;
                        //buffTime[j] = skillList[i].buff.buffTime;
                        //buffObjectList[j] = gameObject;
                        break;
                    }
                }
                if(skillList[i].teamBuff)//团队buff
                {
                    for (int j = 0; j < targetPlayerUnitList.Count; j++)
                    {
                        if(targetPlayerUnitList[j] != null)
                        {
                            for (int k = 0; k < targetPlayerUnitList[j].GetComponent<EnemyUI>().buffAndDebuffList.Count; k++)
                            {
                                if(targetPlayerUnitList[j].GetComponent<EnemyUI>().buffAndDebuffList[k] == null)
                                {
                                    targetPlayerUnitList[j].GetComponent<EnemyUI>().buffTime[k] = skillList[i].buff.buffTime;
                                    targetPlayerUnitList[j].GetComponent<EnemyUI>().buffObjectList[k] = gameObject;
                                    targetPlayerUnitList[j].GetComponent<EnemyUI>().buffAndDebuffList[k] = skillList[i].buff;
                                    //targetPlayerUnitList[j].GetComponent<PlayerBattle>().player.buffTime[k] = skillList[i].buff.buffTime;
                                    //targetPlayerUnitList[j].GetComponent<PlayerBattle>().player.buffObjectList[k] = gameObject;
                                    break;
                                }
                            }
                        }
                    }
                }
            }  
        }

    }
    
    for (int i = 0; i < damageList.Count ; i++)
    {
        damage += damageList[i];
    }
    for (int i = 0; i < damageNumList.Count; i++)
    {
        if(damageNumList[i] == 0)
        {
            damageNumList[i] = damage;
            break;
        }
    }

    hp += (drainLife * damage);
    damage = 0;
    for (int i = 0; i < damageList.Count; i++)
    {
        damageList[i] = 0;
    }
}
public void Point()
{
    rank = playerClass.level;
    if((timeManage.GetComponent<TimeManage>().day + timeManage.GetComponent<TimeManage>().level) <= 20)
    {
        point = rank * 1;
    }
    if((timeManage.GetComponent<TimeManage>().day + timeManage.GetComponent<TimeManage>().level) <= 40 && (timeManage.GetComponent<TimeManage>().day + timeManage.GetComponent<TimeManage>().level) > 20)
    {
        point = rank * 2;
    }
    if((timeManage.GetComponent<TimeManage>().day + timeManage.GetComponent<TimeManage>().level) <= 60 && (timeManage.GetComponent<TimeManage>().day + timeManage.GetComponent<TimeManage>().level) > 40)
    {
        point = rank * 3;
    }
    if((timeManage.GetComponent<TimeManage>().day + timeManage.GetComponent<TimeManage>().level) <= 80 && (timeManage.GetComponent<TimeManage>().day + timeManage.GetComponent<TimeManage>().level) > 60)
    {
        point = rank * 4;
    }
    if((timeManage.GetComponent<TimeManage>().day + timeManage.GetComponent<TimeManage>().level) > 80)
    {
        point = rank * 5;
    }
    battleManage.enemyPoint = point;
}
public void DamageNum()
{
    damageNum = 0;
    for (int i = 0; i < damageNumList.Count; i++)
    {
        damageNum += damageNumList[i];
    }
}

public void Death()//死亡机制
{
    if(hp <= 0)
    {
        if(targetUnit != null)
        {
            for (int i = 0; i < targetUnit.GetComponent<PlayerBattle>().player.skillList.Count ; i++)
            {
                if(targetUnit.GetComponent<PlayerBattle>().player.skillList[i] != null)
                {
                if(targetUnit.GetComponent<PlayerBattle>().player.skillList[i].killSkill)//击杀技能
                {
                    if(targetUnit.GetComponent<PlayerBattle>().player.skillList[i].singleDamage)//单体伤害
                    {
                        if(targetUnit.GetComponent<PlayerBattle>().player.skillList[i].adSkill)
                        {
                            targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().hp -= ((targetUnit.GetComponent<PlayerBattle>().player.ad * targetUnit.GetComponent<PlayerBattle>().player.skillList[i].adSkillFactor) - targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().def);
                            targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().targetUnit = targetUnit;
                            for (int n = 0; n < targetUnit.GetComponent<PlayerBattle>().player.damageList.Count; n++)
                       {
                           if(targetUnit.GetComponent<PlayerBattle>().player.damageList[n] == 0)
                           {
                               targetUnit.GetComponent<PlayerBattle>().player.damageList[n] = ((targetUnit.GetComponent<PlayerBattle>().player.ad * targetUnit.GetComponent<PlayerBattle>().player.skillList[i].adSkillFactor) - targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().def);
                               targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().damageNumObjectIsAlive = true;//伤害数值显示
                               targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().damageNumber = targetUnit.GetComponent<PlayerBattle>().player.damageList[n];
                               break;
                           }
                       }          
                        }
                        if(targetUnit.GetComponent<PlayerBattle>().player.skillList[i].hpSkill)
                        {
                            targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().hp -= ((targetUnit.GetComponent<PlayerBattle>().player.totalhp * targetUnit.GetComponent<PlayerBattle>().player.skillList[i].hpSkillFactor) - targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().def);
                            targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().targetUnit = targetUnit;
                              for (int n = 0; n < targetUnit.GetComponent<PlayerBattle>().player.damageList.Count; n++)
                       {
                           if(targetUnit.GetComponent<PlayerBattle>().player.damageList[n] == 0)
                           {
                               targetUnit.GetComponent<PlayerBattle>().player.damageList[n] = ((targetUnit.GetComponent<PlayerBattle>().player.totalhp * targetUnit.GetComponent<PlayerBattle>().player.skillList[i].hpSkillFactor) - targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().def);
                               targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().damageNumObjectIsAlive = true;//伤害数值显示
                               targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().damageNumber = targetUnit.GetComponent<PlayerBattle>().player.damageList[n];
                               break;
                           }
                       }          
                        }
                        if(targetUnit.GetComponent<PlayerBattle>().player.skillList[i].apSkill)
                        {
                            targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().hp -= ((targetUnit.GetComponent<PlayerBattle>().player.ap * targetUnit.GetComponent<PlayerBattle>().player.skillList[i].apSkillFactor) - targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().mdef);
                            targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().targetUnit = targetUnit;
                            for (int n = 0; n < targetUnit.GetComponent<PlayerBattle>().player.damageList.Count; n++)
                            {

                            
                            if(targetUnit.GetComponent<PlayerBattle>().player.damageList[n] == 0)
                           {
                               targetUnit.GetComponent<PlayerBattle>().player.damageList[n] =  ((targetUnit.GetComponent<PlayerBattle>().player.ap * targetUnit.GetComponent<PlayerBattle>().player.skillList[i].apSkillFactor) - targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().mdef);
                               targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().damageNumObjectIsAlive = true;//伤害数值显示
                               targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().damageNumber = targetUnit.GetComponent<PlayerBattle>().player.damageList[n];
                               break;
                           }
                            }
                        }
                        if(targetUnit.GetComponent<PlayerBattle>().player.skillList[i].iqSkill)
                        {
                            targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().hp -= ((targetUnit.GetComponent<PlayerBattle>().player.iq * targetUnit.GetComponent<PlayerBattle>().player.skillList[i].iqSkillFactor) - targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().mdef);
                            targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().targetUnit = targetUnit;
                            for (int n = 0; n < targetUnit.GetComponent<PlayerBattle>().player.damageList.Count; n++)
                            { 
                            if(targetUnit.GetComponent<PlayerBattle>().player.damageList[n] == 0)
                           {
                               targetUnit.GetComponent<PlayerBattle>().player.damageList[n] = ((targetUnit.GetComponent<PlayerBattle>().player.iq * targetUnit.GetComponent<PlayerBattle>().player.skillList[i].iqSkillFactor) - targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().mdef);
                               targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().damageNumObjectIsAlive = true;//伤害数值显示
                               targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().damageNumber = damageList[n];
                               break;
                           }
                            }
                        }
                    }
                    if(targetUnit.GetComponent<PlayerBattle>().player.skillList[i].teamDamage)//团队伤害
                    {
                        if(targetUnit.GetComponent<PlayerBattle>().player.skillList[i].adSkill)
                        {
                            for (int j = 0; j < targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList.Count; j++)
                            {  
                             targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList[j].GetComponent<EnemyUI>().hp -= ((targetUnit.GetComponent<PlayerBattle>().player.ad * targetUnit.GetComponent<PlayerBattle>().player.skillList[i].adSkillFactor) - targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList[j].GetComponent<EnemyUI>().def);
                             targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList[j].GetComponent<EnemyUI>().targetUnit = targetUnit;
                             for (int n = 0; n < targetUnit.GetComponent<PlayerBattle>().player.damageList.Count; n++)
                            { 
                            if(targetUnit.GetComponent<PlayerBattle>().player.damageList[n] == 0)
                           {
                               targetUnit.GetComponent<PlayerBattle>().player.damageList[n] = ((targetUnit.GetComponent<PlayerBattle>().player.ad * targetUnit.GetComponent<PlayerBattle>().player.skillList[i].adSkillFactor) - targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList[j].GetComponent<EnemyUI>().def);
                               targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList[j].GetComponent<EnemyUI>().damageNumObjectIsAlive = true;//伤害数值显示
                               targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList[j].GetComponent<EnemyUI>().damageNumber = targetUnit.GetComponent<PlayerBattle>().player.damageList[n];
                               break;
                           }
                            }
                            }
                        }
                        if(targetUnit.GetComponent<PlayerBattle>().player.skillList[i].hpSkill)
                        {
                            for (int j = 0; j < targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList.Count; j++)
                            {  
                             targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList[j].GetComponent<EnemyUI>().hp -= ((targetUnit.GetComponent<PlayerBattle>().player.totalhp * targetUnit.GetComponent<PlayerBattle>().player.skillList[i].hpSkillFactor) - targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList[j].GetComponent<EnemyUI>().def);
                             targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList[j].GetComponent<EnemyUI>().targetUnit = targetUnit;
                             for (int n = 0; n < targetUnit.GetComponent<PlayerBattle>().player.damageList.Count; n++)
                            { 
                            if(targetUnit.GetComponent<PlayerBattle>().player.damageList[n] == 0)
                           {
                               targetUnit.GetComponent<PlayerBattle>().player.damageList[n] = ((targetUnit.GetComponent<PlayerBattle>().player.totalhp * targetUnit.GetComponent<PlayerBattle>().player.skillList[i].hpSkillFactor) - targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList[j].GetComponent<EnemyUI>().def);
                               targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList[j].GetComponent<EnemyUI>().damageNumObjectIsAlive = true;//伤害数值显示
                               targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList[j].GetComponent<EnemyUI>().damageNumber = damageList[n];
                               break;
                           }
                            }
                            }
                        }
                        if(targetUnit.GetComponent<PlayerBattle>().player.skillList[i].apSkill)
                        {
                            for (int j = 0; j < targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList.Count; j++)
                            {  
                             targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList[j].GetComponent<EnemyUI>().hp -= ((targetUnit.GetComponent<PlayerBattle>().player.ap * targetUnit.GetComponent<PlayerBattle>().player.skillList[i].apSkillFactor) - targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList[j].GetComponent<EnemyUI>().mdef);
                             targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList[j].GetComponent<EnemyUI>().targetUnit = targetUnit;
                              for (int n = 0; n < targetUnit.GetComponent<PlayerBattle>().player.damageList.Count; n++)
                            { 
                            if(targetUnit.GetComponent<PlayerBattle>().player.damageList[n] == 0)
                           {
                               targetUnit.GetComponent<PlayerBattle>().player.damageList[n] = ((targetUnit.GetComponent<PlayerBattle>().player.ap * targetUnit.GetComponent<PlayerBattle>().player.skillList[i].apSkillFactor) - targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList[j].GetComponent<EnemyUI>().mdef);
                               targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList[j].GetComponent<EnemyUI>().damageNumObjectIsAlive = true;//伤害数值显示
                               targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList[j].GetComponent<EnemyUI>().damageNumber = targetUnit.GetComponent<PlayerBattle>().player.damageList[n];
                               break;
                           }
                            }
                            }
                        }
                        if(targetUnit.GetComponent<PlayerBattle>().player.skillList[i].iqSkill)
                        {
                            for (int j = 0; j < targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList.Count; j++)
                            {  
                             targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList[j].GetComponent<EnemyUI>().hp -= ((targetUnit.GetComponent<PlayerBattle>().player.iq * targetUnit.GetComponent<PlayerBattle>().player.skillList[i].iqSkillFactor) - targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList[j].GetComponent<EnemyUI>().mdef);
                             targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList[j].GetComponent<EnemyUI>().targetUnit = targetUnit;
                              for (int n = 0; n < targetUnit.GetComponent<PlayerBattle>().player.damageList.Count; n++)
                            { 
                            if(targetUnit.GetComponent<PlayerBattle>().player.damageList[n] == 0)
                           {
                               targetUnit.GetComponent<PlayerBattle>().player.damageList[n] = ((targetUnit.GetComponent<PlayerBattle>().player.iq * targetUnit.GetComponent<PlayerBattle>().player.skillList[i].iqSkillFactor) - targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList[j].GetComponent<EnemyUI>().mdef);
                               targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList[j].GetComponent<EnemyUI>().damageNumObjectIsAlive = true;//伤害数值显示
                               targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList[j].GetComponent<EnemyUI>().damageNumber = targetUnit.GetComponent<PlayerBattle>().player.damageList[n];
                               break;
                           }
                            }
                            }
                        }
                    }
                    if(targetUnit.GetComponent<PlayerBattle>().player.skillList[i].ownBuff)//自我buff
                    {
                         for (int j = 0; j < targetUnit.GetComponent<PlayerBattle>().player.buffAndDebuffList.Count; j++)
                         {
                         targetUnit.GetComponent<PlayerBattle>().player.buffTime[j] = targetUnit.GetComponent<PlayerBattle>().player.skillList[i].buff.buffTime;
                         targetUnit.GetComponent<PlayerBattle>().player.buffObjectList[j] = targetUnit.GetComponent<PlayerBattle>().player.gameObject;
                         targetUnit.GetComponent<PlayerBattle>().player.buffAndDebuffList[j] = targetUnit.GetComponent<PlayerBattle>().player.skillList[i].buff;
                         //targetUnit.GetComponent<PlayerBattle>().player.buffTime[j] = targetUnit.GetComponent<PlayerBattle>().player.skillList[i].buff.buffTime;
                         //targetUnit.GetComponent<PlayerBattle>().player.buffObjectList[j] = targetUnit.GetComponent<PlayerBattle>().player.gameObject;
                         break;
                         }
                    }
                    if(targetUnit.GetComponent<PlayerBattle>().player.skillList[i].teamBuff)//团队buff
                    {
                        for (int j = 0; j < targetUnit.GetComponent<PlayerBattle>().player.targetPlayerUnitList.Count; j++)
                      {
                        if(targetUnit.GetComponent<PlayerBattle>().player.targetPlayerUnitList[j] != null)
                        {
                            for (int k = 0; k < targetUnit.GetComponent<PlayerBattle>().player.targetPlayerUnitList[j].GetComponent<PlayerBattle>().player.buffAndDebuffList.Count; k++)
                            {
                                if(targetUnit.GetComponent<PlayerBattle>().player.targetPlayerUnitList[j].GetComponent<PlayerBattle>().player.buffAndDebuffList[k] == null)
                                {
                                    targetUnit.GetComponent<PlayerBattle>().player.targetPlayerUnitList[j].GetComponent<PlayerBattle>().player.buffTime[k] = targetUnit.GetComponent<PlayerBattle>().player.skillList[i].buff.buffTime;
                                    targetUnit.GetComponent<PlayerBattle>().player.targetPlayerUnitList[j].GetComponent<PlayerBattle>().player.buffObjectList[k] = targetUnit;
                                    targetUnit.GetComponent<PlayerBattle>().player.targetPlayerUnitList[j].GetComponent<PlayerBattle>().player.buffAndDebuffList[k] = targetUnit.GetComponent<PlayerBattle>().player.skillList[i].buff;
                                    //targetUnit.GetComponent<PlayerBattle>().player.targetPlayerUnitList[j].GetComponent<PlayerBattle>().player.buffTime[k] = targetUnit.GetComponent<PlayerBattle>().player.skillList[i].buff.buffTime;
                                    //targetUnit.GetComponent<PlayerBattle>().player.targetPlayerUnitList[j].GetComponent<PlayerBattle>().player.buffObjectList[k] = targetUnit;
                                    break;
                                }
                            }
                        }
                       }
                    }
                    if(targetUnit.GetComponent<PlayerBattle>().player.skillList[i].teamDebuff)//团队debuff
                    {
                        for (int j = 0; j < targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList.Count; j++)
                      {
                        if(targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList[j] != null)
                        {
                            for (int k = 0; k < targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList[j].GetComponent<EnemyUI>().buffAndDebuffList.Count; k++)
                            {
                                if(targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList[j].GetComponent<EnemyUI>().buffAndDebuffList[k] == null)
                                {
                                    targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList[j].GetComponent<EnemyUI>().buffTime[k] = targetUnit.GetComponent<PlayerBattle>().player.skillList[i].buff.buffTime;
                                    targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList[j].GetComponent<EnemyUI>().buffObjectList[k] = targetUnit;
                                    targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList[j].GetComponent<EnemyUI>().buffAndDebuffList[k] = targetUnit.GetComponent<PlayerBattle>().player.skillList[i].buff;
                                    //targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffTime[k] = targetUnit.GetComponent<PlayerBattle>().player.skillList[i].buff.buffTime;
                                    //targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffObjectList[k] = targetUnit;
                                    break;
                                }
                            }
                        }
                       }
                    }
                    if(targetUnit.GetComponent<PlayerBattle>().player.skillList[i].growthSkill)//成长
                    {
                        targetUnit.GetComponent<PlayerBattle>().player.baseAd += targetUnit.GetComponent<PlayerBattle>().player.skillList[i].ad;
                        targetUnit.GetComponent<PlayerBattle>().player.baseAp += targetUnit.GetComponent<PlayerBattle>().player.skillList[i].ap;
                        targetUnit.GetComponent<PlayerBattle>().player.baseTotalhp += targetUnit.GetComponent<PlayerBattle>().player.skillList[i].totalhp;
                        targetUnit.GetComponent<PlayerBattle>().player.baseSpeed += targetUnit.GetComponent<PlayerBattle>().player.skillList[i].speed;
                        targetUnit.GetComponent<PlayerBattle>().player.baseDef += targetUnit.GetComponent<PlayerBattle>().player.skillList[i].def;
                        targetUnit.GetComponent<PlayerBattle>().player.baseMdef += targetUnit.GetComponent<PlayerBattle>().player.skillList[i].mdef;
                        targetUnit.GetComponent<PlayerBattle>().player.baseCritDamge += targetUnit.GetComponent<PlayerBattle>().player.skillList[i].critDamge;
                        targetUnit.GetComponent<PlayerBattle>().player.baseIq += targetUnit.GetComponent<PlayerBattle>().player.skillList[i].iq;
                        targetUnit.GetComponent<PlayerBattle>().player.baseCharm += targetUnit.GetComponent<PlayerBattle>().player.skillList[i].charm;
                    }  
                }
            }
            }
            targetUnit.GetComponent<PlayerBattle>().player.point += point;
        }
        for(int i = 0; i < targetEnemyUnitList.Count; i++)
        {
            for(int j = 0; j < targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList.Count; j++)
            {
                if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j] != null)
                {
                    if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].deathSkill)
                    {
                        if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].singleDamage)//单体伤害
                    {
                        if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].adSkill)
                        {
                            targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().hp -= ((targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.ad * targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].adSkillFactor) - targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().def);
                            targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().targetUnit = targetEnemyUnitList[i];
                            for (int n = 0; n < targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList.Count; n++)
                            { 
                            if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n] == 0)
                           {
                               targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n] = ((targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.ad * targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].adSkillFactor) - targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().def);
                               targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().damageNumObjectIsAlive = true;//伤害数值显示
                               targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().damageNumber = targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n];
                               break;
                           }
                            }
                            
                        }
                        if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].hpSkill)
                        {
                            targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().hp -= ((targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.totalhp * targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].hpSkillFactor) - targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().def);
                            targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().targetUnit = targetEnemyUnitList[i];
                            for (int n = 0; n < targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList.Count; n++)
                            { 
                            if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n] == 0)
                           {
                               targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n] = ((targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.totalhp * targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].hpSkillFactor) - targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().def);
                               targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().damageNumObjectIsAlive = true;//伤害数值显示
                               targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().damageNumber = targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n];
                               break;
                           }
                            }
                        }
                        if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].apSkill)
                        {
                            targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().hp -= ((targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.ap * targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].apSkillFactor) - targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().mdef);
                            targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().targetUnit = targetEnemyUnitList[i];
                            for (int n = 0; n < targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList.Count; n++)
                            { 
                            if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n] == 0)
                           {
                               targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n] = ((targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.ap * targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].apSkillFactor) - targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().mdef);
                               targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().damageNumObjectIsAlive = true;//伤害数值显示
                               targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().damageNumber = targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n];
                               break;
                           }
                            }
                        }
                        if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].iqSkill)
                        {
                            targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().hp -= ((targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.iq * targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].iqSkillFactor) - targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().mdef);
                            targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().targetUnit = targetEnemyUnitList[i];
                            for (int n = 0; n < targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList.Count; n++)
                            { 
                            if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n] == 0)
                           {
                               targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n] = ((targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.iq * targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].iqSkillFactor) - targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().mdef);
                               targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().damageNumObjectIsAlive = true;//伤害数值显示
                               targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().damageNumber = targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n];
                               break;
                           }
                            }
                        }
                    }
                    if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].teamDamage)//团队伤害
                    {
                        if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].adSkill)
                        {
                            for (int k = 0; k < targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList.Count; k++)
                            {  
                             targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList[k].GetComponent<EnemyUI>().hp -= ((targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.ad * targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].adSkillFactor) - targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList[k].GetComponent<EnemyUI>().def);
                             targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList[k].GetComponent<EnemyUI>().targetUnit = targetEnemyUnitList[i];
                             for (int n = 0; n < targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList.Count; n++)
                            { 
                            if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n] == 0)
                           {
                               targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n] = ((targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.ad * targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].adSkillFactor) - targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList[k].GetComponent<EnemyUI>().def);
                               targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList[k].GetComponent<EnemyUI>().damageNumObjectIsAlive = true;//伤害数值显示
                               targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList[k].GetComponent<EnemyUI>().damageNumber = targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n];
                               break;
                           }
                            }
                            }
                        }
                        if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].hpSkill)
                        {
                            for (int k = 0; k < targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList.Count; k++)
                            {  
                             targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList[k].GetComponent<EnemyUI>().hp -= ((targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.totalhp * targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].hpSkillFactor) - targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList[k].GetComponent<EnemyUI>().def);
                             targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList[k].GetComponent<EnemyUI>().targetUnit = targetEnemyUnitList[i];
                             for (int n = 0; n < targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList.Count; n++)
                            { 
                            if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n] == 0)
                           {
                               targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n] = ((targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.totalhp * targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].hpSkillFactor) - targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList[k].GetComponent<EnemyUI>().def);
                               targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList[k].GetComponent<EnemyUI>().damageNumObjectIsAlive = true;//伤害数值显示
                               targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList[k].GetComponent<EnemyUI>().damageNumber = targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n];
                               break;
                           }
                            }
                            }
                        }
                        if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].apSkill)
                        {
                            for (int k = 0; k < targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList.Count; k++)
                            {  
                             targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList[k].GetComponent<EnemyUI>().hp -= ((targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.ap * targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].apSkillFactor) - targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList[k].GetComponent<EnemyUI>().mdef);
                             targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList[k].GetComponent<EnemyUI>().targetUnit = targetEnemyUnitList[i];
                              for (int n = 0; n < targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList.Count; n++)
                            { 
                            if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n] == 0)
                           {
                               targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n] = ((targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.ap * targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].apSkillFactor) - targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList[k].GetComponent<EnemyUI>().mdef);
                               targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList[k].GetComponent<EnemyUI>().damageNumObjectIsAlive = true;//伤害数值显示
                               targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList[k].GetComponent<EnemyUI>().damageNumber = targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n];
                               break;
                           }
                            }
                            }
                        }
                        if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].iqSkill)
                        {
                            for (int k = 0; k < targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList.Count; k++)
                            {  
                             targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList[k].GetComponent<EnemyUI>().hp -= ((targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.iq * targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].iqSkillFactor) - targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList[k].GetComponent<EnemyUI>().mdef);
                             targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList[k].GetComponent<EnemyUI>().targetUnit = targetEnemyUnitList[i];
                              for (int n = 0; n < targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList.Count; n++)
                            { 
                            if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n] == 0)
                           {
                               targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n] = ((targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.iq * targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].iqSkillFactor) - targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList[k].GetComponent<EnemyUI>().mdef);
                               targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList[k].GetComponent<EnemyUI>().damageNumObjectIsAlive = true;//伤害数值显示
                               targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList[k].GetComponent<EnemyUI>().damageNumber = targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n];
                               break;
                           }
                            }
                            }
                        }

                        if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].ownBuff)//自我buff
                    {
                         for (int k = 0; k < targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.buffAndDebuffList.Count; k++)
                         {
                         targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.buffTime[k] = targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].buff.buffTime;
                         targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.buffObjectList[k] = targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.gameObject;
                         targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.buffAndDebuffList[k] = targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].buff;
                         //targetUnit.GetComponent<PlayerBattle>().player.buffTime[j] = targetUnit.GetComponent<PlayerBattle>().player.skillList[i].buff.buffTime;
                         //targetUnit.GetComponent<PlayerBattle>().player.buffObjectList[j] = targetUnit.GetComponent<PlayerBattle>().player.gameObject;
                         break;
                         }
                    }
                    if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].teamBuff)//团队buff
                    {
                        for (int k = 0; k < targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetPlayerUnitList.Count; k++)
                      {
                        if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetPlayerUnitList[k] != null)
                        {
                            for (int l = 0; l < targetUnit.GetComponent<PlayerBattle>().player.targetPlayerUnitList[k].GetComponent<PlayerBattle>().player.buffAndDebuffList.Count; l++)
                            {
                                if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetPlayerUnitList[k].GetComponent<PlayerBattle>().player.buffAndDebuffList[l] == null)
                                {
                                    targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetPlayerUnitList[k].GetComponent<PlayerBattle>().player.buffTime[l] = targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].buff.buffTime;
                                    targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetPlayerUnitList[k].GetComponent<PlayerBattle>().player.buffObjectList[l] = targetEnemyUnitList[i];
                                    targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetPlayerUnitList[k].GetComponent<PlayerBattle>().player.buffAndDebuffList[l] = targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].buff;
                                    //targetUnit.GetComponent<PlayerBattle>().player.targetPlayerUnitList[j].GetComponent<PlayerBattle>().player.buffTime[k] = targetUnit.GetComponent<PlayerBattle>().player.skillList[i].buff.buffTime;
                                    //targetUnit.GetComponent<PlayerBattle>().player.targetPlayerUnitList[j].GetComponent<PlayerBattle>().player.buffObjectList[k] = targetUnit;
                                    break;
                                }
                            }
                        }
                       }
                    }
                    if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].teamDebuff)//团队debuff
                    {
                        for (int k = 0; k < targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList.Count; k++)
                      {
                        if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList[k] != null)
                        {
                            for (int l = 0; l < targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList[k].GetComponent<EnemyUI>().buffAndDebuffList.Count; k++)
                            {
                                if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList[k].GetComponent<EnemyUI>().buffAndDebuffList[l] == null)
                                {
                                    targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList[k].GetComponent<EnemyUI>().buffTime[l] = targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].buff.buffTime;
                                    targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList[k].GetComponent<EnemyUI>().buffObjectList[l] = targetEnemyUnitList[i];
                                    targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList[k].GetComponent<EnemyUI>().buffAndDebuffList[l] = targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].buff;
                                    //targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffTime[k] = targetUnit.GetComponent<PlayerBattle>().player.skillList[i].buff.buffTime;
                                    //targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffObjectList[k] = targetUnit;
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
        }
        
        



        
        for (int i = 0; i < missionManager.GetComponent<MissionManager>().missionList.Count; i++)//任务击杀机制
        {
            if(missionManager.GetComponent<MissionManager>().missionList[i].activeSelf == true)//激活确认
            {
                if(missionManager.GetComponent<MissionManager>().missionList[i].GetComponent<PlayerMission>().mission.enemyObjectName == playerClass.playerName)//名字相符
                {
                    missionManager.GetComponent<MissionManager>().missionList[i].GetComponent<PlayerMission>().enemyNum += 1;//击杀数目+1
                }
            }
            
        }
        

      
       battleManage.remainEnemyList.Remove(gameObject);
       Destroy(gameObject);
            
    }
 }

}