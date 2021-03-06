using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
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
    public bool charmSkillBool;
    public bool apSkillBool;
    public bool iqSkillBool;
    public bool doubleDamage;
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
public float randomFloat;//随机因子

[Header("战斗显示")]
public GameObject damageNumObject;//prefab
public GameObject damageNumobjectPoint1;//定位点
public GameObject damageNumobjectPoint2;//定位点
public GameObject damageNumObj;//标记
public float damageNumber;//数值
public string dodgeString;//闪避string
public bool damageNumObjectIsAlive;//检测bool
public GameObject buffManage;
public GameObject buffPrefabObject;
[Header("战斗动作")]
public GameObject originalPosition;
public GameObject actionPosition;
public GameObject hurtPosition;
[Header("buff显示")]
public GameObject buffInfoObjectPrefab;
public GameObject buffInfoObject;
public GameObject buffInfoPoint1;
public GameObject buffInfoPoint2;
public string buffInfo;
public bool buffInfoIsAlive;

public GameObject skillNamePoint1;
public GameObject skillNamePoint2;
public string skillName;
public bool skillNameIsAlive;
public GameObject skillNameObjectPrefab;
public GameObject skillNameObject;




  
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
public void OnEnable()
{
    randomFloat = Random.Range(0,0.2f);
    
}
public void Update()
{
    slider.value = hp;
    slider.maxValue = totalhp;
    speedSlider.maxValue = 2;
    speedSlider.value = actionTime;
    //ownObject = gameObject;
    Point();
    Reply();
    Equipment();
    PlayerInformation();
    Fight();
    Death();
    PlayerInformation();
    
}
public void DamageNumObjectIsAlive()
{
    if(damageNumber <= 0)
    {
        damageNum = 1;
    }
    if(damageNumObjectIsAlive)
    {
        damageNumObj = Instantiate(damageNumObject);
        damageNumObj.transform.parent = gameObject.transform;
        damageNumObj.transform.position = damageNumobjectPoint1.transform.position;
        damageNumObjectIsAlive = false;
    }
      
}
public void BuffInfoIsAlive()
{
    if(buffInfoIsAlive)
    {
        buffInfoObject = Instantiate(buffInfoObjectPrefab);
        buffInfoObject.GetComponent<EnemyBuffInfo>().buffInfoText.text = buffInfo.ToString();
        buffInfoObject.GetComponent<EnemyBuffInfo>().buffInfoPoint2 = buffInfoPoint2;
        buffInfoObject.transform.parent = gameObject.transform;
        buffInfoObject.transform.position = buffInfoPoint1.transform.position;
        buffInfoIsAlive = false;
    }
}
public void SkillNameIsAlive()
{
    if(skillNameIsAlive)
    {
        skillNameObject = Instantiate(skillNameObjectPrefab);
        skillNameObject.GetComponent<SkillName>().skillNameText.text = skillName.ToString();
        skillNameObject.GetComponent<SkillName>().skillNamePoint2 = skillNamePoint2;
        skillNameObject.transform.parent = gameObject.transform;
        skillNameObject.transform.position = skillNamePoint1.transform.position;
        skillNameIsAlive = false;
    }
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
    totalhp = ((baseTotalhp + equipmentTotalhp + temporaryTotalhp + buffTotalhp) * (1.0f + randomFloat + baseTotalhpPCT + equipmentTotalhpPCT + temporaryTotalhpPCT + buffTotalhpPCT)) * ((1.0f + (0.1f * timeFactor)) * (1.0f + (0.1f * level)));
    totalmp = ((baseTotalmp + equipmentTotalmp + temporaryTotalmp + buffTotalmp) * (1.0f + randomFloat + baseTotalmpPCT + equipmentTotalmpPCT + temporaryTotalmpPCT + buffTotalmpPCT)) * ((1.0f + (0.1f * timeFactor)) * (1.0f + (0.1f * level)));
    totalsp = ((baseTotalsp + equipmentTotalsp + temporaryTotalsp + buffTotalsp) * (1.0f + randomFloat + baseTotalspPCT + equipmentTotalspPCT + temporaryTotalspPCT + buffTotalspPCT)) * ((1.0f + (0.1f * timeFactor)) * (1.0f + (0.1f * level)));
    ad = ((baseAd + equipmentAd + temporaryAd + buffAd) * (1.0f + randomFloat +  baseAdPCT + equipmentAdPCT + temporaryAdPCT + buffAdPCT)) * ((1.0f + (0.1f * timeFactor)) * (1.0f + (0.1f * level)));
    ap = ((baseAp + equipmentAp + temporaryAp + buffAp) * (1.0f + randomFloat +  baseApPCT + equipmentApPCT + temporaryApPCT + buffApPCT)) * ((1.0f + (0.1f * timeFactor)) * (1.0f + (0.1f * level)));
    def = ((baseDef + equipmentDef + temporaryDef + buffDef) * (1.0f + randomFloat +  baseDefPCT + equipmentDefPCT + temporaryDefPCT + buffDefPCT)) * ((1.0f + (0.1f * timeFactor)) * (1.0f + (0.1f * level)));
    mdef = ((baseMdef + equipmentMdef + temporaryMdef + buffMdef) * (1.0f + randomFloat +  baseMdefPCT + equipmentMdefPCT + temporaryMdefPCT + buffMdefPCT)) * ((1.0f + (0.1f * timeFactor)) * (1.0f + (0.1f * level)));
    speed = ((baseSpeed + equipmentSpeed + temporarySpeed + buffSpeed) * (1.0f +  randomFloat + baseSpeedPCT + equipmentSpeedPCT + temporarySpeedPCT + buffSpeedPCT)) * ((1.0f + (0.1f * timeFactor)) * (1.0f + (0.1f * level)));
    dodge = (baseDodge + equipmentDodge + temporaryDodge + buffDodge); //* (1.0f + baseDodgePCT + equipmentDodgePCT + temporaryDodgePCT + buffDodgePCT);
    crit = (baseCrit + equipmentCrit + temporaryCrit + buffCrit) ;//* (1.0f + baseCritPCT + equipmentCritPCT + temporaryCritPCT + buffCritPCT);
    iq = ((baseIq + equipmentIq + temporaryIq + buffIq) * (1.0f + randomFloat +  baseIqPCT + equipmentIqPCT + temporaryIqPCT + buffIqPCT)) * ((1.0f + (0.1f * timeFactor)) * (1.0f + (0.1f * level)));
    charm = ((baseCharm + equipmentCharm + temporaryCharm + buffCharm) * (1.0f + randomFloat +  baseCharmPCT + equipmentCharmPCT + temporaryCharmPCT + buffCharmPCT)) * ((1.0f + (0.1f * timeFactor)) * (1.0f + (0.1f * level)));
    critDamge = (baseCritDamge + equipmentCritDamge + temporaryCritDamge + buffCritDamge);//* (1.0f + baseCritDamgePCT + equipmentCritDamgePCT + temporaryCritDamgePCT + buffCritDamgePCT);
    drainLife = (baseDrainLife + equipmentDrainLife + temporaryDrainLife + buffDrainLife); //* (1.0f + baseDrainLifePCT + equipmentDrainLifePCT + temporaryDrainLifePCT + buffDrainLifePCT);
    replyHp = ((baseReplyHp + equipmentReplyHp + temporaryReplyHp + buffReplyHp) * (1.0f +  randomFloat + baseReplyHpPCT + equipmentReplyHpPCT + temporaryReplyHpPCT + buffReplyHpPCT)) * ((1.0f + (0.1f * timeFactor)) * (1.0f + (0.1f * level)));
    replyMp = ((baseReplyMp + equipmentReplyMp + temporaryReplyMp + buffReplyMp) * (1.0f +  randomFloat + baseReplyMpPCT + equipmentReplyMpPCT + temporaryReplyMpPCT + buffReplyMpPCT));  
    replySp = ((baseReplySp + equipmentReplySp + temporaryReplySp + buffReplySp) * (1.0f +  randomFloat + baseReplySpPCT + equipmentReplySpPCT + temporaryReplySpPCT + buffReplySpPCT)); 
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
       actionTime += (Time.deltaTime * (speed / maxSpeed));

       Buff();
       Target();
       DamageNum();
       BuffInfoIsAlive();
       DamageNumObjectIsAlive();
       //SkillNameIsAlive();

       if(actionTime >= 2 && actionTime >= 0.5f)//行动开始
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

     buffCrit1 = 0;

     buffIq1 = 0;
     buffIqPCT1 = 0;
     buffCharm1 = 0;
     buffCharmPCT1 = 0;
     buffCritDamge1 = 0;
   
     buffDrainLife1 = 0;
  
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
             if(buffAndDebuffList[i].dizzy)
             {
                dizzy = true;
             }
             if(buffAndDebuffList[i].disarm)
             {
                disarm = true;
             }
             if(buffAndDebuffList[i].singleDebuff || buffAndDebuffList[i].teamDebuff)//
             {
                 if(buffObjectList[i].GetComponent<PlayerBattle>().player.apSkillBool && buffObjectList[i].GetComponent<PlayerBattle>().player.iqSkillBool)
                 {                
             sp += (buffAndDebuffList[i].sp * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.ap / 10000)));
             mp += (buffAndDebuffList[i].mp * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.ap / 10000)));
             hp += (buffAndDebuffList[i].hp * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.ap / 10000)));
             buffTotalhp1 += (buffAndDebuffList[i].totalhp * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.ap / 10000)));
             buffTotalhpPCT1 += (buffAndDebuffList[i].totalhpPCT * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.iq / 1000)));
             buffTotalmp1 += (buffAndDebuffList[i].totalmp * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.ap / 10000)));
             buffTotalmpPCT1 += (buffAndDebuffList[i].totalmpPCT * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.iq / 1000)));
             buffTotalsp1 += (buffAndDebuffList[i].totalsp * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.ap / 10000)));
             buffTotalspPCT1 += (buffAndDebuffList[i].totalspPCT * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.iq / 1000)));
             buffAd1 += (buffAndDebuffList[i].ad * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.ap / 10000)));
             buffAdPCT1 += (buffAndDebuffList[i].adPCT * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.iq / 1000)));
             buffAp1 += (buffAndDebuffList[i].ap * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.ap / 10000)));
             buffApPCT1 += (buffAndDebuffList[i].apPCT * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.iq / 1000)));
             buffDef1 += (buffAndDebuffList[i].def * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.ap / 10000)));
             buffDefPCT1 += (buffAndDebuffList[i].defPCT * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.iq / 1000)));
             buffMdef1 += (buffAndDebuffList[i].mdef * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.ap / 10000)));
             buffMdefPCT1 += (buffAndDebuffList[i].mdefPCT * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.iq / 1000)));
             buffSpeed1 += (buffAndDebuffList[i].speed * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.ap / 10000)));
             buffSpeedPCT1 += (buffAndDebuffList[i].speedPCT * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.iq / 1000)));
             buffDodge1 += (buffAndDebuffList[i].dodge * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.iq / 1000)));
             //buffDodgePCT1 += (buffAndDebuffList[i].dodgePCT* (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.iq / 1000)) * buffAndDebuffList[i].dodgePCT);
             buffCrit1 += (buffAndDebuffList[i].crit * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.iq / 1000)));
             //buffCritPCT1 += (buffAndDebuffList[i].critPCT * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.iq / 1000)) * buffAndDebuffList[i].critPCT);
             buffIq1 += (buffAndDebuffList[i].iq * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.ap / 10000)));
             buffIqPCT1 += (buffAndDebuffList[i].iqPCT * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.iq / 1000)));
             buffCharm1 += (buffAndDebuffList[i].charm * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.ap / 10000)));
             buffCharmPCT1 += (buffAndDebuffList[i].charmPCT * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.iq / 1000)));
             buffCritDamge1 += (buffAndDebuffList[i].critDamge * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.iq / 1000)));
             //buffCritDamgePCT1 += (buffAndDebuffList[i].critDamgePCT * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.iq / 1000)) * buffAndDebuffList[i].critDamgePCT);
             buffDrainLife1 += (buffAndDebuffList[i].drainLife * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.iq / 1000)));
             //buffDrainLifePCT1 += (buffAndDebuffList[i].drainLifePCT * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.iq / 1000)) * buffAndDebuffList[i].drainLifePCT);
             buffReplyHp1 += (buffAndDebuffList[i].replyHp * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.ap / 10000)));
             buffReplyHpPCT1 += (buffAndDebuffList[i].replyHpPCT * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.iq / 1000)));
             buffReplyMp1 += (buffAndDebuffList[i].replyMp * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.ap / 10000)));
             buffReplyMpPCT1 += (buffAndDebuffList[i].replyMpPCT * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.iq / 1000)));
             buffReplySp1 += (buffAndDebuffList[i].replySp * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.ap / 10000)));
             buffReplySpPCT1 += (buffAndDebuffList[i].replySpPCT * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.iq / 1000)));
             buffSkillOdds1 += buffAndDebuffList[i].skillOdds;
             buffSword1 += buffAndDebuffList[i].sword;
             buffGun1 += buffAndDebuffList[i].gun;
                 }
                 if(!buffObjectList[i].GetComponent<PlayerBattle>().player.apSkillBool && buffObjectList[i].GetComponent<PlayerBattle>().player.iqSkillBool)
                 {                
             sp += (buffAndDebuffList[i].sp);
             mp += (buffAndDebuffList[i].mp);
             hp += (buffAndDebuffList[i].hp);
             buffTotalhp1 += (buffAndDebuffList[i].totalhp);
             buffTotalhpPCT1 += (buffAndDebuffList[i].totalhpPCT * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.iq / 1000)));
             buffTotalmp1 += (buffAndDebuffList[i].totalmp);
             buffTotalmpPCT1 += (buffAndDebuffList[i].totalmpPCT * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.iq / 1000)));
             buffTotalsp1 += (buffAndDebuffList[i].totalsp);
             buffTotalspPCT1 += (buffAndDebuffList[i].totalspPCT * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.iq / 1000)));
             buffAd1 += (buffAndDebuffList[i].ad);
             buffAdPCT1 += (buffAndDebuffList[i].adPCT * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.iq / 1000)));
             buffAp1 += (buffAndDebuffList[i].ap);
             buffApPCT1 += (buffAndDebuffList[i].apPCT * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.iq / 1000)));
             buffDef1 += (buffAndDebuffList[i].def);
             buffDefPCT1 += (buffAndDebuffList[i].defPCT * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.iq / 1000)));
             buffMdef1 += (buffAndDebuffList[i].mdef);
             buffMdefPCT1 += (buffAndDebuffList[i].mdefPCT * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.iq / 1000)));
             buffSpeed1 += (buffAndDebuffList[i].speed);
             buffSpeedPCT1 += (buffAndDebuffList[i].speedPCT * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.iq / 1000)));
             buffDodge1 += (buffAndDebuffList[i].dodge * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.iq / 1000)));
             //buffDodgePCT1 += (buffAndDebuffList[i].dodgePCT* (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.iq / 1000)) * buffAndDebuffList[i].dodgePCT);
             buffCrit1 += (buffAndDebuffList[i].crit * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.iq / 1000)));
             //buffCritPCT1 += (buffAndDebuffList[i].critPCT * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.iq / 1000)) * buffAndDebuffList[i].critPCT);
             buffIq1 += (buffAndDebuffList[i].iq);
             buffIqPCT1 += (buffAndDebuffList[i].iqPCT * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.iq / 1000)));
             buffCharm1 += (buffAndDebuffList[i].charm);
             buffCharmPCT1 += (buffAndDebuffList[i].charmPCT * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.iq / 1000)));
             buffCritDamge1 += (buffAndDebuffList[i].critDamge * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.iq / 1000)));
             //buffCritDamgePCT1 += (buffAndDebuffList[i].critDamgePCT * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.iq / 1000)) * buffAndDebuffList[i].critDamgePCT);
             buffDrainLife1 += (buffAndDebuffList[i].drainLife * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.iq / 1000)));
             //buffDrainLifePCT1 += (buffAndDebuffList[i].drainLifePCT * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.iq / 1000)) * buffAndDebuffList[i].drainLifePCT);
             buffReplyHp1 += (buffAndDebuffList[i].replyHp);
             buffReplyHpPCT1 += (buffAndDebuffList[i].replyHpPCT * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.iq / 1000)));
             buffReplyMp1 += (buffAndDebuffList[i].replyMp);
             buffReplyMpPCT1 += (buffAndDebuffList[i].replyMpPCT * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.iq / 1000)));
             buffReplySp1 += (buffAndDebuffList[i].replySp);
             buffReplySpPCT1 += (buffAndDebuffList[i].replySpPCT * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.iq / 1000)));
             buffSkillOdds1 += buffAndDebuffList[i].skillOdds;
             buffSword1 += buffAndDebuffList[i].sword;
             buffGun1 += buffAndDebuffList[i].gun;
                 }
                  if(buffObjectList[i].GetComponent<PlayerBattle>().player.apSkillBool && !buffObjectList[i].GetComponent<PlayerBattle>().player.iqSkillBool)
                 {                
             sp += (buffAndDebuffList[i].sp * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.ap / 10000)));
             mp += (buffAndDebuffList[i].mp * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.ap / 10000)));
             hp += (buffAndDebuffList[i].hp * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.ap / 10000)));
             buffTotalhp1 += (buffAndDebuffList[i].totalhp * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.ap / 10000)));
             buffTotalhpPCT1 += (buffAndDebuffList[i].totalhpPCT);
             buffTotalmp1 += (buffAndDebuffList[i].totalmp * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.ap / 10000)));
             buffTotalmpPCT1 += (buffAndDebuffList[i].totalmpPCT);
             buffTotalsp1 += (buffAndDebuffList[i].totalsp * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.ap / 10000)));
             buffTotalspPCT1 += (buffAndDebuffList[i].totalspPCT);
             buffAd1 += (buffAndDebuffList[i].ad * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.ap / 10000)));
             buffAdPCT1 += (buffAndDebuffList[i].adPCT);
             buffAp1 += (buffAndDebuffList[i].ap * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.ap / 10000)));
             buffApPCT1 += (buffAndDebuffList[i].apPCT);
             buffDef1 += (buffAndDebuffList[i].def * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.ap / 10000)));
             buffDefPCT1 += (buffAndDebuffList[i].defPCT);
             buffMdef1 += (buffAndDebuffList[i].mdef * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.ap / 10000)));
             buffMdefPCT1 += (buffAndDebuffList[i].mdefPCT);
             buffSpeed1 += (buffAndDebuffList[i].speed * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.ap / 10000)));
             buffSpeedPCT1 += (buffAndDebuffList[i].speedPCT);
             buffDodge1 += (buffAndDebuffList[i].dodge);
             //buffDodgePCT1 += (buffAndDebuffList[i].dodgePCT* (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.iq / 1000)) * buffAndDebuffList[i].dodgePCT);
             buffCrit1 += (buffAndDebuffList[i].crit);
             //buffCritPCT1 += (buffAndDebuffList[i].critPCT * buffAndDebuffList[i].critPCT);
             buffIq1 += (buffAndDebuffList[i].iq * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.ap / 10000)));
             buffIqPCT1 += (buffAndDebuffList[i].iqPCT);
             buffCharm1 += (buffAndDebuffList[i].charm * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.ap / 10000)));
             buffCharmPCT1 += (buffAndDebuffList[i].charmPCT);
             buffCritDamge1 += (buffAndDebuffList[i].critDamge);
             //buffCritDamgePCT1 += (buffAndDebuffList[i].critDamgePCT * buffAndDebuffList[i].critDamgePCT);
             buffDrainLife1 += (buffAndDebuffList[i].drainLife);
             //buffDrainLifePCT1 += (buffAndDebuffList[i].drainLifePCT * buffAndDebuffList[i].drainLifePCT);
             buffReplyHp1 += (buffAndDebuffList[i].replyHp * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.ap / 10000)));
             buffReplyHpPCT1 += (buffAndDebuffList[i].replyHpPCT);
             buffReplyMp1 += (buffAndDebuffList[i].replyMp * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.ap / 10000)));
             buffReplyMpPCT1 += (buffAndDebuffList[i].replyMpPCT);
             buffReplySp1 += (buffAndDebuffList[i].replySp * (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.ap / 10000)));
             buffReplySpPCT1 += (buffAndDebuffList[i].replySpPCT);
             buffSkillOdds1 += buffAndDebuffList[i].skillOdds;
             buffSword1 += buffAndDebuffList[i].sword;
             buffGun1 += buffAndDebuffList[i].gun;
                 }
                 if(!buffObjectList[i].GetComponent<PlayerBattle>().player.apSkillBool && !buffObjectList[i].GetComponent<PlayerBattle>().player.iqSkillBool)
                 {                
             sp += (buffAndDebuffList[i].sp);
             mp += (buffAndDebuffList[i].mp);
             hp += (buffAndDebuffList[i].hp);
             buffTotalhp1 += (buffAndDebuffList[i].totalhp);
             buffTotalhpPCT1 += (buffAndDebuffList[i].totalhpPCT);
             buffTotalmp1 += (buffAndDebuffList[i].totalmp);
             buffTotalmpPCT1 += (buffAndDebuffList[i].totalmpPCT);
             buffTotalsp1 += (buffAndDebuffList[i].totalsp);
             buffTotalspPCT1 += (buffAndDebuffList[i].totalspPCT);
             buffAd1 += (buffAndDebuffList[i].ad);
             buffAdPCT1 += (buffAndDebuffList[i].adPCT);
             buffAp1 += (buffAndDebuffList[i].ap);
             buffApPCT1 += (buffAndDebuffList[i].apPCT);
             buffDef1 += (buffAndDebuffList[i].def);
             buffDefPCT1 += (buffAndDebuffList[i].defPCT);
             buffMdef1 += (buffAndDebuffList[i].mdef);
             buffMdefPCT1 += (buffAndDebuffList[i].mdefPCT);
             buffSpeed1 += (buffAndDebuffList[i].speed);
             buffSpeedPCT1 += (buffAndDebuffList[i].speedPCT);
             buffDodge1 += (buffAndDebuffList[i].dodge);
             //buffDodgePCT1 += (buffAndDebuffList[i].dodgePCT* (1 + (buffObjectList[i].GetComponent<PlayerBattle>().player.iq / 1000)) * buffAndDebuffList[i].dodgePCT);
             buffCrit1 += (buffAndDebuffList[i].crit);
             //buffCritPCT1 += (buffAndDebuffList[i].critPCT * buffAndDebuffList[i].critPCT);
             buffIq1 += (buffAndDebuffList[i].iq);
             buffIqPCT1 += (buffAndDebuffList[i].iqPCT);
             buffCharm1 += (buffAndDebuffList[i].charm);
             buffCharmPCT1 += (buffAndDebuffList[i].charmPCT);
             buffCritDamge1 += (buffAndDebuffList[i].critDamge);
             //buffCritDamgePCT1 += (buffAndDebuffList[i].critDamgePCT * buffAndDebuffList[i].critDamgePCT);
             buffDrainLife1 += (buffAndDebuffList[i].drainLife);
             //buffDrainLifePCT1 += (buffAndDebuffList[i].drainLifePCT * buffAndDebuffList[i].drainLifePCT);
             buffReplyHp1 += (buffAndDebuffList[i].replyHp);
             buffReplyHpPCT1 += (buffAndDebuffList[i].replyHpPCT);
             buffReplyMp1 += (buffAndDebuffList[i].replyMp);
             buffReplyMpPCT1 += (buffAndDebuffList[i].replyMpPCT);
             buffReplySp1 += (buffAndDebuffList[i].replySp);
             buffReplySpPCT1 += (buffAndDebuffList[i].replySpPCT);
             buffSkillOdds1 += buffAndDebuffList[i].skillOdds;
             buffSword1 += buffAndDebuffList[i].sword;
             buffGun1 += buffAndDebuffList[i].gun;
                 }



             }
             if(buffAndDebuffList[i].singleBuff || buffAndDebuffList[i].teamBuff || buffAndDebuffList[i].ownBuff)
             {
                  if(buffObjectList[i].GetComponent<EnemyUI>().apSkillBool && buffObjectList[i].GetComponent<EnemyUI>().iqSkillBool)
                  {
             sp += (buffAndDebuffList[i].sp * (1 + (buffObjectList[i].GetComponent<EnemyUI>().ap / 10000)));
             mp += (buffAndDebuffList[i].mp * (1 + (buffObjectList[i].GetComponent<EnemyUI>().ap / 10000)));
             hp += (buffAndDebuffList[i].hp * (1 + (buffObjectList[i].GetComponent<EnemyUI>().ap / 10000)));
             buffTotalhp2 += (buffAndDebuffList[i].totalhp * (1 + (buffObjectList[i].GetComponent<EnemyUI>().ap / 10000)));
             buffTotalhpPCT2 += (buffAndDebuffList[i].totalhpPCT * (1 + (buffObjectList[i].GetComponent<EnemyUI>().iq / 1000)));
             buffTotalmp2 += (buffAndDebuffList[i].totalmp * (1 + (buffObjectList[i].GetComponent<EnemyUI>().ap / 10000)));
             buffTotalmpPCT2 += (buffAndDebuffList[i].totalmpPCT * (1 + (buffObjectList[i].GetComponent<EnemyUI>().iq / 1000)));
             buffTotalsp2 += (buffAndDebuffList[i].totalsp * (1 + (buffObjectList[i].GetComponent<EnemyUI>().ap / 10000)));
             buffTotalspPCT2 += (buffAndDebuffList[i].totalspPCT * (1 + (buffObjectList[i].GetComponent<EnemyUI>().iq / 1000)));
             buffAd2 += (buffAndDebuffList[i].ad * (1 + (buffObjectList[i].GetComponent<EnemyUI>().ap / 10000)));
             buffAdPCT2 += (buffAndDebuffList[i].adPCT * (1 + (buffObjectList[i].GetComponent<EnemyUI>().iq / 1000)));
             buffAp2 += (buffAndDebuffList[i].ap * (1 + (buffObjectList[i].GetComponent<EnemyUI>().ap / 10000)));
             buffApPCT2 += (buffAndDebuffList[i].apPCT * (1 + (buffObjectList[i].GetComponent<EnemyUI>().iq / 1000)));
             buffDef2 += (buffAndDebuffList[i].def * (1 + (buffObjectList[i].GetComponent<EnemyUI>().ap / 10000)));
             buffDefPCT2 += (buffAndDebuffList[i].defPCT * (1 + (buffObjectList[i].GetComponent<EnemyUI>().iq / 1000)));
             buffMdef2 += (buffAndDebuffList[i].mdef * (1 + (buffObjectList[i].GetComponent<EnemyUI>().ap / 10000)));
             buffMdefPCT2 += (buffAndDebuffList[i].mdefPCT * (1 + (buffObjectList[i].GetComponent<EnemyUI>().iq / 1000)));
             buffSpeed2 += (buffAndDebuffList[i].speed * (1 + (buffObjectList[i].GetComponent<EnemyUI>().ap / 10000)));
             buffSpeedPCT2 += (buffAndDebuffList[i].speedPCT * (1 + (buffObjectList[i].GetComponent<EnemyUI>().iq / 1000)));
             buffDodge2 += (buffAndDebuffList[i].dodge * (1 + (buffObjectList[i].GetComponent<EnemyUI>().iq / 1000)));
             //buffDodgePCT2 += (buffAndDebuffList[i].dodgePCT* (1 + (buffObjectList[i].GetComponent<EnemyUI>().iq / 1000)) * buffAndDebuffList[i].dodgePCT);
             buffCrit2 += (buffAndDebuffList[i].crit * (1 + (buffObjectList[i].GetComponent<EnemyUI>().iq / 1000)));
             //buffCritPCT2 += (buffAndDebuffList[i].critPCT * (1 + (buffObjectList[i].GetComponent<EnemyUI>().iq / 1000)) * buffAndDebuffList[i].critPCT);
             buffIq2 += (buffAndDebuffList[i].iq * (1 + (buffObjectList[i].GetComponent<EnemyUI>().ap / 10000)));
             buffIqPCT2 += (buffAndDebuffList[i].iqPCT * (1 + (buffObjectList[i].GetComponent<EnemyUI>().iq / 1000)));
             buffCharm2 += (buffAndDebuffList[i].charm * (1 + (buffObjectList[i].GetComponent<EnemyUI>().ap / 10000)));
             buffCharmPCT2 += (buffAndDebuffList[i].charmPCT * (1 + (buffObjectList[i].GetComponent<EnemyUI>().iq / 1000)));
             buffCritDamge2 += (buffAndDebuffList[i].critDamge * (1 + (buffObjectList[i].GetComponent<EnemyUI>().iq / 1000)));
            // buffCritDamgePCT2 += (buffAndDebuffList[i].critDamgePCT * (1 + (buffObjectList[i].GetComponent<EnemyUI>().iq / 1000)) * buffAndDebuffList[i].critDamgePCT);
             buffDrainLife2 += (buffAndDebuffList[i].drainLife * (1 + (buffObjectList[i].GetComponent<EnemyUI>().iq / 1000)));
             //buffDrainLifePCT2 += (buffAndDebuffList[i].drainLifePCT * (1 + (buffObjectList[i].GetComponent<EnemyUI>().iq / 1000)) * buffAndDebuffList[i].drainLifePCT);
             buffReplyHp2 += (buffAndDebuffList[i].replyHp * (1 + (buffObjectList[i].GetComponent<EnemyUI>().ap / 10000)));
             buffReplyHpPCT2 += (buffAndDebuffList[i].replyHpPCT * (1 + (buffObjectList[i].GetComponent<EnemyUI>().iq / 1000)));
             buffReplyMp2 += (buffAndDebuffList[i].replyMp * (1 + (buffObjectList[i].GetComponent<EnemyUI>().ap / 10000)));
             buffReplyMpPCT2 += (buffAndDebuffList[i].replyMpPCT * (1 + (buffObjectList[i].GetComponent<EnemyUI>().iq / 1000)));
             buffReplySp2 += (buffAndDebuffList[i].replySp * (1 + (buffObjectList[i].GetComponent<EnemyUI>().ap / 10000)));
             buffReplySpPCT2 += (buffAndDebuffList[i].replySpPCT * (1 + (buffObjectList[i].GetComponent<EnemyUI>().iq / 1000)));
             buffSkillOdds2 += buffAndDebuffList[i].skillOdds;
             buffSword2 += buffAndDebuffList[i].sword;
             buffGun2 += buffAndDebuffList[i].gun;
                 }
                 if(!buffObjectList[i].GetComponent<EnemyUI>().apSkillBool && buffObjectList[i].GetComponent<EnemyUI>().iqSkillBool)
                  {
             sp += (buffAndDebuffList[i].sp);
             mp += (buffAndDebuffList[i].mp);
             hp += (buffAndDebuffList[i].hp);
             buffTotalhp2 += (buffAndDebuffList[i].totalhp);
             buffTotalhpPCT2 += (buffAndDebuffList[i].totalhpPCT * (1 + (buffObjectList[i].GetComponent<EnemyUI>().iq / 1000)));
             buffTotalmp2 += (buffAndDebuffList[i].totalmp);
             buffTotalmpPCT2 += (buffAndDebuffList[i].totalmpPCT * (1 + (buffObjectList[i].GetComponent<EnemyUI>().iq / 1000)));
             buffTotalsp2 += (buffAndDebuffList[i].totalsp);
             buffTotalspPCT2 += (buffAndDebuffList[i].totalspPCT * (1 + (buffObjectList[i].GetComponent<EnemyUI>().iq / 1000)));
             buffAd2 += (buffAndDebuffList[i].ad);
             buffAdPCT2 += (buffAndDebuffList[i].adPCT * (1 + (buffObjectList[i].GetComponent<EnemyUI>().iq / 1000)));
             buffAp2 += (buffAndDebuffList[i].ap);
             buffApPCT2 += (buffAndDebuffList[i].apPCT * (1 + (buffObjectList[i].GetComponent<EnemyUI>().iq / 1000)));
             buffDef2 += (buffAndDebuffList[i].def);
             buffDefPCT2 += (buffAndDebuffList[i].defPCT * (1 + (buffObjectList[i].GetComponent<EnemyUI>().iq / 1000)));
             buffMdef2 += (buffAndDebuffList[i].mdef);
             buffMdefPCT2 += (buffAndDebuffList[i].mdefPCT * (1 + (buffObjectList[i].GetComponent<EnemyUI>().iq / 1000)));
             buffSpeed2 += (buffAndDebuffList[i].speed);
             buffSpeedPCT2 += (buffAndDebuffList[i].speedPCT * (1 + (buffObjectList[i].GetComponent<EnemyUI>().iq / 1000)));
             buffDodge2 += (buffAndDebuffList[i].dodge * (1 + (buffObjectList[i].GetComponent<EnemyUI>().iq / 1000)));
             //buffDodgePCT2 += (buffAndDebuffList[i].dodgePCT* (1 + (buffObjectList[i].GetComponent<EnemyUI>().iq / 1000)) * buffAndDebuffList[i].dodgePCT);
             buffCrit2 += (buffAndDebuffList[i].crit * (1 + (buffObjectList[i].GetComponent<EnemyUI>().iq / 1000)));
             //buffCritPCT2 += (buffAndDebuffList[i].critPCT * (1 + (buffObjectList[i].GetComponent<EnemyUI>().iq / 1000)) * buffAndDebuffList[i].critPCT);
             buffIq2 += (buffAndDebuffList[i].iq);
             buffIqPCT2 += (buffAndDebuffList[i].iqPCT * (1 + (buffObjectList[i].GetComponent<EnemyUI>().iq / 1000)));
             buffCharm2 += (buffAndDebuffList[i].charm);
             buffCharmPCT2 += (buffAndDebuffList[i].charmPCT * (1 + (buffObjectList[i].GetComponent<EnemyUI>().iq / 1000)));
             buffCritDamge2 += (buffAndDebuffList[i].critDamge * (1 + (buffObjectList[i].GetComponent<EnemyUI>().iq / 1000)));
            // buffCritDamgePCT2 += (buffAndDebuffList[i].critDamgePCT * (1 + (buffObjectList[i].GetComponent<EnemyUI>().iq / 1000)) * buffAndDebuffList[i].critDamgePCT);
             buffDrainLife2 += (buffAndDebuffList[i].drainLife * (1 + (buffObjectList[i].GetComponent<EnemyUI>().iq / 1000)));
             //buffDrainLifePCT2 += (buffAndDebuffList[i].drainLifePCT * (1 + (buffObjectList[i].GetComponent<EnemyUI>().iq / 1000)) * buffAndDebuffList[i].drainLifePCT);
             buffReplyHp2 += (buffAndDebuffList[i].replyHp);
             buffReplyHpPCT2 += (buffAndDebuffList[i].replyHpPCT * (1 + (buffObjectList[i].GetComponent<EnemyUI>().iq / 1000)));
             buffReplyMp2 += (buffAndDebuffList[i].replyMp);
             buffReplyMpPCT2 += (buffAndDebuffList[i].replyMpPCT * (1 + (buffObjectList[i].GetComponent<EnemyUI>().iq / 1000)));
             buffReplySp2 += (buffAndDebuffList[i].replySp);
             buffReplySpPCT2 += (buffAndDebuffList[i].replySpPCT * (1 + (buffObjectList[i].GetComponent<EnemyUI>().iq / 1000)));
             buffSkillOdds2 += buffAndDebuffList[i].skillOdds;
             buffSword2 += buffAndDebuffList[i].sword;
             buffGun2 += buffAndDebuffList[i].gun;
                 }
                 if(buffObjectList[i].GetComponent<EnemyUI>().apSkillBool && !buffObjectList[i].GetComponent<EnemyUI>().iqSkillBool)
                  {
             sp += (buffAndDebuffList[i].sp * (1 + (buffObjectList[i].GetComponent<EnemyUI>().ap / 10000)));
             mp += (buffAndDebuffList[i].mp * (1 + (buffObjectList[i].GetComponent<EnemyUI>().ap / 10000)));
             hp += (buffAndDebuffList[i].hp * (1 + (buffObjectList[i].GetComponent<EnemyUI>().ap / 10000)));
             buffTotalhp2 += (buffAndDebuffList[i].totalhp * (1 + (buffObjectList[i].GetComponent<EnemyUI>().ap / 10000)));
             buffTotalhpPCT2 += (buffAndDebuffList[i].totalhpPCT);
             buffTotalmp2 += (buffAndDebuffList[i].totalmp * (1 + (buffObjectList[i].GetComponent<EnemyUI>().ap / 10000)));
             buffTotalmpPCT2 += (buffAndDebuffList[i].totalmpPCT);
             buffTotalsp2 += (buffAndDebuffList[i].totalsp * (1 + (buffObjectList[i].GetComponent<EnemyUI>().ap / 10000)));
             buffTotalspPCT2 += (buffAndDebuffList[i].totalspPCT);
             buffAd2 += (buffAndDebuffList[i].ad * (1 + (buffObjectList[i].GetComponent<EnemyUI>().ap / 10000)));
             buffAdPCT2 += (buffAndDebuffList[i].adPCT);
             buffAp2 += (buffAndDebuffList[i].ap * (1 + (buffObjectList[i].GetComponent<EnemyUI>().ap / 10000)));
             buffApPCT2 += (buffAndDebuffList[i].apPCT);
             buffDef2 += (buffAndDebuffList[i].def * (1 + (buffObjectList[i].GetComponent<EnemyUI>().ap / 10000)));
             buffDefPCT2 += (buffAndDebuffList[i].defPCT);
             buffMdef2 += (buffAndDebuffList[i].mdef * (1 + (buffObjectList[i].GetComponent<EnemyUI>().ap / 10000)));
             buffMdefPCT2 += (buffAndDebuffList[i].mdefPCT);
             buffSpeed2 += (buffAndDebuffList[i].speed * (1 + (buffObjectList[i].GetComponent<EnemyUI>().ap / 10000)));
             buffSpeedPCT2 += (buffAndDebuffList[i].speedPCT);
             buffDodge2 += (buffAndDebuffList[i].dodge);
             //buffDodgePCT2 += (buffAndDebuffList[i].dodgePCT* (1 + (buffObjectList[i].GetComponent<EnemyUI>().iq / 1000)) * buffAndDebuffList[i].dodgePCT);
             buffCrit2 += (buffAndDebuffList[i].crit);
             //buffCritPCT2 += (buffAndDebuffList[i].critPCT * buffAndDebuffList[i].critPCT);
             buffIq2 += (buffAndDebuffList[i].iq * (1 + (buffObjectList[i].GetComponent<EnemyUI>().ap / 10000)));
             buffIqPCT2 += (buffAndDebuffList[i].iqPCT);
             buffCharm2 += (buffAndDebuffList[i].charm * (1 + (buffObjectList[i].GetComponent<EnemyUI>().ap / 10000)));
             buffCharmPCT2 += (buffAndDebuffList[i].charmPCT);
             buffCritDamge2 += (buffAndDebuffList[i].critDamge);
            // buffCritDamgePCT2 += (buffAndDebuffList[i].critDamgePCT * buffAndDebuffList[i].critDamgePCT);
             buffDrainLife2 += (buffAndDebuffList[i].drainLife);
             //buffDrainLifePCT2 += (buffAndDebuffList[i].drainLifePCT * buffAndDebuffList[i].drainLifePCT);
             buffReplyHp2 += (buffAndDebuffList[i].replyHp * (1 + (buffObjectList[i].GetComponent<EnemyUI>().ap / 10000)));
             buffReplyHpPCT2 += (buffAndDebuffList[i].replyHpPCT);
             buffReplyMp2 += (buffAndDebuffList[i].replyMp * (1 + (buffObjectList[i].GetComponent<EnemyUI>().ap / 10000)));
             buffReplyMpPCT2 += (buffAndDebuffList[i].replyMpPCT);
             buffReplySp2 += (buffAndDebuffList[i].replySp * (1 + (buffObjectList[i].GetComponent<EnemyUI>().ap / 10000)));
             buffReplySpPCT2 += (buffAndDebuffList[i].replySpPCT);
             buffSkillOdds2 += buffAndDebuffList[i].skillOdds;
             buffSword2 += buffAndDebuffList[i].sword;
             buffGun2 += buffAndDebuffList[i].gun;
                 }

                 if(!buffObjectList[i].GetComponent<EnemyUI>().apSkillBool && !buffObjectList[i].GetComponent<EnemyUI>().iqSkillBool)
                  {
             sp += (buffAndDebuffList[i].sp);
             mp += (buffAndDebuffList[i].mp);
             hp += (buffAndDebuffList[i].hp);
             buffTotalhp2 += (buffAndDebuffList[i].totalhp);
             buffTotalhpPCT2 += (buffAndDebuffList[i].totalhpPCT);
             buffTotalmp2 += (buffAndDebuffList[i].totalmp);
             buffTotalmpPCT2 += (buffAndDebuffList[i].totalmpPCT);
             buffTotalsp2 += (buffAndDebuffList[i].totalsp);
             buffTotalspPCT2 += (buffAndDebuffList[i].totalspPCT);
             buffAd2 += (buffAndDebuffList[i].ad);
             buffAdPCT2 += (buffAndDebuffList[i].adPCT);
             buffAp2 += (buffAndDebuffList[i].ap);
             buffApPCT2 += (buffAndDebuffList[i].apPCT);
             buffDef2 += (buffAndDebuffList[i].def);
             buffDefPCT2 += (buffAndDebuffList[i].defPCT);
             buffMdef2 += (buffAndDebuffList[i].mdef);
             buffMdefPCT2 += (buffAndDebuffList[i].mdefPCT);
             buffSpeed2 += (buffAndDebuffList[i].speed);
             buffSpeedPCT2 += (buffAndDebuffList[i].speedPCT);
             buffDodge2 += (buffAndDebuffList[i].dodge);
             //buffDodgePCT2 += (buffAndDebuffList[i].dodgePCT* (1 + (buffObjectList[i].GetComponent<EnemyUI>().iq / 1000)) * buffAndDebuffList[i].dodgePCT);
             buffCrit2 += (buffAndDebuffList[i].crit);
             //buffCritPCT2 += (buffAndDebuffList[i].critPCT * buffAndDebuffList[i].critPCT);
             buffIq2 += (buffAndDebuffList[i].iq);
             buffIqPCT2 += (buffAndDebuffList[i].iqPCT);
             buffCharm2 += (buffAndDebuffList[i].charm);
             buffCharmPCT2 += (buffAndDebuffList[i].charmPCT);
             buffCritDamge2 += (buffAndDebuffList[i].critDamge);
            // buffCritDamgePCT2 += (buffAndDebuffList[i].critDamgePCT * buffAndDebuffList[i].critDamgePCT);
             buffDrainLife2 += (buffAndDebuffList[i].drainLife);
             //buffDrainLifePCT2 += (buffAndDebuffList[i].drainLifePCT * buffAndDebuffList[i].drainLifePCT);
             buffReplyHp2 += (buffAndDebuffList[i].replyHp);
             buffReplyHpPCT2 += (buffAndDebuffList[i].replyHpPCT);
             buffReplyMp2 += (buffAndDebuffList[i].replyMp);
             buffReplyMpPCT2 += (buffAndDebuffList[i].replyMpPCT);
             buffReplySp2 += (buffAndDebuffList[i].replySp);
             buffReplySpPCT2 += (buffAndDebuffList[i].replySpPCT);
             buffSkillOdds2 += buffAndDebuffList[i].skillOdds;
             buffSword2 += buffAndDebuffList[i].sword;
             buffGun2 += buffAndDebuffList[i].gun;
                 }

                 
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
               for(int j = 0; j < buffManage.transform.childCount; j++)
               {
                   if(buffManage.transform.GetChild(j).gameObject.GetComponent<Buff>().buff == buffAndDebuffList[i])
                   {
                       buffManage.transform.GetChild(j).gameObject.GetComponent<Buff>().buffHeld -= 1;
                   }

               }
               buffAndDebuffList[i] = null;//清除buff
               buffObjectList[i] = null;
           }
       }

}
public void Action()//行动机制
{
    Sword();
    Gun();
    //Shield();
    //Book();
    CharmSkill();
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
     
     gameObject.transform.DOMove(new Vector3(actionPosition.transform.position.x, actionPosition.transform.position.y, 0f), 0.2f);
     gameObject.transform.DOMove(new Vector3(originalPosition.transform.position.x, originalPosition.transform.position.y, 0f), 0.8f);//战斗移动
     
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
         targetEnemyUnit.GetComponent<PlayerBattle>().player.damageNumObjectIsAlive = true;//伤害数值显示
        targetEnemyUnit.GetComponent<PlayerBattle>().player.dodgeString = "闪避";
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
                    
                    if(gameObject.GetComponent<EnemyUI>().buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(buffList.buffList[0]))
                              {
                                  for(int k = 0; k < gameObject.GetComponent<EnemyUI>().buffManage.transform.childCount ; k++)
                                  {
                                      if(gameObject.GetComponent<EnemyUI>().buffManage.transform.GetChild(k).GetComponent<Buff>().buff == buffList.buffList[0])
                                      {
                                          gameObject.GetComponent<EnemyUI>().buffManage.transform.GetChild(k).GetComponent<Buff>().buffHeld += 1;
                                          break;
                                      }
                                  }
                              }
                    
                   if(!gameObject.GetComponent<EnemyUI>().buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(buffList.buffList[0]))
                              {
                              gameObject.GetComponent<EnemyUI>().buffManage.GetComponent<EnemyBuffManager>().buffList.Add(buffList.buffList[0]);   
                              GameObject buffObject = Instantiate(buffPrefabObject);
                              buffObject.transform.parent = gameObject.GetComponent<EnemyUI>().buffManage.transform;                              
                              buffObject.GetComponent<Buff>().buffHeld = 1;
                              buffObject.GetComponent<Buff>().buff = buffList.buffList[0];
                              }
                             
                              buffInfoIsAlive = true;
                              buffInfo = buffList.buffList[0].buffString;
                              //buff显示
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
             targetEnemyUnit.GetComponent<PlayerBattle>().player.damageNumObjectIsAlive = true;//伤害数值显示
            targetEnemyUnit.GetComponent<PlayerBattle>().player.damageNumber = damageList[i];
            break;
        }
    }

}
public void Shield()//盾防机制
{
   
      List<GameObject> untargetUnitList = new List<GameObject>();
    
     for (int i = 0; i < targetEnemyUnitList.Count; i++)
     {Debug.Log("111");
         if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnit != gameObject)
         {
             untargetUnitList.Add(targetEnemyUnitList[i]);
         }
     }
     
     if(untargetUnitList.Count != 0)
     {
     int randomIndex =  Random.Range(0, untargetUnitList.Count);
     untargetUnitList[randomIndex].GetComponent<PlayerBattle>().player.targetEnemyUnit = gameObject;
     untargetUnitList.Remove(untargetUnitList[randomIndex]);
        if(untargetUnitList.Count != 0)
        {
             int randomIndex1 =  Random.Range(0, untargetUnitList.Count);
             untargetUnitList[randomIndex1].GetComponent<PlayerBattle>().player.targetEnemyUnit = gameObject;
             untargetUnitList.Remove(untargetUnitList[randomIndex1]);
        }
     }
     untargetUnitList.Clear();

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
                 if(gameObject.GetComponent<EnemyUI>().buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(buffList.buffList[equipmentList[i].shieldFactor]))
                              {
                                  for(int k = 0; k < gameObject.GetComponent<EnemyUI>().buffManage.transform.childCount ; k++)
                                  {
                                      if(gameObject.GetComponent<EnemyUI>().buffManage.transform.GetChild(k).GetComponent<Buff>().buff == buffList.buffList[equipmentList[i].shieldFactor])
                                      {
                                          gameObject.GetComponent<EnemyUI>().buffManage.transform.GetChild(k).GetComponent<Buff>().buffHeld += 1;
                                          break;
                                      }
                                  }
                              }
                  
                   if(!gameObject.GetComponent<EnemyUI>().buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(buffList.buffList[equipmentList[i].shieldFactor]))
                              {
                              gameObject.GetComponent<EnemyUI>().buffManage.GetComponent<EnemyBuffManager>().buffList.Add(buffList.buffList[equipmentList[i].shieldFactor]);   
                              GameObject buffObject = Instantiate(buffPrefabObject);
                              buffObject.transform.parent = gameObject.GetComponent<EnemyUI>().buffManage.transform;                              
                              buffObject.GetComponent<Buff>().buffHeld = 1;
                              buffObject.GetComponent<Buff>().buff = buffList.buffList[equipmentList[i].shieldFactor];
                              }
                              buffInfoIsAlive = true;
                              buffInfo = buffList.buffList[equipmentList[i].shieldFactor].buffString;
                              //buff显示
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
public void CharmSkill()
{
    charmSkillBool = false;
    for (int i = 0; i < equipmentList.Count; i++)
    {
        if(equipmentList[i] != null)
        {
            if(equipmentList[i].charmSkillBool == true)
            {
                charmSkillBool = true;
                break;
            }
        }
    }
    apSkillBool = false;
    for (int i = 0; i < equipmentList.Count; i++)
    {
        if(equipmentList[i] != null)
        {
            if(equipmentList[i].apSkillBool == true)
            {
                apSkillBool = true;
                break;
            }
        }
    }
    iqSkillBool = false;
    for (int i = 0; i < equipmentList.Count; i++)
    {
        if(equipmentList[i] != null)
        {
            if(equipmentList[i].iqSkillBool == true)
            {
                iqSkillBool = true;
                break;
            }
        }
    }
    doubleDamage = false;
    for (int i = 0; i < equipmentList.Count; i++)
    {
        if(equipmentList[i] != null)
        {
            if(equipmentList[i].doubleDamage == true)
            {
                doubleDamage = true;
                break;
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
                           

                             if(gameObject.GetComponent<EnemyUI>().buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(buffList.buffList[number]))
                              {
                                  for(int k = 0; k < gameObject.GetComponent<EnemyUI>().buffManage.transform.childCount ; k++)
                                  {
                                      if(gameObject.GetComponent<EnemyUI>().buffManage.transform.GetChild(k).GetComponent<Buff>().buff == buffList.buffList[number])
                                      {
                                          gameObject.GetComponent<EnemyUI>().buffManage.transform.GetChild(k).GetComponent<Buff>().buffHeld += 1;
                                          break;
                                      }
                                  }
                              }
                        if(!gameObject.GetComponent<EnemyUI>().buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(buffList.buffList[number]))
                              {
                              gameObject.GetComponent<EnemyUI>().buffManage.GetComponent<EnemyBuffManager>().buffList.Add(buffList.buffList[number]);   
                              GameObject buffObject = Instantiate(buffPrefabObject);
                              buffObject.transform.parent = gameObject.GetComponent<EnemyUI>().buffManage.transform;                              
                              buffObject.GetComponent<Buff>().buffHeld = 1;
                              buffObject.GetComponent<Buff>().buff = buffList.buffList[number];
                              }
                              buffInfoIsAlive = true;
                              buffInfo = buffList.buffList[number].buffString;
                              //buff显示
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
                            

                            if(targetPlayerUnit.GetComponent<EnemyUI>().buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(buffList.buffList[number]))
                              {
                                  for(int k = 0; k < targetPlayerUnit.GetComponent<EnemyUI>().buffManage.transform.childCount ; k++)
                                  {
                                      if(targetPlayerUnit.GetComponent<EnemyUI>().buffManage.transform.GetChild(k).GetComponent<Buff>().buff == buffList.buffList[number])
                                      {
                                          targetPlayerUnit.GetComponent<EnemyUI>().buffManage.transform.GetChild(k).GetComponent<Buff>().buffHeld += 1;
                                          break;
                                      }
                                  }
                              }
                             if(!targetPlayerUnit.GetComponent<EnemyUI>().buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(buffList.buffList[number]))
                              {
                              targetPlayerUnit.GetComponent<EnemyUI>().buffManage.GetComponent<EnemyBuffManager>().buffList.Add(buffList.buffList[number]);   
                              GameObject buffObject = Instantiate(buffPrefabObject);
                              buffObject.transform.parent = targetPlayerUnit.GetComponent<EnemyUI>().buffManage.transform;                              
                              buffObject.GetComponent<Buff>().buffHeld = 1;
                              buffObject.GetComponent<Buff>().buff = buffList.buffList[number];
                              }
                              buffInfoIsAlive = true;
                              buffInfo = buffList.buffList[number].buffString;
                              //buff显示
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
                            
                             if(targetEnemyUnit.GetComponent<PlayerBattle>().player.buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(buffList.buffList[number]))
                              {
                                  for(int l = 0; l < targetEnemyUnit.GetComponent<PlayerBattle>().player.buffManage.transform.childCount ; l++)
                                  {
                                      if(targetEnemyUnit.GetComponent<PlayerBattle>().player.buffManage.transform.GetChild(l).GetComponent<Buff>().buff == buffList.buffList[number])
                                      {
                                          targetEnemyUnit.GetComponent<PlayerBattle>().player.buffManage.transform.GetChild(l).GetComponent<Buff>().buffHeld += 1;
                                          break;
                                      }
                                  }
                              }

                             if(!targetEnemyUnit.GetComponent<PlayerBattle>().player.buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(buffList.buffList[number]))
                              {
                              targetEnemyUnit.GetComponent<PlayerBattle>().player.buffManage.GetComponent<EnemyBuffManager>().buffList.Add(buffList.buffList[number]);   
                              GameObject buffObject = Instantiate(buffPrefabObject);
                              buffObject.transform.parent = targetEnemyUnit.GetComponent<PlayerBattle>().player.buffManage.transform;                              
                              buffObject.GetComponent<Buff>().buffHeld = 1;
                              buffObject.GetComponent<Buff>().buff = buffList.buffList[number];
                              }
                             
                              
                              //buff显示
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
            float damage = (ad - targetEnemyUnit.GetComponent<PlayerBattle>().player.def);
            if(damage <= 0 )
           {
             damage = 1;
           }  
           targetEnemyUnit.GetComponent<PlayerBattle>().player.hp -= damage; 
           
           for (int m = 0; m < damageList.Count; m++)
           {
                  if(damageList[m] == 0)
                {
                   damageList[m] = damage; 
                   if(damageList[m] <= 0)
                   {
                         damageList[m] = 1;
                   } 
                   //skillName = "攻击";
                   //skillNameIsAlive = true;                                 
                   targetEnemyUnit.GetComponent<PlayerBattle>().player.damageNumObjectIsAlive = true;//伤害数值显示
                   targetEnemyUnit.GetComponent<PlayerBattle>().player.damageNumber = damageList[m];                   
                   break;
                }
           }   
        }
        if(critNumber <= crit)
        {  
             float damage = ((ad - targetEnemyUnit.GetComponent<PlayerBattle>().player.def) * (1.0f + critDamge));
            if(damage <= 0 )
           {
             damage = 1;
           }  
           targetEnemyUnit.GetComponent<PlayerBattle>().player.hp -= damage;
           for (int m = 0; m < damageList.Count; m++)
           {
                  if(damageList[m] == 0)
                {
                   damageList[m] = damage;
                   if(damageList[m] <= 0)
                   {
                         damageList[m] = 1;
                   }   
                   skillName = "暴击";
                   skillNameIsAlive = true;                   
                   targetEnemyUnit.GetComponent<PlayerBattle>().player.damageNumObjectIsAlive = true;//伤害数值显示
                   targetEnemyUnit.GetComponent<PlayerBattle>().player.damageNumber = damageList[m];
                   break;
                }
           }

        }
   
}

public void Skill()//主动技能
{
 List<Skill> activeSkillList = new List<Skill>();
for (int i = 0; i < skillList.Count; i++)
    { 
        if(skillList[i].activeSkill)
      {      
            activeSkillList.Add(skillList[i]);       
      }
        int targetSkillID;
        targetSkillID = Random.Range(0 , activeSkillList.Count);
        /*if(activeSkillList[targetSkillID] == null)
        {
            continue;
        }*/
        if(activeSkillList[targetSkillID] != null)
        {
            if(activeSkillList[targetSkillID].activeSkill)
            {      
                 if(mp >= activeSkillList[targetSkillID].mp && sp >= activeSkillList[targetSkillID].sp && hp >= activeSkillList[targetSkillID].hp )
                {
                   mp -= activeSkillList[targetSkillID].mp;
                   sp -= activeSkillList[targetSkillID].sp;
                   hp -= activeSkillList[targetSkillID].hp;
                   gameObject.transform.DOMove(new Vector3( actionPosition.transform.position.x, actionPosition.transform.position.y, 0f), 0.2f);
                   gameObject.transform.DOMove(new Vector3( originalPosition.transform.position.x, originalPosition.transform.position.y, 0f), 0.8f);//战斗移动
                
                   if(activeSkillList[targetSkillID].singleDamage)//单体伤害技能
                   {
                        if(activeSkillList[targetSkillID].singleDamageName)
                    {                          
                        skillName = activeSkillList[targetSkillID].skillName;
                        skillNameIsAlive = true; 
                    }    
                    if(activeSkillList[targetSkillID].adSkill)
                    {  
                        float damage = ((ad - targetEnemyUnit.GetComponent<PlayerBattle>().player.def) * (activeSkillList[targetSkillID].adSkillFactor));
                         if(damage <= 0 )
                        {
                          damage = 1;
                        }  
                       targetEnemyUnit.GetComponent<PlayerBattle>().player.hp -= damage;
                      for (int n = 0; n < damageList.Count; n++)
                       {
                           if(damageList[n] == 0)
                           {
                               damageList[n] = damage;
                                if(damageList[n] <= 0)
                            {
                             damageList[n] = 1;
                            }   
                              
                               targetEnemyUnit.GetComponent<PlayerBattle>().player.damageNumObjectIsAlive = true;//伤害数值显示
                               targetEnemyUnit.GetComponent<PlayerBattle>().player.damageNumber = damageList[n];
                               break;
                           }
                       }
    
                       break;
                    }
                    if(activeSkillList[targetSkillID].hpSkill)
                    {  
                        float damage = ((totalhp - targetEnemyUnit.GetComponent<PlayerBattle>().player.def) * activeSkillList[targetSkillID].hpSkillFactor);
                         if(damage <= 0 )
                        {
                          damage = 1;
                        }  
                       targetEnemyUnit.GetComponent<PlayerBattle>().player.hp -= damage;
                       for (int n = 0; n < damageList.Count; n++)
                       {
                           if(damageList[n] == 0)
                           {
                               damageList[n] = damage;
                                if(damageList[n] <= 0)
                         {
                             damageList[n] = 1;
                         }     
                                            
                               targetEnemyUnit.GetComponent<PlayerBattle>().player.damageNumObjectIsAlive = true;//伤害数值显示
                               targetEnemyUnit.GetComponent<PlayerBattle>().player.damageNumber = damageList[n];
                               break;
                           }
                       }
    
                       break;
                    }
                    if(activeSkillList[targetSkillID].apSkill)
                    {  
                       float damage = ((ap - targetEnemyUnit.GetComponent<PlayerBattle>().player.mdef) * activeSkillList[targetSkillID].apSkillFactor);
                         if(damage <= 0 )
                        {
                          damage = 1;
                        }  
                       targetEnemyUnit.GetComponent<PlayerBattle>().player.hp -= damage;
                       for (int m = 0; m < damageList.Count; m++)
                       {
                         if(damageList[m] == 0)
                         {
                            damageList[m] = damage;
                            if(damageList[m] <= 0)
                         {
                             damageList[m] = 1;
                         }        
                                    
                            targetEnemyUnit.GetComponent<PlayerBattle>().player.damageNumObjectIsAlive = true;//伤害数值显示
                            targetEnemyUnit.GetComponent<PlayerBattle>().player.damageNumber = damageList[m];
                            break;
                         }
                       }
                       break; 
                    }
                    if(activeSkillList[targetSkillID].iqSkill)
                    {  
                       float damage = ((iq * activeSkillList[targetSkillID].iqSkillFactor) - (targetEnemyUnit.GetComponent<PlayerBattle>().player.mdef * activeSkillList[targetSkillID].iqSkillFactor));
                         if(damage <= 0 )
                        {
                          damage = 1;
                        }  
                       targetEnemyUnit.GetComponent<PlayerBattle>().player.hp -= damage;
                       for (int m = 0; m < damageList.Count; m++)
                       {
                         if(damageList[m] == 0)
                         {
                            damageList[m] = damage;
                               if(damageList[m] <= 0)
                             {
                                damageList[m] = 1;
                             }        
                                 
                            targetEnemyUnit.GetComponent<PlayerBattle>().player.damageNumObjectIsAlive = true;//伤害数值显示
                            targetEnemyUnit.GetComponent<PlayerBattle>().player.damageNumber = damageList[m];
                            break;
                         }
                       }
                       break; 
                    }
                   }
                   if(activeSkillList[targetSkillID].teamDamage)//群体伤害技能
                   {
                        if(activeSkillList[targetSkillID].teamDamageName)
                    {                          
                       skillName = activeSkillList[targetSkillID].skillName;
                        skillNameIsAlive = true; 
                    }    
                    if(activeSkillList[targetSkillID].adSkill)
                    {  
                       for (int j = 0; j < targetEnemyUnitList.Count; j++)
                       {  
                           float damage = ((ad * activeSkillList[targetSkillID].adSkillFactor) - (targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.def * activeSkillList[targetSkillID].adSkillFactor));
                          if(damage <= 0 )
                         {
                          damage = 1;
                         }  
                           targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.targetUnit = gameObject;
                           targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.hp -= damage;
                
                           
                           for (int m = 0; m < damageList.Count; m++)
                          {
                              if(damageList[m] == 0)
                            { 
                               damageList[m] = damage;
                                if(damageList[m] <= 0)
                             {
                                damageList[m] = 1;
                             }     
                             
                               targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.damageNumObjectIsAlive = true;//伤害数值显示
                               targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.damageNumber = damageList[m];
                               break;
                            }
                          }
                       }
                       break;
                    }
                    if(activeSkillList[targetSkillID].hpSkill)
                    {  
                       for (int j = 0; j < targetEnemyUnitList.Count; j++)
                       {  
                            float damage = ((totalhp * activeSkillList[targetSkillID].hpSkillFactor) - (targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.def * activeSkillList[targetSkillID].hpSkillFactor));
                            if(damage <= 0 )
                           {
                             damage = 1;
                           }
                           targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.targetUnit = gameObject;  
                           targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.hp -= damage;
                
                           
                          for (int m = 0; m < damageList.Count; m++)
                          {
                              if(damageList[m] == 0)
                            { 
                               damageList[m] = damage;
                                if(damageList[m] <= 0)
                             {
                                damageList[m] = 1;
                             }   
                                         
                               targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.damageNumObjectIsAlive = true;//伤害数值显示
                               targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.damageNumber = damageList[m];
                               break;
                            }
                          }
                       }
                       break;
                    }
                    if(activeSkillList[targetSkillID].apSkill)
                    {
                        for (int j = 0; j < targetEnemyUnitList.Count; j++)
                       {   
                            float damage = ((ap * activeSkillList[targetSkillID].apSkillFactor) - (targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.mdef * activeSkillList[targetSkillID].apSkillFactor));
                            if(damage <= 0 )
                           {
                             damage = 1;
                           }   
                           targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.targetUnit = gameObject;                      
                           targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.hp -= damage;
                           
                           for (int m = 0; m < damageList.Count; m++)
                          {
                              if(damageList[m] == 0)
                             { 
                               damageList[m] = damage;
                                if(damageList[m] <= 0)
                             {
                                damageList[m] = 1;
                             }        
                                     
                               targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.damageNumObjectIsAlive = true;//伤害数值显示
                               targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.damageNumber = damageList[m];
                               break;
                            }
                          }
                          
                       }
                       break;
                    }
                    if(activeSkillList[targetSkillID].iqSkill)
                    {
                        for (int j = 0; j < targetEnemyUnitList.Count; j++)
                       {     
                           float damage = ((iq * activeSkillList[targetSkillID].iqSkillFactor) - (targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.mdef * activeSkillList[targetSkillID].iqSkillFactor));
                            if(damage <= 0 )
                           {
                             damage = 1;
                           }   
                           targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.targetUnit = gameObject;                        
                           targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.hp -= damage;
                           
                           for (int m = 0; m < damageList.Count; m++)
                          {
                              if(damageList[m] == 0)
                             { 
                               damageList[m] = damage;
                                if(damageList[m] <= 0)
                             {
                                damageList[m] = 1;
                             }    
                             
                               targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.damageNumObjectIsAlive = true;//伤害数值显示
                               targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.damageNumber = damageList[m];
                               break;
                            }
                          }
                       }
                       break;
                    }
                   }
                   if(activeSkillList[targetSkillID].singleDebuff && !activeSkillList[targetSkillID].dizzy)//单体debuff
                   {
                        if(activeSkillList[targetSkillID].singleDebuffName)
                    {                          
                       skillName = activeSkillList[targetSkillID].skillName;
                        skillNameIsAlive = true; 
                    }    
                         for (int j = 0; j < targetEnemyUnit.GetComponent<PlayerBattle>().player.buffAndDebuffList.Count ; j++)
                         {
                             if(targetEnemyUnit.GetComponent<PlayerBattle>().player.buffAndDebuffList[j] == null)
                             {
                              targetEnemyUnit.GetComponent<PlayerBattle>().player.buffObjectList[j] = gameObject;
                              targetEnemyUnit.GetComponent<PlayerBattle>().player.buffTime[j] = activeSkillList[targetSkillID].buff.buffTime;
                              targetEnemyUnit.GetComponent<PlayerBattle>().player.buffAndDebuffList[j] = activeSkillList[targetSkillID].buff;
                              
                              
                              if(targetEnemyUnit.GetComponent<PlayerBattle>().player.buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(activeSkillList[targetSkillID].buff))
                              {
                                  for(int l = 0; l < targetEnemyUnit.GetComponent<PlayerBattle>().player.buffManage.transform.childCount ; l++)
                                  {
                                      if(targetEnemyUnit.GetComponent<PlayerBattle>().player.buffManage.transform.GetChild(l).GetComponent<Buff>().buff == activeSkillList[targetSkillID].buff)
                                      {
                                          targetEnemyUnit.GetComponent<PlayerBattle>().player.buffManage.transform.GetChild(l).GetComponent<Buff>().buffHeld += 1;
                                          break;
                                      }
                                  }
                              }
                              if(!targetEnemyUnit.GetComponent<PlayerBattle>().player.buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(activeSkillList[targetSkillID].buff))
                              {
                              targetEnemyUnit.GetComponent<PlayerBattle>().player.buffManage.GetComponent<EnemyBuffManager>().buffList.Add(activeSkillList[targetSkillID].buff);   
                              GameObject buffObject = Instantiate(buffPrefabObject);
                              buffObject.transform.parent = targetEnemyUnit.GetComponent<PlayerBattle>().player.buffManage.transform;                              
                              buffObject.GetComponent<Buff>().buffHeld = 1;
                              buffObject.GetComponent<Buff>().buff = activeSkillList[targetSkillID].buff;
                              }
                              
                              
                              //buff显示
                              break;
                             }
                         }
                     break;
                   }
                   if(activeSkillList[targetSkillID].singleDebuff && activeSkillList[targetSkillID].dizzy)//单体眩晕
                   {
                        if(activeSkillList[targetSkillID].singleDebuffName)
                    {                          
                       skillName = activeSkillList[targetSkillID].skillName;
                        skillNameIsAlive = true; 
                    }    
                    if(charm >= targetEnemyUnit.GetComponent<PlayerBattle>().player.charm)
                    {  
                        for (int j = 0; j < targetEnemyUnit.GetComponent<PlayerBattle>().player.buffAndDebuffList.Count ; j++)
                       {
                           if(targetEnemyUnit.GetComponent<PlayerBattle>().player.buffAndDebuffList[j] == null)
                           {
                            targetEnemyUnit.GetComponent<PlayerBattle>().player.buffTime[j] = activeSkillList[targetSkillID].buff.buffTime;
                            targetEnemyUnit.GetComponent<PlayerBattle>().player.buffObjectList[j] = gameObject;
                            targetEnemyUnit.GetComponent<PlayerBattle>().player.buffAndDebuffList[j] = activeSkillList[targetSkillID].buff;
                            
                           
                            if(targetEnemyUnit.GetComponent<PlayerBattle>().player.buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(activeSkillList[targetSkillID].buff))
                              {
                                  for(int l = 0; l < targetEnemyUnit.GetComponent<PlayerBattle>().player.buffManage.transform.childCount ; l++)
                                  {
                                      if(targetEnemyUnit.GetComponent<PlayerBattle>().player.buffManage.transform.GetChild(l).GetComponent<Buff>().buff == activeSkillList[targetSkillID].buff)
                                      {
                                          targetEnemyUnit.GetComponent<PlayerBattle>().player.buffManage.transform.GetChild(l).GetComponent<Buff>().buffHeld += 1;
                                          break;
                                      }
                                  }
                              }
                            
                             if(!targetEnemyUnit.GetComponent<PlayerBattle>().player.buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(activeSkillList[targetSkillID].buff))
                              {
                              targetEnemyUnit.GetComponent<PlayerBattle>().player.buffManage.GetComponent<EnemyBuffManager>().buffList.Add(activeSkillList[targetSkillID].buff);   
                              GameObject buffObject = Instantiate(buffPrefabObject);
                              buffObject.transform.parent = targetEnemyUnit.GetComponent<PlayerBattle>().player.buffManage.transform;                              
                              buffObject.GetComponent<Buff>().buffHeld = 1;
                              buffObject.GetComponent<Buff>().buff = activeSkillList[targetSkillID].buff;
                              }
                              
                              
                              //buff显示
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
                   if(activeSkillList[targetSkillID].teamDebuff && !activeSkillList[targetSkillID].dizzy)//群体debuff
                   {
                        if(activeSkillList[targetSkillID].teamDebuffName)
                    {                          
                       skillName = activeSkillList[targetSkillID].skillName;
                        skillNameIsAlive = true; 
                    }    
                    for (int j = 0; j < targetEnemyUnitList.Count; j++)
                    {
                        if(targetEnemyUnitList[j] != null)
                        {
                            for (int k = 0; k < targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffAndDebuffList.Count; k++)
                            {
                                if(targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffAndDebuffList == null)
                                {
                                    targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffTime[k] = activeSkillList[targetSkillID].buff.buffTime;
                                    targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffObjectList[k] = gameObject;
                                    targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffAndDebuffList[k] = activeSkillList[targetSkillID].buff;
                                    
                                    
                                     if(targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(activeSkillList[targetSkillID].buff))
                              {
                                  for(int l = 0; l < targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffManage.transform.childCount ; l++)
                                  {
                                      if(targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffManage.transform.GetChild(l).GetComponent<Buff>().buff == activeSkillList[targetSkillID].buff)
                                      {
                                          targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffManage.transform.GetChild(l).GetComponent<Buff>().buffHeld += 1;
                                          break;
                                      }
                                  }
                              }
                                      if(!targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(activeSkillList[targetSkillID].buff))
                              {
                              targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffManage.GetComponent<EnemyBuffManager>().buffList.Add(activeSkillList[targetSkillID].buff);   
                              GameObject buffObject = Instantiate(buffPrefabObject);
                              buffObject.transform.parent = targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffManage.transform;                              
                              buffObject.GetComponent<Buff>().buffHeld = 1;
                              buffObject.GetComponent<Buff>().buff = activeSkillList[targetSkillID].buff;
                              }
                             
                              //buff显示
                                    break;
                                }
                            }
                        }
                    }
                    break;

                   }
                   if(activeSkillList[targetSkillID].teamDebuff && activeSkillList[targetSkillID].dizzy)//群体眩晕
                   {
                         if(activeSkillList[targetSkillID].teamDebuffName)
                    {                          
                       skillName = activeSkillList[targetSkillID].skillName;
                        skillNameIsAlive = true; 
                    }    
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
                                       targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffTime[k] = activeSkillList[targetSkillID].buff.buffTime;
                                       targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffObjectList[k] = gameObject;
                                       targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffAndDebuffList[k] = activeSkillList[targetSkillID].buff;
                                      
                                   
                                       if(targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(activeSkillList[targetSkillID].buff))
                              {
                                  for(int l = 0; l < targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffManage.transform.childCount ; l++)
                                  {
                                      if(targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffManage.transform.GetChild(l).GetComponent<Buff>().buff == activeSkillList[targetSkillID].buff)
                                      {
                                          targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffManage.transform.GetChild(l).GetComponent<Buff>().buffHeld += 1;
                                          break;
                                      }
                                  }
                              }
                                      if(!targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(activeSkillList[targetSkillID].buff))
                              {
                              targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffManage.GetComponent<EnemyBuffManager>().buffList.Add(activeSkillList[targetSkillID].buff);   
                              GameObject buffObject = Instantiate(buffPrefabObject);
                              buffObject.transform.parent = targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffManage.transform;                              
                              buffObject.GetComponent<Buff>().buffHeld = 1;
                              buffObject.GetComponent<Buff>().buff = activeSkillList[targetSkillID].buff;
                              }
                             
                              //buff显示
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
                   if(activeSkillList[targetSkillID].singleBuff)//队友buff
                   {
                         if(activeSkillList[targetSkillID].singleBuffName)
                    {                          
                       skillName = activeSkillList[targetSkillID].skillName;
                        skillNameIsAlive = true; 
                    }    
                    for (int j = 0; j < targetPlayerUnit.GetComponent<EnemyUI>().buffAndDebuffList.Count; j++)
                    {
                        if(targetPlayerUnit.GetComponent<EnemyUI>().buffAndDebuffList[j] == null)
                        {
                           targetPlayerUnit.GetComponent<EnemyUI>().buffTime[j] = activeSkillList[targetSkillID].buff.buffTime;
                           targetPlayerUnit.GetComponent<EnemyUI>().buffObjectList[j] = gameObject;
                           targetPlayerUnit.GetComponent<EnemyUI>().buffAndDebuffList[j] = activeSkillList[targetSkillID].buff;
                           
                              
                             if(targetPlayerUnit.GetComponent<EnemyUI>().buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(activeSkillList[targetSkillID].buff))
                              {
                                  for(int k = 0; k < targetPlayerUnit.GetComponent<EnemyUI>().buffManage.transform.childCount ; k++)
                                  {
                                      if(targetPlayerUnit.GetComponent<EnemyUI>().buffManage.transform.GetChild(k).GetComponent<Buff>().buff == activeSkillList[targetSkillID].buff)
                                      {
                                          targetPlayerUnit.GetComponent<EnemyUI>().buffManage.transform.GetChild(k).GetComponent<Buff>().buffHeld += 1;
                                          break;
                                      }
                                  }
                              }
                           if(!targetPlayerUnit.GetComponent<EnemyUI>().buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(activeSkillList[targetSkillID].buff))
                              {
                              targetPlayerUnit.GetComponent<EnemyUI>().buffManage.GetComponent<EnemyBuffManager>().buffList.Add(activeSkillList[targetSkillID].buff);   
                              GameObject buffObject = Instantiate(buffPrefabObject);
                              buffObject.transform.parent = targetPlayerUnit.GetComponent<EnemyUI>().buffManage.transform;                              
                              buffObject.GetComponent<Buff>().buffHeld = 1;
                              buffObject.GetComponent<Buff>().buff = activeSkillList[targetSkillID].buff;
                              }
                              targetPlayerUnit.GetComponent<EnemyUI>().buffInfoIsAlive = true;
                              targetPlayerUnit.GetComponent<EnemyUI>().buffInfo = activeSkillList[targetSkillID].buff.buffString;
                              //buff显示
                           break;
                        }
                    }
                    break;
                   
                   }
                   if(activeSkillList[targetSkillID].ownBuff)//单体buff
                   {
                       if(activeSkillList[targetSkillID].ownBuffName)
                    {                          
                       skillName = activeSkillList[targetSkillID].skillName;
                        skillNameIsAlive = true; 
                    }    
                    for (int j = 0; j < buffAndDebuffList.Count; j++)
                    {
                        if(buffAndDebuffList[j] == null)
                        {
                        buffTime[j] = activeSkillList[targetSkillID].buff.buffTime;
                        buffObjectList[j] = gameObject;
                        buffAndDebuffList[j] = activeSkillList[targetSkillID].buff;



                         if(gameObject.GetComponent<EnemyUI>().buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(activeSkillList[targetSkillID].buff))
                              {
                                  for(int k = 0; k < gameObject.GetComponent<EnemyUI>().buffManage.transform.childCount ; k++)
                                  {
                                      if(gameObject.GetComponent<EnemyUI>().buffManage.transform.GetChild(k).GetComponent<Buff>().buff == activeSkillList[targetSkillID].buff)
                                      {
                                          gameObject.GetComponent<EnemyUI>().buffManage.transform.GetChild(k).GetComponent<Buff>().buffHeld += 1;
                                          break;
                                      }
                                  }
                              }
                        if(!gameObject.GetComponent<EnemyUI>().buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(activeSkillList[targetSkillID].buff))
                              {
                              gameObject.GetComponent<EnemyUI>().buffManage.GetComponent<EnemyBuffManager>().buffList.Add(activeSkillList[targetSkillID].buff);   
                              GameObject buffObject = Instantiate(buffPrefabObject);
                              buffObject.transform.parent = gameObject.GetComponent<EnemyUI>().buffManage.transform;                              
                              buffObject.GetComponent<Buff>().buffHeld = 1;
                              buffObject.GetComponent<Buff>().buff = activeSkillList[targetSkillID].buff;
                              }
                             buffInfoIsAlive = true;
                             buffInfo = activeSkillList[targetSkillID].buff.buffString;
                              //buff显示
                        break;
                        }
                    }
                    break;
                   }
                   if(activeSkillList[targetSkillID].teamBuff)//团队buff
                   {
                        if(activeSkillList[targetSkillID].teamBuffName)
                    {                          
                       skillName = activeSkillList[targetSkillID].skillName;
                        skillNameIsAlive = true; 
                    }    
                    for (int j = 0; j < targetPlayerUnitList.Count; j++)
                    {
                        if(targetPlayerUnitList[j] != null)
                        {
                            for (int k = 0; k < targetPlayerUnitList[j].GetComponent<EnemyUI>().buffAndDebuffList.Count; k++)
                            {
                                if(targetPlayerUnitList[j].GetComponent<EnemyUI>().buffAndDebuffList[k] == null)
                                {
                                    targetPlayerUnitList[j].GetComponent<EnemyUI>().buffTime[k] = activeSkillList[targetSkillID].buff.buffTime;
                                    targetPlayerUnitList[j].GetComponent<EnemyUI>().buffObjectList[k] = gameObject;
                                    targetPlayerUnitList[j].GetComponent<EnemyUI>().buffAndDebuffList[k] = activeSkillList[targetSkillID].buff;
                                    
                                    
                                     
                                 if(targetPlayerUnitList[j].GetComponent<EnemyUI>().buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(activeSkillList[targetSkillID].buff))
                              {
                                  for(int l = 0; l < targetPlayerUnitList[j].GetComponent<EnemyUI>().buffManage.transform.childCount ; l++)
                                  {
                                      if(targetPlayerUnitList[j].GetComponent<EnemyUI>().buffManage.transform.GetChild(l).GetComponent<Buff>().buff == activeSkillList[targetSkillID].buff)
                                      {
                                          targetPlayerUnitList[j].GetComponent<EnemyUI>().buffManage.transform.GetChild(l).GetComponent<Buff>().buffHeld += 1;
                                          break;
                                      }
                                  }
                              }
                                    if(!targetPlayerUnitList[j].GetComponent<EnemyUI>().buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(activeSkillList[targetSkillID].buff))
                              {
                              targetPlayerUnitList[j].GetComponent<EnemyUI>().buffManage.GetComponent<EnemyBuffManager>().buffList.Add(activeSkillList[targetSkillID].buff);   
                              GameObject buffObject = Instantiate(buffPrefabObject);
                              buffObject.transform.parent = targetPlayerUnitList[j].GetComponent<EnemyUI>().buffManage.transform;                              
                              buffObject.GetComponent<Buff>().buffHeld = 1;
                              buffObject.GetComponent<Buff>().buff = activeSkillList[targetSkillID].buff;
                              }
                              targetPlayerUnitList[j].GetComponent<EnemyUI>().buffInfoIsAlive = true;
                              targetPlayerUnitList[j].GetComponent<EnemyUI>().buffInfo = activeSkillList[targetSkillID].buff.buffString;
                              
                              //buff显示
                                    break;
                                }
                            }
                        }
                    }
                    break;
                   }
                
                }
                  if(mp < activeSkillList[targetSkillID].mp || sp < activeSkillList[targetSkillID].sp || hp < activeSkillList[targetSkillID].hp)
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
                if(charmSkillBool)
                {
                    int endSkillNum;
                    endSkillNum = Random.Range(0, 100);
                    if((endSkillNum - (charm * skillList[i].charmFactor)) <= skillList[i].endSkillOdd)
                {
                    if(skillList[i].teamDamage)//群体伤害技能
                   {
                       if(skillList[i].teamDamageName)
                    {                          
                       skillName = skillList[i].skillName;
                       skillNameIsAlive = true; 
                    }    
                    if(skillList[i].adSkill)
                    {  
                       for (int j = 0; j < targetEnemyUnitList.Count; j++)
                       {  
                           
                           float damage = ((ad * skillList[i].adSkillFactor) - (targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.def * skillList[i].adSkillFactor));
                            if(damage <= 0 )
                           {
                             damage = 1;
                           } 
                           targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.targetUnit = gameObject;    
                           targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.hp -= damage;
                
                           
                           for (int m = 0; m < damageList.Count; m++)
                          {
                              if(damageList[m] == 0)
                            { 
                               damageList[m] = damage;
                                if(damageList[m] <= 0)
                             {
                                damageList[m] = 1;
                             }     
                               targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.damageNumObjectIsAlive = true;//伤害数值显示
                               targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.damageNumber = damageList[m];
                               break;
                            }
                          }
                       }
                    }
                    if(skillList[i].hpSkill)
                    {  
                       for (int j = 0; j < targetEnemyUnitList.Count; j++)
                       {  
                           
                           float damage = ((totalhp * skillList[i].hpSkillFactor) - (targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.def * skillList[i].hpSkillFactor));
                            if(damage <= 0 )
                           {
                             damage = 1;
                           } 
                           targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.targetUnit = gameObject;   
                           targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.hp -= damage;
                
                           
                           for (int m = 0; m < damageList.Count; m++)
                          {
                              if(damageList[m] == 0)
                            { 
                               damageList[m] = damage;
                                if(damageList[m] <= 0)
                             {
                                damageList[m] = 1;
                             }        
                             
                               targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.damageNumObjectIsAlive = true;//伤害数值显示
                               targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.damageNumber = damageList[m];
                               break;
                            }
                          }
                       }
                    }
                    if(skillList[i].apSkill)
                    {
                        for (int j = 0; j < targetEnemyUnitList.Count; j++)
                       {       
                            float damage = ((ap * skillList[i].apSkillFactor) - (targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.mdef * skillList[i].apSkillFactor));
                            if(damage <= 0 )
                           {
                             damage = 1;
                           }   
                           targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.targetUnit = gameObject;                    
                           targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.hp -= damage;
                           
                            for (int m = 0; m < damageList.Count; m++)
                          {
                              if(damageList[m] == 0)
                             { 
                               damageList[m] = damage;
                                if(damageList[m] <= 0)
                             {
                                damageList[m] = 1;
                             }        
                           
                               targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.damageNumObjectIsAlive = true;//伤害数值显示
                               targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.damageNumber = damageList[m];
                               break;
                            }
                          }
                          
                       }
                    }
                    if(skillList[i].iqSkill)
                    {
                        for (int j = 0; j < targetEnemyUnitList.Count; j++)
                       {   
                           float damage = ((iq * skillList[i].iqSkillFactor) - (targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.mdef * skillList[i].iqSkillFactor));
                            if(damage <= 0 )
                           {
                             damage = 1;
                           }      
                           targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.targetUnit = gameObject;                       
                           targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.hp -= damage;
                           
                           for (int m = 0; m < damageList.Count; m++)
                          {
                              if(damageList[m] == 0)
                             { 
                               damageList[m] = damage;
                                if(damageList[m] <= 0)
                             {
                                damageList[m] = 1;
                             }     
                             
                               targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.damageNumObjectIsAlive = true;//伤害数值显示
                               targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.damageNumber = damageList[m];
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
                              
                             


                               if(targetEnemyUnit.GetComponent<PlayerBattle>().player.buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(skillList[i].buff))
                              {
                                  for(int l = 0; l < targetEnemyUnit.GetComponent<PlayerBattle>().player.buffManage.transform.childCount ; l++)
                                  {
                                      if(targetEnemyUnit.GetComponent<PlayerBattle>().player.buffManage.transform.GetChild(l).GetComponent<Buff>().buff == skillList[i].buff)
                                      {
                                          targetEnemyUnit.GetComponent<PlayerBattle>().player.buffManage.transform.GetChild(l).GetComponent<Buff>().buffHeld += 1;
                                          break;
                                      }
                                  }
                              }
                              if(!targetEnemyUnit.GetComponent<PlayerBattle>().player.buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(skillList[i].buff))
                              {
                              targetEnemyUnit.GetComponent<PlayerBattle>().player.buffManage.GetComponent<EnemyBuffManager>().buffList.Add(skillList[i].buff);   
                              GameObject buffObject = Instantiate(buffPrefabObject);
                              buffObject.transform.parent = targetEnemyUnit.GetComponent<PlayerBattle>().player.buffManage.transform;                              
                              buffObject.GetComponent<Buff>().buffHeld = 1;
                              buffObject.GetComponent<Buff>().buff = skillList[i].buff;
                              }
                             
                              
                              //buff显示
                              
                              
                              break;
                             }
                         }
                   }
                   if(skillList[i].singleDebuff &&skillList[i].dizzy)//单体眩晕
                   {    
                       if(skillList[i].singleDebuffName)
                    {                          
                       skillName = skillList[i].skillName;
                       skillNameIsAlive = true; 
                    }    
                      for (int j = 0; j < targetEnemyUnit.GetComponent<PlayerBattle>().player.buffAndDebuffList.Count; j++)
                         {  
                            if(targetEnemyUnit.GetComponent<PlayerBattle>().player.buffAndDebuffList[j] == null)
                            {
                            targetEnemyUnit.GetComponent<PlayerBattle>().player.buffTime[j] = skillList[i].buff.buffTime;
                            targetEnemyUnit.GetComponent<PlayerBattle>().player.buffObjectList[j] = gameObject;
                            targetEnemyUnit.GetComponent<PlayerBattle>().player.buffAndDebuffList[j] = skillList[i].buff;
                         
                            if(targetEnemyUnit.GetComponent<PlayerBattle>().player.buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(skillList[i].buff))
                              {
                                  for(int l = 0; l < targetEnemyUnit.GetComponent<PlayerBattle>().player.buffManage.transform.childCount ; l++)
                                  {
                                      if(targetEnemyUnit.GetComponent<PlayerBattle>().player.buffManage.transform.GetChild(l).GetComponent<Buff>().buff == skillList[i].buff)
                                      {
                                          targetEnemyUnit.GetComponent<PlayerBattle>().player.buffManage.transform.GetChild(l).GetComponent<Buff>().buffHeld += 1;
                                          break;
                                      }
                                  }
                              }
                            if(!targetEnemyUnit.GetComponent<PlayerBattle>().player.buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(skillList[i].buff))
                              {
                              targetEnemyUnit.GetComponent<PlayerBattle>().player.buffManage.GetComponent<EnemyBuffManager>().buffList.Add(skillList[i].buff);   
                              GameObject buffObject = Instantiate(buffPrefabObject);
                              buffObject.transform.parent = targetEnemyUnit.GetComponent<PlayerBattle>().player.buffManage.transform;                              
                              buffObject.GetComponent<Buff>().buffHeld = 1;
                              buffObject.GetComponent<Buff>().buff = skillList[i].buff;
                              }
                              
                              //buff显示
                            break;
                            }
                         }
                   }
                   if(skillList[i].teamDebuff && !skillList[i].dizzy)//群体debuff
                   {
                        if(skillList[i].teamDebuffName)
                    {                          
                       skillName = skillList[i].skillName;
                       skillNameIsAlive = true; 
                    }    
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
                                   

                                   
                                  if(targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(skillList[i].buff))
                              {
                                  for(int l = 0; l < targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffManage.transform.childCount ; l++)
                                  {
                                      if(targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffManage.transform.GetChild(l).GetComponent<Buff>().buff == skillList[i].buff)
                                      {
                                          targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffManage.transform.GetChild(l).GetComponent<Buff>().buffHeld += 1;
                                          break;
                                      }
                                  }
                              }
                                  
                                   if(!targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(skillList[i].buff))
                              {
                              targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffManage.GetComponent<EnemyBuffManager>().buffList.Add(skillList[i].buff);   
                              GameObject buffObject = Instantiate(buffPrefabObject);
                              buffObject.transform.parent = targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffManage.transform;                              
                              buffObject.GetComponent<Buff>().buffHeld = 1;
                              buffObject.GetComponent<Buff>().buff = skillList[i].buff;
                              }
                              
                              
                              //buff显示
                                    break;
                                }
                            }
                        }
                    }
                   }
                   if(skillList[i].ownBuff)//单体buff
                   {
                        if(skillList[i].ownBuffName)
                    {                          
                       skillName = skillList[i].skillName;
                       skillNameIsAlive = true; 
                    }    
                    for (int j = 0; j < buffAndDebuffList.Count; j++)
                    {
                        if(buffAndDebuffList[j] == null)
                        {
                        
                        buffTime[j] = skillList[i].buff.buffTime;
                        buffObjectList[j] = gameObject;
                        buffAndDebuffList[j] = skillList[i].buff;
                        
                       
                        if(gameObject.GetComponent<EnemyUI>().buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(skillList[i].buff))
                              {
                                  for(int k = 0; k < gameObject.GetComponent<EnemyUI>().buffManage.transform.childCount ; k++)
                                  {
                                      if(gameObject.GetComponent<EnemyUI>().buffManage.transform.GetChild(k).GetComponent<Buff>().buff == skillList[i].buff)
                                      {
                                          gameObject.GetComponent<EnemyUI>().buffManage.transform.GetChild(k).GetComponent<Buff>().buffHeld += 1;
                                          break;
                                      }
                                  }
                              }
                         if(!gameObject.GetComponent<EnemyUI>().buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(skillList[i].buff))
                              {
                              gameObject.GetComponent<EnemyUI>().buffManage.GetComponent<EnemyBuffManager>().buffList.Add(skillList[i].buff);   
                              GameObject buffObject = Instantiate(buffPrefabObject);
                              buffObject.transform.parent = gameObject.GetComponent<EnemyUI>().buffManage.transform;                              
                              buffObject.GetComponent<Buff>().buffHeld = 1;
                              buffObject.GetComponent<Buff>().buff = skillList[i].buff;
                              }
                              buffInfoIsAlive = true;
                              buffInfo = skillList[i].buff.buffString;
                              
                              //buff显示
                        
                        break;
                        }
                    }
                   }
                   if(skillList[i].teamBuff)//团队buff
                   {
                        if(skillList[i].teamBuffName)
                    {                          
                       skillName = skillList[i].skillName;
                       skillNameIsAlive = true; 
                    }    
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
                                    
                               
                                    if(targetPlayerUnitList[j].GetComponent<EnemyUI>().buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(skillList[i].buff))
                              {
                                  for(int l = 0; l < targetPlayerUnitList[j].GetComponent<EnemyUI>().buffManage.transform.childCount ; l++)
                                  {
                                      if(targetPlayerUnitList[j].GetComponent<EnemyUI>().buffManage.transform.GetChild(l).GetComponent<Buff>().buff == skillList[i].buff)
                                      {
                                          targetPlayerUnitList[j].GetComponent<EnemyUI>().buffManage.transform.GetChild(l).GetComponent<Buff>().buffHeld += 1;
                                          break;
                                      }
                                  }
                              }
                                     if(!targetPlayerUnitList[j].GetComponent<EnemyUI>().buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(skillList[i].buff))
                              {
                              targetPlayerUnitList[j].GetComponent<EnemyUI>().buffManage.GetComponent<EnemyBuffManager>().buffList.Add(skillList[i].buff);   
                              GameObject buffObject = Instantiate(buffPrefabObject);
                              buffObject.transform.parent = targetPlayerUnitList[j].GetComponent<EnemyUI>().buffManage.transform;                              
                              buffObject.GetComponent<Buff>().buffHeld = 1;
                              buffObject.GetComponent<Buff>().buff = skillList[i].buff;
                              }
                              targetPlayerUnitList[j].GetComponent<EnemyUI>().buffInfoIsAlive = true;
                              targetPlayerUnitList[j].GetComponent<EnemyUI>().buffInfo = skillList[i].buff.buffString;
                             
                              
                              //buff显示
                                    break;
                                }
                            }
                        }
                    }
                   }
                }
                if((endSkillNum - (charm * skillList[i].charmFactor)) > skillList[i].endSkillOdd)
                {
                    continue;
                }
                }
                if(!charmSkillBool)
                {
                    int endSkillNum;
                    endSkillNum = Random.Range(0, 100);
                    if((endSkillNum) <= skillList[i].endSkillOdd)
                {
                    if(skillList[i].teamDamage)//群体伤害技能
                   {
                       if(skillList[i].teamDamageName)
                    {                          
                       skillName = skillList[i].skillName;
                       skillNameIsAlive = true; 
                    }    
                    if(skillList[i].adSkill)
                    {  
                       for (int j = 0; j < targetEnemyUnitList.Count; j++)
                       {  
                           
                           float damage = ((ad * skillList[i].adSkillFactor) - (targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.def * skillList[i].adSkillFactor));
                            if(damage <= 0 )
                           {
                             damage = 1;
                           }  
                           targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.targetUnit = gameObject;   
                           targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.hp -= damage;
                
                           
                           for (int m = 0; m < damageList.Count; m++)
                          {
                              if(damageList[m] == 0)
                            { 
                               damageList[m] = damage;
                                if(damageList[m] <= 0)
                             {
                                damageList[m] = 1;
                             }     
                               targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.damageNumObjectIsAlive = true;//伤害数值显示
                               targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.damageNumber = damageList[m];
                               break;
                            }
                          }
                       }
                    }
                    if(skillList[i].hpSkill)
                    {  
                       for (int j = 0; j < targetEnemyUnitList.Count; j++)
                       {  
                           float damage = ((totalhp * skillList[i].hpSkillFactor) - (targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.def * skillList[i].hpSkillFactor));
                            if(damage <= 0 )
                           {
                             damage = 1;
                           } 
                           targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.targetUnit = gameObject;    
                           targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.hp -= damage;
                
                           
                           for (int m = 0; m < damageList.Count; m++)
                          {
                              if(damageList[m] == 0)
                            { 
                               damageList[m] = damage;
                                if(damageList[m] <= 0)
                             {
                                damageList[m] = 1;
                             }        
                             
                               targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.damageNumObjectIsAlive = true;//伤害数值显示
                               targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.damageNumber = damageList[m];
                               break;
                            }
                          }
                       }
                    }
                    if(skillList[i].apSkill)
                    {
                        for (int j = 0; j < targetEnemyUnitList.Count; j++)
                       {   
                           float damage = ((ap * skillList[i].apSkillFactor) - (targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.mdef * skillList[i].apSkillFactor));
                            if(damage <= 0 )
                           {
                             damage = 1;
                           }  
                           targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.targetUnit = gameObject;                          
                           targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.hp -= damage;
                           
                            for (int m = 0; m < damageList.Count; m++)
                          {
                              if(damageList[m] == 0)
                             { 
                               damageList[m] = damage;
                                if(damageList[m] <= 0)
                             {
                                damageList[m] = 1;
                             }        
                           
                               targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.damageNumObjectIsAlive = true;//伤害数值显示
                               targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.damageNumber = damageList[m];
                               break;
                            }
                          }
                          
                       }
                    }
                    if(skillList[i].iqSkill)
                    {
                        for (int j = 0; j < targetEnemyUnitList.Count; j++)
                       {           
                           float damage = ((iq * skillList[i].iqSkillFactor) - (targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.mdef * skillList[i].iqSkillFactor));
                            if(damage <= 0 )
                           {
                             damage = 1;
                           } 
                           targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.targetUnit = gameObject;                  
                           targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.hp -= damage;
                           
                           for (int m = 0; m < damageList.Count; m++)
                          {
                              if(damageList[m] == 0)
                             { 
                               damageList[m] = damage;
                                if(damageList[m] <= 0)
                             {
                                damageList[m] = 1;
                             }     
                             
                               targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.damageNumObjectIsAlive = true;//伤害数值显示
                               targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.damageNumber = damageList[m];
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
                              
                             


                               if(targetEnemyUnit.GetComponent<PlayerBattle>().player.buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(skillList[i].buff))
                              {
                                  for(int l = 0; l < targetEnemyUnit.GetComponent<PlayerBattle>().player.buffManage.transform.childCount ; l++)
                                  {
                                      if(targetEnemyUnit.GetComponent<PlayerBattle>().player.buffManage.transform.GetChild(l).GetComponent<Buff>().buff == skillList[i].buff)
                                      {
                                          targetEnemyUnit.GetComponent<PlayerBattle>().player.buffManage.transform.GetChild(l).GetComponent<Buff>().buffHeld += 1;
                                          break;
                                      }
                                  }
                              }
                              if(!targetEnemyUnit.GetComponent<PlayerBattle>().player.buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(skillList[i].buff))
                              {
                              targetEnemyUnit.GetComponent<PlayerBattle>().player.buffManage.GetComponent<EnemyBuffManager>().buffList.Add(skillList[i].buff);   
                              GameObject buffObject = Instantiate(buffPrefabObject);
                              buffObject.transform.parent = targetEnemyUnit.GetComponent<PlayerBattle>().player.buffManage.transform;                              
                              buffObject.GetComponent<Buff>().buffHeld = 1;
                              buffObject.GetComponent<Buff>().buff = skillList[i].buff;
                              }
                             
                              
                              //buff显示
                              
                              
                              break;
                             }
                         }
                   }
                   if(skillList[i].singleDebuff &&skillList[i].dizzy)//单体眩晕
                   {    
                       if(skillList[i].singleDebuffName)
                    {                          
                       skillName = skillList[i].skillName;
                       skillNameIsAlive = true; 
                    }    
                      for (int j = 0; j < targetEnemyUnit.GetComponent<PlayerBattle>().player.buffAndDebuffList.Count; j++)
                         {  
                            if(targetEnemyUnit.GetComponent<PlayerBattle>().player.buffAndDebuffList[j] == null)
                            {
                            targetEnemyUnit.GetComponent<PlayerBattle>().player.buffTime[j] = skillList[i].buff.buffTime;
                            targetEnemyUnit.GetComponent<PlayerBattle>().player.buffObjectList[j] = gameObject;
                            targetEnemyUnit.GetComponent<PlayerBattle>().player.buffAndDebuffList[j] = skillList[i].buff;
                         
                            if(targetEnemyUnit.GetComponent<PlayerBattle>().player.buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(skillList[i].buff))
                              {
                                  for(int l = 0; l < targetEnemyUnit.GetComponent<PlayerBattle>().player.buffManage.transform.childCount ; l++)
                                  {
                                      if(targetEnemyUnit.GetComponent<PlayerBattle>().player.buffManage.transform.GetChild(l).GetComponent<Buff>().buff == skillList[i].buff)
                                      {
                                          targetEnemyUnit.GetComponent<PlayerBattle>().player.buffManage.transform.GetChild(l).GetComponent<Buff>().buffHeld += 1;
                                          break;
                                      }
                                  }
                              }
                            if(!targetEnemyUnit.GetComponent<PlayerBattle>().player.buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(skillList[i].buff))
                              {
                              targetEnemyUnit.GetComponent<PlayerBattle>().player.buffManage.GetComponent<EnemyBuffManager>().buffList.Add(skillList[i].buff);   
                              GameObject buffObject = Instantiate(buffPrefabObject);
                              buffObject.transform.parent = targetEnemyUnit.GetComponent<PlayerBattle>().player.buffManage.transform;                              
                              buffObject.GetComponent<Buff>().buffHeld = 1;
                              buffObject.GetComponent<Buff>().buff = skillList[i].buff;
                              }
                              
                              //buff显示
                            break;
                            }
                         }
                   }
                   if(skillList[i].teamDebuff && !skillList[i].dizzy)//群体debuff
                   {
                        if(skillList[i].teamDebuffName)
                    {                          
                       skillName = skillList[i].skillName;
                       skillNameIsAlive = true; 
                    }    
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
                                   

                                   
                                  if(targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(skillList[i].buff))
                              {
                                  for(int l = 0; l < targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffManage.transform.childCount ; l++)
                                  {
                                      if(targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffManage.transform.GetChild(l).GetComponent<Buff>().buff == skillList[i].buff)
                                      {
                                          targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffManage.transform.GetChild(l).GetComponent<Buff>().buffHeld += 1;
                                          break;
                                      }
                                  }
                              }
                                  
                                   if(!targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(skillList[i].buff))
                              {
                              targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffManage.GetComponent<EnemyBuffManager>().buffList.Add(skillList[i].buff);   
                              GameObject buffObject = Instantiate(buffPrefabObject);
                              buffObject.transform.parent = targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffManage.transform;                              
                              buffObject.GetComponent<Buff>().buffHeld = 1;
                              buffObject.GetComponent<Buff>().buff = skillList[i].buff;
                              }
                              
                              
                              //buff显示
                                    break;
                                }
                            }
                        }
                    }
                   }
                   if(skillList[i].ownBuff)//单体buff
                   {
                        if(skillList[i].ownBuffName)
                    {                          
                       skillName = skillList[i].skillName;
                       skillNameIsAlive = true; 
                    }    
                    for (int j = 0; j < buffAndDebuffList.Count; j++)
                    {
                        if(buffAndDebuffList[j] == null)
                        {                    
                        buffTime[j] = skillList[i].buff.buffTime;
                        buffObjectList[j] = gameObject;
                        buffAndDebuffList[j] = skillList[i].buff;
                        
                       
                        if(gameObject.GetComponent<EnemyUI>().buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(skillList[i].buff))
                              {
                                  for(int k = 0; k < gameObject.GetComponent<EnemyUI>().buffManage.transform.childCount ; k++)
                                  {
                                      if(gameObject.GetComponent<EnemyUI>().buffManage.transform.GetChild(k).GetComponent<Buff>().buff == skillList[i].buff)
                                      {
                                          gameObject.GetComponent<EnemyUI>().buffManage.transform.GetChild(k).GetComponent<Buff>().buffHeld += 1;
                                          break;
                                      }
                                  }
                              }
                         if(!gameObject.GetComponent<EnemyUI>().buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(skillList[i].buff))
                              {
                              gameObject.GetComponent<EnemyUI>().buffManage.GetComponent<EnemyBuffManager>().buffList.Add(skillList[i].buff);   
                              GameObject buffObject = Instantiate(buffPrefabObject);
                              buffObject.transform.parent = gameObject.GetComponent<EnemyUI>().buffManage.transform;                              
                              buffObject.GetComponent<Buff>().buffHeld = 1;
                              buffObject.GetComponent<Buff>().buff = skillList[i].buff;
                              }
                              buffInfoIsAlive = true;
                              buffInfo = skillList[i].buff.buffString;
                              
                              //buff显示
                        
                        break;
                        }
                    }
                   }
                   if(skillList[i].teamBuff)//团队buff
                   {
                        if(skillList[i].teamBuffName)
                    {                          
                       skillName = skillList[i].skillName;
                       skillNameIsAlive = true; 
                    }    
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
                                    
                               
                                    if(targetPlayerUnitList[j].GetComponent<EnemyUI>().buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(skillList[i].buff))
                              {
                                  for(int l = 0; l < targetPlayerUnitList[j].GetComponent<EnemyUI>().buffManage.transform.childCount ; l++)
                                  {
                                      if(targetPlayerUnitList[j].GetComponent<EnemyUI>().buffManage.transform.GetChild(l).GetComponent<Buff>().buff == skillList[i].buff)
                                      {
                                          targetPlayerUnitList[j].GetComponent<EnemyUI>().buffManage.transform.GetChild(l).GetComponent<Buff>().buffHeld += 1;
                                          break;
                                      }
                                  }
                              }
                                   if(!targetPlayerUnitList[j].GetComponent<EnemyUI>().buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(skillList[i].buff))
                              {
                              targetPlayerUnitList[j].GetComponent<EnemyUI>().buffManage.GetComponent<EnemyBuffManager>().buffList.Add(skillList[i].buff);   
                              GameObject buffObject = Instantiate(buffPrefabObject);
                              buffObject.transform.parent = targetPlayerUnitList[j].GetComponent<EnemyUI>().buffManage.transform;                              
                              buffObject.GetComponent<Buff>().buffHeld = 1;
                              buffObject.GetComponent<Buff>().buff = skillList[i].buff;
                              }
                              targetPlayerUnitList[j].GetComponent<EnemyUI>().buffInfoIsAlive = true;
                              targetPlayerUnitList[j].GetComponent<EnemyUI>().buffInfo = skillList[i].buff.buffString;
                             
                              
                              //buff显示
                                    break;
                                }
                            }
                        }
                    }
                   }
                }
                if((endSkillNum) > skillList[i].endSkillOdd)
                {
                    continue;
                }
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
                     if(skillList[i].singleDamageName)
                    {                          
                       skillName = skillList[i].skillName;
                       skillNameIsAlive = true; 
                    }    
                    if(skillList[i].adSkill)
                    {  
                        float damage = ((ad * skillList[i].adSkillFactor) - (targetEnemyUnit.GetComponent<PlayerBattle>().player.def * skillList[i].adSkillFactor));
                            if(damage <= 0 )
                           {
                             damage = 1;
                           }  
                       targetEnemyUnit.GetComponent<PlayerBattle>().player.targetUnit = gameObject;     
                       targetEnemyUnit.GetComponent<PlayerBattle>().player.hp -= damage;
                       
                       for (int n = 0; n < damageList.Count; n++)
                       {
                           if(damageList[n] == 0)
                           {
                               damageList[n] = damage;
                                if(damageList[n] <= 0)
                         {
                             damageList[n] = 1;
                         }        
                                
                                targetEnemyUnit.GetComponent<PlayerBattle>().player.damageNumObjectIsAlive = true;//伤害数值显示
                               targetEnemyUnit.GetComponent<PlayerBattle>().player.damageNumber = damageList[n];
                               break;
                           }
                       }          
                    }
                    if(skillList[i].hpSkill)
                    {  
                        float damage = ((totalhp * skillList[i].hpSkillFactor) - (targetEnemyUnit.GetComponent<PlayerBattle>().player.def * skillList[i].hpSkillFactor));
                            if(damage <= 0 )
                           {
                             damage = 1;
                           } 
                       targetEnemyUnit.GetComponent<PlayerBattle>().player.targetUnit = gameObject;  
                       targetEnemyUnit.GetComponent<PlayerBattle>().player.hp -= damage;
                      
                       for (int n = 0; n < damageList.Count; n++)
                       {
                           if(damageList[n] == 0)
                           {
                               damageList[n] = damage;
                                if(damageList[n] <= 0)
                         {
                             damageList[n] = 1;
                         }        
                         
                               targetEnemyUnit.GetComponent<PlayerBattle>().player.damageNumObjectIsAlive = true;//伤害数值显示
                               targetEnemyUnit.GetComponent<PlayerBattle>().player.damageNumber = damageList[n];
                               break;
                           }
                       }           
                    }
                    if(skillList[i].apSkill)
                    {  
                        float damage = ((ap * skillList[i].apSkillFactor) - (targetEnemyUnit.GetComponent<PlayerBattle>().player.mdef * skillList[i].apSkillFactor));
                            if(damage <= 0 )
                           {
                             damage = 1;
                           }
                        targetEnemyUnit.GetComponent<PlayerBattle>().player.targetUnit = gameObject;   
                       targetEnemyUnit.GetComponent<PlayerBattle>().player.hp -= damage;
                      
                       for (int m = 0; m < damageList.Count; m++)
                       {
                         if(damageList[m] == 0)
                         {
                            damageList[m] = damage;
                             if(damageList[m] <= 0)
                             {
                                damageList[m] = 1;
                             }     
                            
                            targetEnemyUnit.GetComponent<PlayerBattle>().player.damageNumObjectIsAlive = true;//伤害数值显示
                               targetEnemyUnit.GetComponent<PlayerBattle>().player.damageNumber = damageList[m];
                            break;
                         }
                       } 
                    }
                    if(skillList[i].iqSkill)
                    {  
                        float damage = ((iq * skillList[i].iqSkillFactor) - (targetEnemyUnit.GetComponent<PlayerBattle>().player.mdef * skillList[i].iqSkillFactor));
                            if(damage <= 0 )
                           {
                             damage = 1;
                           }
                       targetEnemyUnit.GetComponent<PlayerBattle>().player.targetUnit = gameObject;   
                       targetEnemyUnit.GetComponent<PlayerBattle>().player.hp -=  damage ;
                       
                       for (int m = 0; m < damageList.Count; m++)
                       {
                         if(damageList[m] == 0)
                         {
                            damageList[m] =  damage ;
                             if(damageList[m] <= 0)
                             {
                                damageList[m] = 1;
                             }     
                            
                            targetEnemyUnit.GetComponent<PlayerBattle>().player.damageNumObjectIsAlive = true;//伤害数值显示
                               targetEnemyUnit.GetComponent<PlayerBattle>().player.damageNumber = damageList[m];
                            break;
                         }
                       } 
                    }
                }
                if(skillList[i].teamDamage)//群体伤害技能
                {
                     if(skillList[i].teamDamageName)
                    {                          
                       skillName = skillList[i].skillName;
                       skillNameIsAlive = true; 
                    }    
                    if(skillList[i].adSkill)
                    {  
                       for (int j = 0; j < targetEnemyUnitList.Count; j++)
                       {  
                            float damage = ((ad * skillList[i].adSkillFactor) - (targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.def * skillList[i].adSkillFactor));
                            if(damage <= 0 )
                           {
                             damage = 1;
                           }
                           targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.targetUnit = gameObject;   
                           targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.hp -= damage;
                           
                           for (int m = 0; m < damageList.Count; m++)
                          {
                              if(damageList[m] == 0)
                            { 
                               damageList[m] = damage;
                                if(damageList[m] <= 0)
                             {
                                damageList[m] = 1;
                             }     
                                 
                               targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.damageNumObjectIsAlive = true;//伤害数值显示
                               targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.damageNumber = damageList[m];
                               break;
                            }
                          }
                       }
                    }
                    if(skillList[i].hpSkill)
                    {  
                       for (int j = 0; j < targetEnemyUnitList.Count; j++)
                       {  
                           float damage = ((totalhp * skillList[i].hpSkillFactor) - (targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.def * skillList[i].hpSkillFactor));
                            if(damage <= 0 )
                           {
                             damage = 1;
                           } 
                           targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.targetUnit = gameObject;  
                           targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.hp -= damage;
                           
                           for (int m = 0; m < damageList.Count; m++)
                          {
                              if(damageList[m] == 0)
                            { 
                               damageList[m] = damage;
                                if(damageList[m] <= 0)
                             {
                                damageList[m] = 1;
                             }      
                                
                                targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.damageNumObjectIsAlive = true;//伤害数值显示
                               targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.damageNumber = damageList[m];
                               break;
                            }
                          }
                       }
                    }
                    if(skillList[i].apSkill)
                    {
                        for (int j = 0; j < targetEnemyUnitList.Count; j++)
                       {     
                           float damage = ((ap * skillList[i].apSkillFactor) - (targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.mdef * skillList[i].apSkillFactor));
                            if(damage <= 0 )
                           {
                             damage = 1;
                           }
                           targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.targetUnit = gameObject;                        
                           targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.hp -= damage;
                          
                            for (int m = 0; m < damageList.Count; m++)
                           {
                              if(damageList[m] == 0)
                             { 
                               damageList[m] = damage;
                                if(damageList[m] <= 0)
                             {
                                damageList[m] = 1;
                             }      
                                  
                                targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.damageNumObjectIsAlive = true;//伤害数值显示
                               targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.damageNumber = damageList[m];
                               break;
                            }
                          }
                           
                       }

                    }
                    if(skillList[i].iqSkill)
                    {
                        for (int j = 0; j < targetEnemyUnitList.Count; j++)
                       {    
                           float damage = ((iq * skillList[i].iqSkillFactor) - (targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.mdef * skillList[i].iqSkillFactor));
                            if(damage <= 0 )
                           {
                             damage = 1;
                           } 
                           targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.targetUnit = gameObject;                          
                           targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.hp -= damage;
                           
                            for (int m = 0; m < damageList.Count; m++)
                           {
                              if(damageList[m] == 0)
                             { 
                               damageList[m] = damage;
                                if(damageList[m] <= 0)
                             {
                                damageList[m] = 1;
                             }       
                             
                                targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.damageNumObjectIsAlive = true;//伤害数值显示
                               targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.damageNumber = damageList[m];
                               break;
                            }
                          }
                           
                       }

                    }

                }
                if(skillList[i].singleDebuff)//单体debuff
                {
                     if(skillList[i].singleDebuffName)
                    {                          
                       skillName = skillList[i].skillName;
                       skillNameIsAlive = true; 
                    }    
                   for (int j = 0; j < targetEnemyUnit.GetComponent<PlayerBattle>().player.buffAndDebuffList.Count ; j++)
                   {
                       if(targetEnemyUnit.GetComponent<PlayerBattle>().player.buffAndDebuffList[j] == null)
                       {
                           targetEnemyUnit.GetComponent<PlayerBattle>().player.buffTime[j] = skillList[i].buff.buffTime;
                           targetEnemyUnit.GetComponent<PlayerBattle>().player.buffObjectList[j] = gameObject;
                           targetEnemyUnit.GetComponent<PlayerBattle>().player.buffAndDebuffList[j] = skillList[i].buff;
                           
                         

                            if(targetEnemyUnit.GetComponent<PlayerBattle>().player.buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(skillList[i].buff))
                              {
                                  for(int l = 0; l < targetEnemyUnit.GetComponent<PlayerBattle>().player.buffManage.transform.childCount ; l++)
                                  {
                                      if(targetEnemyUnit.GetComponent<PlayerBattle>().player.buffManage.transform.GetChild(l).GetComponent<Buff>().buff == skillList[i].buff)
                                      {
                                          targetEnemyUnit.GetComponent<PlayerBattle>().player.buffManage.transform.GetChild(l).GetComponent<Buff>().buffHeld += 1;
                                          break;
                                      }
                                  }
                              }
                            if(!targetEnemyUnit.GetComponent<PlayerBattle>().player.buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(skillList[i].buff))
                              {
                              targetEnemyUnit.GetComponent<PlayerBattle>().player.buffManage.GetComponent<EnemyBuffManager>().buffList.Add(skillList[i].buff);   
                              GameObject buffObject = Instantiate(buffPrefabObject);
                              buffObject.transform.parent = targetEnemyUnit.GetComponent<PlayerBattle>().player.buffManage.transform;                              
                              buffObject.GetComponent<Buff>().buffHeld = 1;
                              buffObject.GetComponent<Buff>().buff = skillList[i].buff;
                              }
                             
                              
                              //buff显示

                           break;
                       }
                   }
                }             
                if(skillList[i].teamDebuff)//群体debuff
                {
                     if(skillList[i].teamBuffName)
                    {                          
                       skillName = skillList[i].skillName;
                       skillNameIsAlive = true; 
                    }    
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
                                    
                                  
                                     if(targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(skillList[i].buff))
                              {
                                  for(int l = 0; l < targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffManage.transform.childCount ; l++)
                                  {
                                      if(targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffManage.transform.GetChild(l).GetComponent<Buff>().buff == skillList[i].buff)
                                      {
                                          targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffManage.transform.GetChild(l).GetComponent<Buff>().buffHeld += 1;
                                          break;
                                      }
                                  }
                              }
                               if(!targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(skillList[i].buff))
                              {
                              targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffManage.GetComponent<EnemyBuffManager>().buffList.Add(skillList[i].buff);   
                              GameObject buffObject = Instantiate(buffPrefabObject);
                              buffObject.transform.parent = targetEnemyUnitList[j].GetComponent<PlayerBattle>().player.buffManage.transform;                              
                              buffObject.GetComponent<Buff>().buffHeld = 1;
                              buffObject.GetComponent<Buff>().buff = skillList[i].buff;
                              }
                             
                              
                              //buff显示
                                    break;
                                }
                            }
                        }
                    }

                }
                if(skillList[i].singleBuff)//队友buff
                {
                    if(skillList[i].singleBuffName)
                    {                          
                       skillName = skillList[i].skillName;
                       skillNameIsAlive = true; 
                    }    
                    for (int j = 0; j < targetPlayerUnit.GetComponent<EnemyUI>().buffAndDebuffList.Count; j++)
                    {
                        if(targetPlayerUnit.GetComponent<EnemyUI>().buffAndDebuffList[j] == null)
                        {
                           targetPlayerUnit.GetComponent<EnemyUI>().buffTime[j] = skillList[i].buff.buffTime;
                           targetPlayerUnit.GetComponent<EnemyUI>().buffObjectList[j] = gameObject;
                           targetPlayerUnit.GetComponent<EnemyUI>().buffAndDebuffList[j] = skillList[i].buff;
                           
                          


                           if(targetPlayerUnit.GetComponent<EnemyUI>().buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(skillList[i].buff))
                                  {
                                         for(int k = 0; k < targetPlayerUnit.GetComponent<EnemyUI>().buffManage.transform.childCount ; k++)
                                       {
                                             if(targetPlayerUnit.GetComponent<EnemyUI>().buffManage.transform.GetChild(k).GetComponent<Buff>().buff == skillList[i].buff)
                                            {
                                               targetPlayerUnit.GetComponent<EnemyUI>().buffManage.transform.GetChild(k).GetComponent<Buff>().buffHeld += 1;
                                               break;
                                            }
                                       }
                                  }
                          if(!targetPlayerUnit.GetComponent<EnemyUI>().buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(skillList[i].buff))
                                  {
                                     targetPlayerUnit.GetComponent<EnemyUI>().buffManage.GetComponent<EnemyBuffManager>().buffList.Add(skillList[i].buff);   
                                     GameObject buffObject = Instantiate(buffPrefabObject);
                                     targetPlayerUnit.transform.parent = targetPlayerUnit.GetComponent<EnemyUI>().buffManage.transform;                              
                                     targetPlayerUnit.GetComponent<Buff>().buffHeld = 1;
                                     targetPlayerUnit.GetComponent<Buff>().buff = skillList[i].buff;
                                  }
                                    targetPlayerUnit.GetComponent<EnemyUI>().buffInfoIsAlive = true;
                                    targetPlayerUnit.GetComponent<EnemyUI>().buffInfo = skillList[i].buff.buffString;
                                  
                                  //buff显示

                           break;
                        }
                    }
                   
                }
                if(skillList[i].ownBuff)//自我buff
                {
                    if(skillList[i].ownBuffName)
                    {                          
                       skillName = skillList[i].skillName;
                       skillNameIsAlive = true; 
                    }    
                    for (int j = 0; j < buffAndDebuffList.Count; j++)
                    {
                        if(buffAndDebuffList[j] == null)
                        {                      
                        buffTime[j] = skillList[i].buff.buffTime;
                        buffObjectList[j] = gameObject;
                        buffAndDebuffList[j] = skillList[i].buff;
                       
                         
                         if(gameObject.GetComponent<EnemyUI>().buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(skillList[i].buff))
                                  {
                                         for(int k = 0; k < gameObject.GetComponent<EnemyUI>().buffManage.transform.childCount ; k++)
                                       {
                                             if(gameObject.GetComponent<EnemyUI>().buffManage.transform.GetChild(k).GetComponent<Buff>().buff == skillList[i].buff)
                                            {
                                               gameObject.GetComponent<EnemyUI>().buffManage.transform.GetChild(k).GetComponent<Buff>().buffHeld += 1;
                                               break;
                                            }
                                       }
                                  }
                       if(!gameObject.GetComponent<EnemyUI>().buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(skillList[i].buff))
                                  {
                                     gameObject.GetComponent<EnemyUI>().buffManage.GetComponent<EnemyBuffManager>().buffList.Add(skillList[i].buff);   
                                     GameObject buffObject = Instantiate(buffPrefabObject);
                                     buffObject.transform.parent = gameObject.GetComponent<EnemyUI>().buffManage.transform;                              
                                     buffObject.GetComponent<Buff>().buffHeld = 1;
                                     buffObject.GetComponent<Buff>().buff = skillList[i].buff;
                                  }
                                   
                                   buffInfoIsAlive = true;                                   
                                   buffInfo = skillList[i].buff.buffString;
                                    
                                  
                                  //buff显示
                        break;
                        }
                    }
                }
                if(skillList[i].teamBuff)//团队buff
                {
                    if(skillList[i].teamBuffName)
                    {                          
                       skillName = skillList[i].skillName;
                       skillNameIsAlive = true; 
                    }    
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
                                    
                                   
                                     if(targetPlayerUnitList[j].GetComponent<EnemyUI>().buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(skillList[i].buff))
                                  {
                                         for(int l = 0; l < targetPlayerUnitList[j].GetComponent<EnemyUI>().buffManage.transform.childCount ; l++)
                                       {
                                             if(targetPlayerUnitList[j].GetComponent<EnemyUI>().buffManage.transform.GetChild(l).GetComponent<Buff>().buff == skillList[i].buff)
                                            {
                                               targetPlayerUnitList[j].GetComponent<EnemyUI>().buffManage.transform.GetChild(l).GetComponent<Buff>().buffHeld += 1;
                                               break;
                                            }
                                       }
                                  }
                                     else//if(!targetPlayerUnitList[j].GetComponent<EnemyUI>().buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(skillList[i].buff))
                                  {
                                     targetPlayerUnitList[j].GetComponent<EnemyUI>().buffManage.GetComponent<EnemyBuffManager>().buffList.Add(skillList[i].buff);   
                                     GameObject buffObject = Instantiate(buffPrefabObject);
                                     buffObject.transform.parent = targetPlayerUnitList[j].GetComponent<EnemyUI>().buffManage.transform;                              
                                     buffObject.GetComponent<Buff>().buffHeld = 1;
                                     buffObject.GetComponent<Buff>().buff = skillList[i].buff;
                                  }
                                    targetPlayerUnitList[j].GetComponent<EnemyUI>().buffInfoIsAlive = true;
                                    targetPlayerUnitList[j].GetComponent<EnemyUI>().buffInfo = skillList[i].buff.buffString;
                                  
                                  //buff显示
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
                        if(targetUnit.GetComponent<PlayerBattle>().player.skillList[i].singleDamageName)
                    {                          
                       targetUnit.GetComponent<PlayerBattle>().player.skillName = targetUnit.GetComponent<PlayerBattle>().player.skillList[i].skillName;
                       targetUnit.GetComponent<PlayerBattle>().player.skillNameIsAlive = true; 
                    }    
                        if(targetUnit.GetComponent<PlayerBattle>().player.skillList[i].adSkill)
                        {
                             float damage = ((targetUnit.GetComponent<PlayerBattle>().player.ad * targetUnit.GetComponent<PlayerBattle>().player.skillList[i].adSkillFactor) - (targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().def * targetUnit.GetComponent<PlayerBattle>().player.skillList[i].adSkillFactor));
                             if(damage <= 0 )
                             {
                               damage = 1;
                             } 
                            targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().targetUnit = targetUnit;      
                            targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().hp -= damage;
                            
                            for (int n = 0; n < targetUnit.GetComponent<PlayerBattle>().player.damageList.Count; n++)
                         {
                           if(targetUnit.GetComponent<PlayerBattle>().player.damageList[n] == 0)
                           {
                               targetUnit.GetComponent<PlayerBattle>().player.damageList[n] = damage;
                                if(targetUnit.GetComponent<PlayerBattle>().player.damageList[n] <= 0)
                         {
                             targetUnit.GetComponent<PlayerBattle>().player.damageList[n] = 1;
                         }        
                              
                               targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().damageNumObjectIsAlive = true;//伤害数值显示
                               targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().damageNumber = targetUnit.GetComponent<PlayerBattle>().player.damageList[n];
                               break;
                           }
                         }          
                        }
                        if(targetUnit.GetComponent<PlayerBattle>().player.skillList[i].hpSkill)
                        {
                             float damage = ((targetUnit.GetComponent<PlayerBattle>().player.totalhp * targetUnit.GetComponent<PlayerBattle>().player.skillList[i].hpSkillFactor) - (targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().def * targetUnit.GetComponent<PlayerBattle>().player.skillList[i].hpSkillFactor));
                             if(damage <= 0 )
                             {
                               damage = 1;
                             }     
                            targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().targetUnit = targetUnit;
                            targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().hp -= damage;
                            
                              for (int n = 0; n < targetUnit.GetComponent<PlayerBattle>().player.damageList.Count; n++)
                       {
                           if(targetUnit.GetComponent<PlayerBattle>().player.damageList[n] == 0)
                           {
                               targetUnit.GetComponent<PlayerBattle>().player.damageList[n] = damage;
                               if(targetUnit.GetComponent<PlayerBattle>().player.damageList[n] <= 0)
                               {
                                  targetUnit.GetComponent<PlayerBattle>().player.damageList[n] = 1;
                               }        
                               
                               targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().damageNumObjectIsAlive = true;//伤害数值显示
                               targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().damageNumber = targetUnit.GetComponent<PlayerBattle>().player.damageList[n];
                               break;
                           }
                       }          
                        }
                        if(targetUnit.GetComponent<PlayerBattle>().player.skillList[i].apSkill)
                        {
                            float damage = ((targetUnit.GetComponent<PlayerBattle>().player.ap * targetUnit.GetComponent<PlayerBattle>().player.skillList[i].apSkillFactor) - (targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().mdef * targetUnit.GetComponent<PlayerBattle>().player.skillList[i].apSkillFactor));
                             if(damage <= 0 )
                             {
                               damage = 1;
                             }  
                            targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().targetUnit = targetUnit;   
                            targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().hp -= damage;
                           
                            
                            for (int n = 0; n < targetUnit.GetComponent<PlayerBattle>().player.damageList.Count; n++)
                            {

                            
                            if(targetUnit.GetComponent<PlayerBattle>().player.damageList[n] == 0)
                           {
                               targetUnit.GetComponent<PlayerBattle>().player.damageList[n] =  damage;
                               if(targetUnit.GetComponent<PlayerBattle>().player.damageList[n] <= 0)
                               {
                                  targetUnit.GetComponent<PlayerBattle>().player.damageList[n] = 1;
                               }
                                      
                               targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().damageNumObjectIsAlive = true;//伤害数值显示
                               targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().damageNumber = targetUnit.GetComponent<PlayerBattle>().player.damageList[n];
                               break;
                           }
                            }
                        }
                        if(targetUnit.GetComponent<PlayerBattle>().player.skillList[i].iqSkill)
                        {
                            float damage = ((targetUnit.GetComponent<PlayerBattle>().player.iq * targetUnit.GetComponent<PlayerBattle>().player.skillList[i].iqSkillFactor) - (targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().mdef * targetUnit.GetComponent<PlayerBattle>().player.skillList[i].iqSkillFactor));
                             if(damage <= 0 )
                             {
                               damage = 1;
                             }
                             targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().targetUnit = targetUnit;   
                            targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().hp -= damage;
                            
                            for (int n = 0; n < targetUnit.GetComponent<PlayerBattle>().player.damageList.Count; n++)
                            { 
                            if(targetUnit.GetComponent<PlayerBattle>().player.damageList[n] == 0)
                           {
                               targetUnit.GetComponent<PlayerBattle>().player.damageList[n] = damage;
                               if(targetUnit.GetComponent<PlayerBattle>().player.damageList[n] <= 0)
                               {
                                  targetUnit.GetComponent<PlayerBattle>().player.damageList[n] = 1;
                               } 
                                          
                               targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().damageNumObjectIsAlive = true;//伤害数值显示
                               targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().damageNumber = damageList[n];
                               break;
                           }
                            }
                        }
                    }
                    if(targetUnit.GetComponent<PlayerBattle>().player.skillList[i].teamDamage)//团队伤害
                    {
                        if(targetUnit.GetComponent<PlayerBattle>().player.skillList[i].teamDamageName)
                    {                          
                       targetUnit.GetComponent<PlayerBattle>().player.skillName = targetUnit.GetComponent<PlayerBattle>().player.skillList[i].skillName;
                       targetUnit.GetComponent<PlayerBattle>().player.skillNameIsAlive = true; 
                    }    
                        if(targetUnit.GetComponent<PlayerBattle>().player.skillList[i].adSkill)
                        {
                            for (int j = 0; j < targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList.Count; j++)
                            { 
                                float damage = ((targetUnit.GetComponent<PlayerBattle>().player.ad * targetUnit.GetComponent<PlayerBattle>().player.skillList[i].adSkillFactor) - (targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList[j].GetComponent<EnemyUI>().def * targetUnit.GetComponent<PlayerBattle>().player.skillList[i].adSkillFactor));
                                if(damage <= 0 )
                                {
                                  damage = 1;
                                } 
                             targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList[j].GetComponent<EnemyUI>().targetUnit = targetUnit;   
                             targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList[j].GetComponent<EnemyUI>().hp -= damage;
                             
                             for (int n = 0; n < targetUnit.GetComponent<PlayerBattle>().player.damageList.Count; n++)
                            { 
                            if(targetUnit.GetComponent<PlayerBattle>().player.damageList[n] == 0)
                           {
                               targetUnit.GetComponent<PlayerBattle>().player.damageList[n] = damage;
                               if(targetUnit.GetComponent<PlayerBattle>().player.damageList[n] <= 0)
                               {
                                  targetUnit.GetComponent<PlayerBattle>().player.damageList[n] = 1;
                               }  
                                          
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
                                float damage = ((targetUnit.GetComponent<PlayerBattle>().player.totalhp * targetUnit.GetComponent<PlayerBattle>().player.skillList[i].hpSkillFactor) - (targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList[j].GetComponent<EnemyUI>().def * targetUnit.GetComponent<PlayerBattle>().player.skillList[i].hpSkillFactor));
                                if(damage <= 0 )
                                {
                                  damage = 1;
                                }
                             targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList[j].GetComponent<EnemyUI>().targetUnit = targetUnit;    
                             targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList[j].GetComponent<EnemyUI>().hp -= damage;
                             
                             for (int n = 0; n < targetUnit.GetComponent<PlayerBattle>().player.damageList.Count; n++)
                            { 
                            if(targetUnit.GetComponent<PlayerBattle>().player.damageList[n] == 0)
                           {
                               targetUnit.GetComponent<PlayerBattle>().player.damageList[n] = damage;
                               if(targetUnit.GetComponent<PlayerBattle>().player.damageList[n] <= 0)
                               {
                                  targetUnit.GetComponent<PlayerBattle>().player.damageList[n] = 1;
                               } 
                                        
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
                                 float damage = ((targetUnit.GetComponent<PlayerBattle>().player.ap * targetUnit.GetComponent<PlayerBattle>().player.skillList[i].apSkillFactor) - (targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList[j].GetComponent<EnemyUI>().mdef * targetUnit.GetComponent<PlayerBattle>().player.skillList[i].apSkillFactor));
                                if(damage <= 0 )
                                {
                                  damage = 1;
                                } 
                             targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList[j].GetComponent<EnemyUI>().targetUnit = targetUnit;   
                             targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList[j].GetComponent<EnemyUI>().hp -= damage;
                             
                              for (int n = 0; n < targetUnit.GetComponent<PlayerBattle>().player.damageList.Count; n++)
                            { 
                            if(targetUnit.GetComponent<PlayerBattle>().player.damageList[n] == 0)
                           {
                               targetUnit.GetComponent<PlayerBattle>().player.damageList[n] = damage;
                               if(targetUnit.GetComponent<PlayerBattle>().player.damageList[n] <= 0)
                               {
                                  targetUnit.GetComponent<PlayerBattle>().player.damageList[n] = 1;
                               } 
                              
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
                                float damage = ((targetUnit.GetComponent<PlayerBattle>().player.iq * targetUnit.GetComponent<PlayerBattle>().player.skillList[i].iqSkillFactor) - (targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList[j].GetComponent<EnemyUI>().mdef * targetUnit.GetComponent<PlayerBattle>().player.skillList[i].iqSkillFactor));
                                if(damage <= 0 )
                                {
                                  damage = 1;
                                }
                             targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList[j].GetComponent<EnemyUI>().targetUnit = targetUnit;     
                             targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList[j].GetComponent<EnemyUI>().hp -= damage;
                             
                              for (int n = 0; n < targetUnit.GetComponent<PlayerBattle>().player.damageList.Count; n++)
                            { 
                            if(targetUnit.GetComponent<PlayerBattle>().player.damageList[n] == 0)
                           {
                               targetUnit.GetComponent<PlayerBattle>().player.damageList[n] = damage;
                               if(targetUnit.GetComponent<PlayerBattle>().player.damageList[n] <= 0)
                               {
                                  targetUnit.GetComponent<PlayerBattle>().player.damageList[n] = 1;
                               }  
                                   
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
                        if(targetUnit.GetComponent<PlayerBattle>().player.skillList[i].ownBuffName)
                    {                          
                       targetUnit.GetComponent<PlayerBattle>().player.skillName = targetUnit.GetComponent<PlayerBattle>().player.skillList[i].skillName;
                       targetUnit.GetComponent<PlayerBattle>().player.skillNameIsAlive = true; 
                    }    
                         for (int j = 0; j < targetUnit.GetComponent<PlayerBattle>().player.buffAndDebuffList.Count; j++)
                         {
                             if(targetUnit.GetComponent<PlayerBattle>().player.buffAndDebuffList[j] == null)
                             {
                         targetUnit.GetComponent<PlayerBattle>().player.buffTime[j] = targetUnit.GetComponent<PlayerBattle>().player.skillList[i].buff.buffTime;
                         targetUnit.GetComponent<PlayerBattle>().player.buffObjectList[j] = targetUnit;
                         targetUnit.GetComponent<PlayerBattle>().player.buffAndDebuffList[j] = targetUnit.GetComponent<PlayerBattle>().player.skillList[i].buff;
                        
                      

                       if(targetUnit.GetComponent<PlayerBattle>().player.buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(targetUnit.GetComponent<PlayerBattle>().player.skillList[i].buff))
                              {
                                  for(int m = 0; m < targetUnit.GetComponent<PlayerBattle>().player.buffManage.transform.childCount; m++)
                                  {
                                      if(targetUnit.GetComponent<PlayerBattle>().player.buffManage.transform.GetChild(m).gameObject.GetComponent<Buff>().buff == targetUnit.GetComponent<PlayerBattle>().player.skillList[i].buff)
                                      {
                                          targetUnit.GetComponent<PlayerBattle>().player.buffManage.transform.GetChild(m).gameObject.GetComponent<Buff>().buffHeld += 1;
                                          break;
                                      }
                                  }
                              }
                              else
                        //if(!targetUnit.GetComponent<PlayerBattle>().player.buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(targetUnit.GetComponent<PlayerBattle>().player.skillList[j].buff))
                              {
                              targetUnit.GetComponent<PlayerBattle>().player.buffManage.GetComponent<EnemyBuffManager>().buffList.Add(targetUnit.GetComponent<PlayerBattle>().player.skillList[i].buff);   
                              GameObject buffObject = Instantiate(buffPrefabObject);
                              buffObject.transform.parent = targetUnit.GetComponent<PlayerBattle>().player.buffManage.transform;                              
                              buffObject.GetComponent<Buff>().buffHeld = 1;
                              buffObject.GetComponent<Buff>().buff = targetUnit.GetComponent<PlayerBattle>().player.skillList[i].buff;
                              
                              }

                              
                              //buff显示
                             break;
                             }
                         }
                    }
                    if(targetUnit.GetComponent<PlayerBattle>().player.skillList[i].teamBuff)//团队buff
                    {
                        if(targetUnit.GetComponent<PlayerBattle>().player.skillList[i].teamBuffName)
                    {                          
                       targetUnit.GetComponent<PlayerBattle>().player.skillName = targetUnit.GetComponent<PlayerBattle>().player.skillList[i].skillName;
                       targetUnit.GetComponent<PlayerBattle>().player.skillNameIsAlive = true; 
                    }    
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
                                    
                                   

                                     if(targetUnit.GetComponent<PlayerBattle>().player.targetPlayerUnitList[j].GetComponent<PlayerBattle>().player.buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(targetUnit.GetComponent<PlayerBattle>().player.skillList[i].buff))
                              {
                                  for(int m = 0; m < targetUnit.GetComponent<PlayerBattle>().player.targetPlayerUnitList[j].GetComponent<PlayerBattle>().player.buffManage.transform.childCount ; m++)
                                  {
                                      if(targetUnit.GetComponent<PlayerBattle>().player.targetPlayerUnitList[j].GetComponent<PlayerBattle>().player.buffManage.transform.GetChild(m).GetComponent<Buff>().buff == targetUnit.GetComponent<PlayerBattle>().player.skillList[i].buff)
                                      {
                                          targetUnit.GetComponent<PlayerBattle>().player.targetPlayerUnitList[j].GetComponent<PlayerBattle>().player.buffManage.transform.GetChild(m).GetComponent<Buff>().buffHeld += 1;
                                          break;
                                      }
                                  }
                              }

                                   else  //if(!targetUnit.GetComponent<PlayerBattle>().player.targetPlayerUnitList[j].GetComponent<PlayerBattle>().player.buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(targetUnit.GetComponent<PlayerBattle>().player.skillList[j].buff))
                              {
                              targetUnit.GetComponent<PlayerBattle>().player.targetPlayerUnitList[j].GetComponent<PlayerBattle>().player.buffManage.GetComponent<EnemyBuffManager>().buffList.Add(targetUnit.GetComponent<PlayerBattle>().player.skillList[i].buff);   
                              GameObject buffObject = Instantiate(buffPrefabObject);
                              buffObject.transform.parent = targetUnit.GetComponent<PlayerBattle>().player.targetPlayerUnitList[k].GetComponent<PlayerBattle>().player.buffManage.transform;                              
                              buffObject.GetComponent<Buff>().buffHeld = 1;
                              buffObject.GetComponent<Buff>().buff = targetUnit.GetComponent<PlayerBattle>().player.skillList[i].buff;
                              }
                              targetUnit.GetComponent<PlayerBattle>().player.targetPlayerUnitList[j].GetComponent<PlayerBattle>().player.buffInfoIsAlive = true;
                              targetUnit.GetComponent<PlayerBattle>().player.targetPlayerUnitList[j].GetComponent<PlayerBattle>().player.buffInfo = targetUnit.GetComponent<PlayerBattle>().player.skillList[i].buff.buffString;
                             
                              
                              //buff显示



                                    break;
                                }
                            }
                        }
                       }
                    }
                    if(targetUnit.GetComponent<PlayerBattle>().player.skillList[i].teamDebuff)//团队debuff
                    {
                        if(targetUnit.GetComponent<PlayerBattle>().player.skillList[i].teamDebuffName)
                    {                          
                       targetUnit.GetComponent<PlayerBattle>().player.skillName = targetUnit.GetComponent<PlayerBattle>().player.skillList[i].skillName;
                       targetUnit.GetComponent<PlayerBattle>().player.skillNameIsAlive = true; 
                    }    
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
                                    
                                     
                                if(targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList[j].GetComponent<EnemyUI>().buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(targetUnit.GetComponent<PlayerBattle>().player.skillList[i].buff))
                              {
                                  for(int l = 0; l < targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList[j].GetComponent<EnemyUI>().buffManage.transform.childCount ; l++)
                                  {
                                      if(targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList[j].GetComponent<EnemyUI>().buffManage.transform.GetChild(l).GetComponent<Buff>().buff == targetUnit.GetComponent<PlayerBattle>().player.skillList[i].buff)
                                      {
                                          targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList[j].GetComponent<EnemyUI>().buffManage.transform.GetChild(l).GetComponent<Buff>().buffHeld += 1;
                                          break;
                                      }
                                  }
                              }
                               else //if(!targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList[j].GetComponent<EnemyUI>().buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(targetUnit.GetComponent<PlayerBattle>().player.skillList[i].buff))
                              {
                              targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList[j].GetComponent<EnemyUI>().buffManage.GetComponent<EnemyBuffManager>().buffList.Add(targetUnit.GetComponent<PlayerBattle>().player.skillList[i].buff);   
                              GameObject buffObject = Instantiate(buffPrefabObject);
                              buffObject.transform.parent = targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList[j].GetComponent<EnemyUI>().buffManage.transform;                              
                              buffObject.GetComponent<Buff>().buffHeld = 1;
                              buffObject.GetComponent<Buff>().buff = targetUnit.GetComponent<PlayerBattle>().player.skillList[i].buff;
                              }
                              targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList[j].GetComponent<EnemyUI>().buffInfoIsAlive = true;
                              targetUnit.GetComponent<PlayerBattle>().player.targetEnemyUnitList[j].GetComponent<EnemyUI>().buffInfo = targetUnit.GetComponent<PlayerBattle>().player.skillList[i].buff.buffString;
                              
                              //buff显示
                                    break;
                                }
                            }
                        }
                       }
                    }
                    if(targetUnit.GetComponent<PlayerBattle>().player.skillList[i].growthSkill)//成长
                    {
                         targetUnit.GetComponent<PlayerBattle>().player.skillName = targetUnit.GetComponent<PlayerBattle>().player.skillList[i].skillName;
                         targetUnit.GetComponent<PlayerBattle>().player.skillNameIsAlive = true;   
                        targetUnit.GetComponent<PlayerBattle>().player.growthAd += targetUnit.GetComponent<PlayerBattle>().player.skillList[i].ad;
                        targetUnit.GetComponent<PlayerBattle>().player.growthAp += targetUnit.GetComponent<PlayerBattle>().player.skillList[i].ap;
                        targetUnit.GetComponent<PlayerBattle>().player.growthTotalhp += targetUnit.GetComponent<PlayerBattle>().player.skillList[i].totalhp;
                        targetUnit.GetComponent<PlayerBattle>().player.growthSpeed += targetUnit.GetComponent<PlayerBattle>().player.skillList[i].speed;
                        targetUnit.GetComponent<PlayerBattle>().player.growthDef += targetUnit.GetComponent<PlayerBattle>().player.skillList[i].def;
                        targetUnit.GetComponent<PlayerBattle>().player.growthMdef += targetUnit.GetComponent<PlayerBattle>().player.skillList[i].mdef;
                        targetUnit.GetComponent<PlayerBattle>().player.growthCritDamge += targetUnit.GetComponent<PlayerBattle>().player.skillList[i].critDamge;
                        targetUnit.GetComponent<PlayerBattle>().player.growthIq += targetUnit.GetComponent<PlayerBattle>().player.skillList[i].iq;
                        targetUnit.GetComponent<PlayerBattle>().player.growthCharm += targetUnit.GetComponent<PlayerBattle>().player.skillList[i].charm;
                    }  
                }
             }
            }
            
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
                        if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[i].singleDamageName)
                    {                          
                       targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillName = targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[i].skillName;
                       targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillNameIsAlive = true; 
                    }    
                        if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].adSkill)
                        {
                             float damage = ((targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.ad * targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].adSkillFactor) - (targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().def * targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].adSkillFactor));
                                if(damage <= 0 )
                                {
                                  damage = 1;
                                }     
                            targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().hp -= damage;
                            targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().targetUnit = targetEnemyUnitList[i];
                            for (int n = 0; n < targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList.Count; n++)
                            { 
                            if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n] == 0)
                           {
                               targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n] = damage;
                               if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n] <= 0)
                               {
                                  targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n] = 1;
                               }        
                               
                               targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().damageNumObjectIsAlive = true;//伤害数值显示
                               targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().damageNumber = targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n];
                               break;
                           }
                            }
                            
                        }
                        if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].hpSkill)
                        {
                            float damage = ((targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.totalhp * targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].hpSkillFactor) - (targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().def * targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].hpSkillFactor));
                                if(damage <= 0 )
                                {
                                  damage = 1;
                                }  
                            targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().hp -= damage;
                            targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().targetUnit = targetEnemyUnitList[i];
                            for (int n = 0; n < targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList.Count; n++)
                            { 
                            if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n] == 0)
                           {
                               targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n] = damage;
                               if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n] <= 0)
                               {
                                  targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n] = 1;
                               } 
                               
                               targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().damageNumObjectIsAlive = true;//伤害数值显示
                               targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().damageNumber = targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n];
                               break;
                           }
                            }
                        }
                        if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].apSkill)
                        {
                            float damage = ((targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.ap * targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].apSkillFactor) - (targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().mdef * targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].apSkillFactor));
                                if(damage <= 0 )
                                {
                                  damage = 1;
                                }  
                            targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().hp -= damage;
                            targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().targetUnit = targetEnemyUnitList[i];
                            for (int n = 0; n < targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList.Count; n++)
                            { 
                            if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n] == 0)
                           {
                               targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n] = damage;
                               if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n] <= 0)
                               {
                                  targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n] = 1;
                               } 
                              
                               targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().damageNumObjectIsAlive = true;//伤害数值显示
                               targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().damageNumber = targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n];
                               break;
                           }
                            }
                        }
                        if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].iqSkill)
                        {
                            float damage = ((targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.iq * targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].iqSkillFactor) - (targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().mdef * targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].iqSkillFactor));
                                if(damage <= 0 )
                                {
                                  damage = 1;
                                }  
                            targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().hp -= damage;
                            targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().targetUnit = targetEnemyUnitList[i];
                            for (int n = 0; n < targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList.Count; n++)
                            { 
                            if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n] == 0)
                           {
                               targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n] = damage;
                               if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n] <= 0)
                               {
                                  targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n] = 1;
                               } 
                                
                               targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().damageNumObjectIsAlive = true;//伤害数值显示
                               targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnit.GetComponent<EnemyUI>().damageNumber = targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n];
                               break;
                           }
                            }
                        }
                    }
                    if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].teamDamage)//团队伤害
                    {
                        if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[i].teamDamageName)
                    {                          
                       targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillName = targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[i].skillName;
                       targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillNameIsAlive = true; 
                    }    
                        if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].adSkill)
                        {
                            for (int k = 0; k < targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList.Count; k++)
                            {  
                                float damage = ((targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.ad * targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].adSkillFactor) - (targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList[k].GetComponent<EnemyUI>().def * targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].adSkillFactor));
                                if(damage <= 0 )
                                {
                                  damage = 1;
                                }  
                             targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList[k].GetComponent<EnemyUI>().hp -= damage;
                             targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList[k].GetComponent<EnemyUI>().targetUnit = targetEnemyUnitList[i];
                             for (int n = 0; n < targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList.Count; n++)
                            { 
                            if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n] == 0)
                           {
                               targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n] = damage;
                               if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n] <= 0)
                               {
                                  targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n] = 1;
                               }  
                                 
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
                                float damage = ((targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.totalhp * targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].hpSkillFactor) - (targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList[k].GetComponent<EnemyUI>().def * targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].hpSkillFactor));
                                if(damage <= 0 )
                                {
                                  damage = 1;
                                }  
                             targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList[k].GetComponent<EnemyUI>().hp -= damage;
                             targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList[k].GetComponent<EnemyUI>().targetUnit = targetEnemyUnitList[i];
                             for (int n = 0; n < targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList.Count; n++)
                            { 
                            if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n] == 0)
                           {
                               targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n] = damage;
                               if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n] <= 0)
                               {
                                  targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n] = 1;
                               }  
                              
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
                                float damage = ((targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.ap * targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].apSkillFactor) - (targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList[k].GetComponent<EnemyUI>().mdef * targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].apSkillFactor));
                                if(damage <= 0 )
                                {
                                  damage = 1;
                                }  
                             targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList[k].GetComponent<EnemyUI>().hp -= damage;
                             targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList[k].GetComponent<EnemyUI>().targetUnit = targetEnemyUnitList[i];
                              for (int n = 0; n < targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList.Count; n++)
                            { 
                            if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n] == 0)
                           {
                               targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n] = damage;
                               if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n] <= 0)
                               {
                                  targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n] = 1;
                               }  
                                
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
                                float damage = ((targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.iq * targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].iqSkillFactor) - (targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList[k].GetComponent<EnemyUI>().mdef * targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].iqSkillFactor));
                                if(damage <= 0 )
                                {
                                  damage = 1;
                                }  
                             targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList[k].GetComponent<EnemyUI>().hp -= damage;
                             targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList[k].GetComponent<EnemyUI>().targetUnit = targetEnemyUnitList[i];
                              for (int n = 0; n < targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList.Count; n++)
                            { 
                            if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n] == 0)
                           {
                               targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n] = damage;
                               if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n] <= 0)
                               {
                                  targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n] = 1;
                               }   
                               
                               targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList[k].GetComponent<EnemyUI>().damageNumObjectIsAlive = true;//伤害数值显示
                               targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList[k].GetComponent<EnemyUI>().damageNumber = targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.damageList[n];
                               break;
                           }
                            }
                            }
                        }
                    }

                        if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].ownBuff)//自我buff
                    { 
                         for (int k = 0; k < targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.buffAndDebuffList.Count; k++)
                         {
                             if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.buffAndDebuffList[k] == null)
                             {              
                                        
                         targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.buffTime[k] = targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].buff.buffTime;
                         
                         targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.buffObjectList[k] = targetEnemyUnitList[i];
                         
                         targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.buffAndDebuffList[k] = targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].buff;
                        
                                 targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillName = targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[i].skillName;
                                 targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillNameIsAlive = true;   


                                             
                           if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].buff))
                              {
                                  for(int m = 0; m < targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.buffManage.transform.childCount ; m++)
                                  {
                                      if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.buffManage.transform.GetChild(m).GetComponent<Buff>().buff == targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].buff)
                                      {
                                          targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.buffManage.transform.GetChild(m).GetComponent<Buff>().buffHeld += 1;
                                          break;
                                      }
                                  }
                              }
                              else
                           // if(!targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].buff))
                              {Debug.Log("888");
                              targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.buffManage.GetComponent<EnemyBuffManager>().buffList.Add(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].buff);   
                              GameObject buffObject = Instantiate(buffPrefabObject);
                              buffObject.transform.parent = targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.buffManage.transform;                              
                              buffObject.GetComponent<Buff>().buffHeld = 1;
                              buffObject.GetComponent<Buff>().buff = targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].buff;
                              
                              }
                         
                              
                              
                              //buff显示

                         break;
                             }
                         }
                    }
                    if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].teamBuff)//团队buff
                    {
                        if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[i].teamBuffName)
                    {                          
                       targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillName = targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[i].skillName;
                       targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillNameIsAlive = true; 
                    }    
                        for (int k = 0; k < targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetPlayerUnitList.Count; k++)
                      {
                        if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetPlayerUnitList[k] != null)
                        {
                            for (int l = 0; l < targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetPlayerUnitList[k].GetComponent<PlayerBattle>().player.buffAndDebuffList.Count; l++)
                            {
                                if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetPlayerUnitList[k].GetComponent<PlayerBattle>().player.buffAndDebuffList[l] == null)
                                {
                                    targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetPlayerUnitList[k].GetComponent<PlayerBattle>().player.buffTime[l] = targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].buff.buffTime;
                                    targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetPlayerUnitList[k].GetComponent<PlayerBattle>().player.buffObjectList[l] = targetEnemyUnitList[i];
                                    targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetPlayerUnitList[k].GetComponent<PlayerBattle>().player.buffAndDebuffList[l] = targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].buff;
                                    
                                   


                                 if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetPlayerUnitList[k].GetComponent<PlayerBattle>().player.buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].buff))
                              {
                                  for(int m = 0; m < targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetPlayerUnitList[k].GetComponent<PlayerBattle>().player.buffManage.transform.childCount ; m++)
                                  {
                                      if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetPlayerUnitList[k].GetComponent<PlayerBattle>().player.buffManage.transform.GetChild(m).GetComponent<Buff>().buff == targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].buff)
                                      {
                                          targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetPlayerUnitList[k].GetComponent<PlayerBattle>().player.buffManage.transform.GetChild(m).GetComponent<Buff>().buffHeld += 1;
                                          break;
                                      }
                                  }
                              }
                               else// if(!targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetPlayerUnitList[k].GetComponent<PlayerBattle>().player.buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].buff))
                              {
                              targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetPlayerUnitList[k].GetComponent<PlayerBattle>().player.buffManage.GetComponent<EnemyBuffManager>().buffList.Add(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].buff);   
                              GameObject buffObject = Instantiate(buffPrefabObject);
                              buffObject.transform.parent = targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetPlayerUnitList[k].GetComponent<PlayerBattle>().player.buffManage.transform;                              
                              buffObject.GetComponent<Buff>().buffHeld = 1;
                              buffObject.GetComponent<Buff>().buff = targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[i].buff;
                              }
                              targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetPlayerUnitList[k].GetComponent<PlayerBattle>().player.buffInfoIsAlive = true;
                              targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetPlayerUnitList[k].GetComponent<PlayerBattle>().player.buffInfo = targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].buff.buffString;
                             
                              
                              //buff显示

                                    break;
                                }
                            }
                        }
                       }
                    }
                    if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].teamDebuff)//团队debuff
                    {
                        if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[i].teamDebuffName)
                    {                          
                       targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillName = targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[i].skillName;
                       targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillNameIsAlive = true; 
                    }    
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
                                    
                                  


                                if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList[k].GetComponent<EnemyUI>().buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].buff))
                              {
                                  for(int m = 0; m < targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList[k].GetComponent<EnemyUI>().buffManage.transform.childCount ; m++)
                                  {
                                      if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList[k].GetComponent<EnemyUI>().buffManage.transform.GetChild(m).GetComponent<Buff>().buff == targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].buff)
                                      {
                                          targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList[k].GetComponent<EnemyUI>().buffManage.transform.GetChild(m).GetComponent<Buff>().buffHeld += 1;
                                          break;
                                      }
                                  }
                              }
                                   else //if(!targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList[k].GetComponent<EnemyUI>().buffManage.GetComponent<EnemyBuffManager>().buffList.Contains(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].buff))
                              {
                              targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList[k].GetComponent<EnemyUI>().buffManage.GetComponent<EnemyBuffManager>().buffList.Add(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].buff);   
                              GameObject buffObject = Instantiate(buffPrefabObject);
                              buffObject.transform.parent = targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList[k].GetComponent<EnemyUI>().buffManage.transform;                              
                              buffObject.GetComponent<Buff>().buffHeld = 1;
                              buffObject.GetComponent<Buff>().buff = targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[i].buff;
                              }
                              
                              targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList[j].GetComponent<EnemyUI>().buffInfoIsAlive = true;
                              targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.targetEnemyUnitList[j].GetComponent<EnemyUI>().buffInfo = targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[j].buff.buffString;
                              //buff显示

                               
                                    break;
                                }
                            }
                        }
                       }
                    }
                    if(targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[i].growthSkill)//成长
                    {
                        targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillName = targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[i].skillName;
                        targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillNameIsAlive = true;   
                        targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.growthAd += targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[i].ad;
                        targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.growthAp += targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[i].ap;
                        targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.growthTotalhp += targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[i].totalhp;
                        targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.growthSpeed += targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[i].speed;
                        targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.growthDef += targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[i].def;
                        targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.growthMdef += targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[i].mdef;
                        targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.growthCritDamge += targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[i].critDamge;
                        targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.growthIq += targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[i].iq;
                        targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.growthCharm += targetEnemyUnitList[i].GetComponent<PlayerBattle>().player.skillList[i].charm;
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
        

       targetUnit.GetComponent<PlayerBattle>().player.point += point;
       battleManage.remainEnemyList.Remove(gameObject);
       Destroy(gameObject);
        
    }         
}


}

